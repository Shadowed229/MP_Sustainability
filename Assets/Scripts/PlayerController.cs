using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;
using System;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Rigidbody2D theRB; // rigid body component attached in player
    private Vector2 moveInput; // to get vecotr2 value of the player object
    AudioSource audioSource;
    float x;


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
    // Joystick
    [SerializeField]
    private Vector2 joystickSize = new Vector2(100, 100);
    [SerializeField]
    private FloatingJoystick joystick;

    private Finger movementFinger;
    private Vector2 movementAmount;

    [HideInInspector]
    public bool canDash;

    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += Touch_onFingerDown;
        ETouch.Touch.onFingerUp += HandleLoseFinger;
        ETouch.Touch.onFingerMove += Touch_onFingerMove;
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= Touch_onFingerDown;
        ETouch.Touch.onFingerUp -= HandleLoseFinger;
        ETouch.Touch.onFingerMove -= Touch_onFingerMove;
        EnhancedTouchSupport.Disable();
    }

    private void Touch_onFingerMove(Finger MovedFinger)
    {
        if (MovedFinger == movementFinger)
        {
            Vector2 knobPosition;
            float maxMovement = joystickSize.x / 2;
            ETouch.Touch currentTouch = MovedFinger.currentTouch;

            if (Vector2.Distance(currentTouch.screenPosition, joystick.rectTransform.anchoredPosition) > maxMovement)
            {
                knobPosition = (currentTouch.screenPosition - joystick.rectTransform.anchoredPosition).normalized * maxMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition - joystick.rectTransform.anchoredPosition;
            }

            joystick.knob.anchoredPosition = knobPosition;
            movementAmount = knobPosition / maxMovement;
        }
    }

    private void HandleLoseFinger(Finger LostFinger)
    {
        movementFinger = null;
        joystick.knob.anchoredPosition = Vector2.zero;
        joystick.gameObject.SetActive(false);
        movementAmount = Vector2.zero;
    }

    private void Touch_onFingerDown(Finger TouchedFinger)
    {
        if (movementFinger == null && TouchedFinger.screenPosition.x <= Screen.width / 2f)
        {
            movementFinger = TouchedFinger;
            movementAmount = Vector2.zero;
            if (LevelManager.instance.isPaused == false)
            {
                joystick.gameObject.SetActive(true);
            }

            joystick.rectTransform.sizeDelta = joystickSize;
            joystick.rectTransform.anchoredPosition = ClampStartPosition(TouchedFinger.screenPosition);
        }
    }

    private Vector2 ClampStartPosition(Vector2 startPosition)
    {
        if (startPosition.x < joystickSize.x / 2)
        {
            startPosition.x = joystickSize.x / 2;
        }

        if (startPosition.y < joystickSize.y / 2)
        {
            startPosition.y = joystickSize.y / 2;
        }
        else if (startPosition.y > Screen.height - joystickSize.y / 2)
        {
            startPosition.y = Screen.height - joystickSize.y / 2;
        }

        return startPosition;

    }
    // Start is called before the first frame update
    void Start()
    {
        stats.moveSpeed = 6f;
        stats.dashSpeed = 20f;
        activeMoveSpeed = stats.moveSpeed;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.instance.isPaused == false)
        {
            Movement();
            Dash();
            Debug.Log(activeMoveSpeed);
        }
    }

   


    void Movement()
    {
        moveInput.x = movementAmount.x; //using unity input system to get the value of x (right: 1, Left: -1)
        moveInput.y = movementAmount.y; //using unity input system to get the value of y (up: 1, down: -1)

        moveInput.Normalize(); //make the player movement more consistent by noramlizing all the distance (can imagine the distance to be in a circle)

        theRB.velocity = moveInput * activeMoveSpeed; //this is to set the speed(velocity) in the rididBody2D by doing vector2 value * moveSpeed(float)
        if (theRB.velocity.x != 0 || theRB.velocity.y != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();

            }
        }
        else
        {
            audioSource.Stop();
        }
        
    }
    
    public void Dash()
    {
        if (canDash == true) //when player press space
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0) ///player dashing
            {
                activeMoveSpeed = stats.dashSpeed;
                dashCounter = dashLength; //declaring how long the dash speed will last
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
            canDash = false;
        }

    }
}
