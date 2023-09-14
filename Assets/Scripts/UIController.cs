using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    // var to store all the assets corresponding to the description
    public Button interactBtn;
    public bool InteractBtnPressed;
    public Slider progressbar;
    public Text timerText;
    public GameObject dashButton;

    // new joystick
    private Vector2 startingPoint;
    private int leftTouch = 99; //int value to differentiate the lefttouch and right touch
    public Vector2 movementAmt;

    [SerializeField]
    private FloatingJoystick joystick; //var to assign the floating joytick inside the hierarchy 
    [SerializeField]
    private Vector2 joystickSize = new Vector2(300, 300); //setting the size of the joystick 
    private Vector2 joystickPos; //Vector2 value for joystick 


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        LevelManager.instance.isPaused = false;

    }
    void Update()
    {
        //using while loop to keep track of the touched made 
        int i = 0;
        while (i < Input.touchCount)
        {
            //setting the maxmovement of the joystick knob so that the knob don’t extrude the joystick radius
            float maxMovement = joystickSize.x / 2;
            Touch t = Input.GetTouch(i);
            //setting the initial anchored position of the joystick (we are plussing the maxMovement as when we set the recttransform, it will use the bottom left corner as the ref
            joystickPos = new Vector2(joystick.rectTransform.anchoredPosition.x + maxMovement, joystick.rectTransform.anchoredPosition.y + maxMovement);
            //when the player touched the screen,
            if (t.phase == TouchPhase.Began)
            {
                //set the movement amount of the joystic knob to 0 first
                movementAmt = Vector2.zero;
                //player will only be able to move the joystick if they touch the 1/3 side of the screen
                if (t.position.x > Screen.width / 3)
                {

                    Debug.Log("right touch");
                }
                else
                {

                    leftTouch = t.fingerId;
                }
            }
            //when the player move their finger while touching the screen…
            else if (t.phase == TouchPhase.Moved && leftTouch == t.fingerId)
            {
                //setting the empty vector2 value to store the position of the joystick knob
                Vector2 knobPosition;

                //this is to ensure that the joystick knob don’t extrude. If the player finger pos is outside of the max distance from the joystick, it will normalise the distance and multiply the maxmovement so that the knob will never extrude joystick
                if (Vector2.Distance(t.position, joystickPos) > maxMovement)
                {
                    knobPosition = (t.position - joystickPos).normalized * maxMovement;
                }
                else
                {
                    knobPosition = t.position - joystickPos;
                }
                //update the anchored position of the anchored position as the player continues to move their finger to control the joystick
                //Debug.Log(Vector2.Distance(t.position, joystickPos));
                joystick.knob.anchoredPosition = knobPosition;
                movementAmt = knobPosition / maxMovement;


            }
            //when the player lift their fingers up from the screen…
            else if (t.phase == TouchPhase.Ended && leftTouch == t.fingerId)
            {
                //reset back the anchored position of the knob to return to its original position and set the movement amount back to 0
                joystick.knob.anchoredPosition = Vector2.zero;

                movementAmt = Vector2.zero;
                leftTouch = 99;
            }
            ++i;
        }
    }

    public void DashBtn()
    {
        PlayerController.instance.canDash = true;
    }

    public void PauseBtn()
    {
        //use timescale to stop time from moving in unity to simulate pause
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            //pauseScreen.enabled = true;
            dashButton.SetActive(false);
            //pauseTxt.text = "Unpause";
            LevelManager.instance.isPaused = true;

        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            //pauseScreen.enabled = false;
            dashButton.SetActive(true);
            //pauseTxt.text = "Pause";
            LevelManager.instance.isPaused = false;
        }
    }

}
