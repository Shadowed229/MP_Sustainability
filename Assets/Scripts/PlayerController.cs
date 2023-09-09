using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;
using System;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Rigidbody2D theRB; // rigid body component attached in player
    public Vector2 moveInput; // to get vecotr2 value of the player object
    private SpriteRenderer sr; // to get vecotr2 value of the player object
    AudioSource audioSource;
    public bool isWorking;
    public Image DashImage;
    public SpriteRenderer spriteRenderer;
    public Animator animator; 


    [Serializable]
    public struct PlayerStats
    {
        public float moveSpeed;
        public float dashSpeed;
        public float stamina;
    }

    [SerializeField]
    private PlayerStats stats;

    private float activeMoveSpeed;

    [HideInInspector]
    public float dashLength = 0.5f, dashCooldown = 1f;
    [HideInInspector]
    public float dashCounter, dashCoolCounter;
    /*
    // Joystick
    [SerializeField]
    private Vector2 joystickSize = new Vector2(100, 100);
    [SerializeField]
    private FloatingJoystick joystick;

    private Finger movementFinger;
    private Vector2 movementAmount;
    */
    [HideInInspector]
    public bool canDash;
    [HideInInspector]
    public bool isColliding;

    public Transform itemHolder;
    public GameObject objectHolding;
    private void Awake()
    {
        instance = this;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        stats.moveSpeed = 6f;
        stats.dashSpeed = 20f;
        activeMoveSpeed = stats.moveSpeed;
        audioSource = GetComponent<AudioSource>();
        DashImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.instance.isPaused == false && LevelManager.instance.isGameOver == false)
        {
            Debug.Log("Able to move");
            Movement();
            Dash();
            Debug.Log(activeMoveSpeed);
        }
    }




    void Movement()
    {
        if (Tutorial.tutorialing || isWorking == true || LevelManager.instance.isGameOver == true)
        {
            moveInput.x = 0;
            moveInput.y = 0;
            theRB.velocity = Vector2.zero;
            
        }
        else
        {
            moveInput.x = UIController.instance.movementAmt.x; //using unity input system to get the value of x (right: 1, Left: -1)
            moveInput.y = UIController.instance.movementAmt.y; //using unity input system to get the value of y (up: 1, down: -1)

            moveInput.Normalize(); //make the player movement more consistent by noramlizing all the distance (can imagine the distance to be in a circle)

            theRB.velocity = moveInput * activeMoveSpeed; //this is to set the speed(velocity) in the rididBody2D by doing vector2 value * moveSpeed(float)
            if (theRB.velocity.x != 0 || theRB.velocity.y != 0)
            {
                if (!audioSource.isPlaying && LevelManager.instance.isPaused == false && LevelManager.instance.isGameOver == false)
                {
                    audioSource.Play();

                }
                
                if (objectHolding != null && (moveInput.x > 0 || moveInput.y > 0))
                {
                    animator.SetBool("carry and walk", true);
                    Debug.Log("workkkkkkkkkkkk");

                }
                if (moveInput.x > 0 || moveInput.y > 0)
                {
                    animator.SetBool("walking", true);
                }

            }
            else
            {
                audioSource.Stop();
                animator.SetBool("walking", false);
                animator.SetBool("is carrying", false);
                animator.SetBool("carry and walk", false);
            }

            if(moveInput.x < 0)
            {
                sr.flipX = true;
                //gameObject.transform.rotation.y + 180;
            }
            else if(moveInput.x > 0)
            {
                sr.flipX = false;
            }

            
        }
    }
    
    public void Dash()
    {
        if (canDash == true) //when player press space
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0) ///player dashing
            {
                DashImage.fillAmount = 1;
                activeMoveSpeed = stats.dashSpeed;
                dashCounter = dashLength; //declaring how long the dash speed will last
                
                if(objectHolding != null)
                {
                    animator.SetTrigger("carry and sprint");
                }
                else
                {
                    animator.SetTrigger("sprinting");
                }
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime*3; //minusing off deltaTime(sescond) from the duration of dash speed
            if (dashCounter <= 0) //when dashCounter turns to 0, the player will go back to normal speed
            {
                activeMoveSpeed = stats.moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime; //minusing off deltaTime(per second) from the duration of dashCooldown
            if(dashCoolCounter <= 0f)
            {
                canDash = false;
                dashCoolCounter = 0f;
                if (DashImage != null)
                {
                    DashImage.fillAmount = 0;
                    animator.SetBool("walking", true);
                }
            }
            else
            {
                if (DashImage != null)
                {
                    DashImage.fillAmount = dashCoolCounter / dashCooldown;

                }
            }
           
            
        }

    }
}
