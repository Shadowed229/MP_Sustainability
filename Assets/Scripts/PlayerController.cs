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
    AudioSource audioSource; //Var to store the audio source for the player
    public bool isWorking; //bool variable to check if the player is interacting with the washing basin. While interacting with washing basin, we will use this variable to stop the player from moving while “washing” the rubbish
    public Image DashImage; //image variable to store the image of dashbutton. This will then be used to visualise the cool down of the dash 
    public SpriteRenderer spriteRenderer; //spriterenderer component
    public Animator animator; //animator component for player 


    [Serializable]
    public struct PlayerStats //categorised some of the variable together to organise 
    {
        public float moveSpeed;
        public float dashSpeed;
    }
    [SerializeField]
    private PlayerStats stats; // this is here so that the script can access to the variable inside PlayerStats

    private float activeMoveSpeed; //float var to store the current value of the player speed at the moment

    [HideInInspector]
    public float dashLength = 0.5f, dashCooldown = 1f; //variable used for dash function. Dashlength is the duration of the player in dash mode and dashcooldown is the amount of time the player need to wait before activatinf dash function 
    [HideInInspector]
    public float dashCounter, dashCoolCounter; //empty float var that will later used to store the value of the dashlength and dashcooldown we created another empty variable so that we don’t directly edit the value in dashlength and dashcooldown

    [HideInInspector]
    public bool canDash; //bool variable to check if the player is able to dash at the moment after the cooldown has run down
    [HideInInspector]
    public bool isColliding; //bool var to check if the player is colliding

    public Transform itemHolder; //transform var to store the position of where the player will be holding the item when carrying the rubbish
    public GameObject objectHolding; //gameobject var to store the information of what kind of gameobject the player is holding at the moment

    private void Awake()
    {
        //making sure theres only one playercontroller present at a time
        instance = this;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        stats.moveSpeed = 6f; //initial movespeed of the player to be 6f (normal walking speed)
        stats.dashSpeed = 20f; //speed of the player when the player is dashing
        activeMoveSpeed = stats.moveSpeed; //declaring that the activeMoveSpeed at the moment to be walking speed (6f)
        audioSource = GetComponent<AudioSource>();
        DashImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //allow the player to move only when the game is not paused and the game hasn’t end. We are doing it so by referring back to the var in level manager
        if (LevelManager.instance.isPaused == false && LevelManager.instance.isGameOver == false)
        {
            Debug.Log("Able to move");
            Movement();
            Dash();
            Debug.Log(activeMoveSpeed); //debug log to keep track of the movespeed of the player throughout the game for debugging purposes
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
            moveInput.x = UIController.instance.movementAmt.x; //ref from the x and y value from UIController script which has direct reference to the player joystick
            moveInput.y = UIController.instance.movementAmt.y;

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

            if (moveInput.x < 0)
            {
                sr.flipX = true;
                //gameObject.transform.rotation.y + 180;
            }
            else if (moveInput.x > 0)
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
