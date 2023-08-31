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

    public Image pauseScreen;
    public Button interactBtn;
    public bool InteractBtnPressed;
    public Text pauseTxt;
    public Button aimBtn;
    public Image optionScreen;
    public Slider progressbar;
    public Text timerText;
    public GameObject dashButton;

    /*
    // Joystick
    [SerializeField]
    private Vector2 joystickSize = new Vector2(200, 200);
    [SerializeField]
    private FloatingJoystick joystick;
    //private Finger movementFinger;
    [HideInInspector]
    public Vector2 movementAmount;
    private Vector2 originalJoystickPos = new Vector2(Screen.width / 10f, Screen.height / 10f);
    */

    // new joystick
    private Vector2 startingPoint;
    private int leftTouch = 99;
    //public Transform circle;
    //public Transform outerCircle;
    public Vector2 direction;

    [SerializeField]
    private FloatingJoystick joystick;
    [SerializeField]
    private Vector2 joystickSize = new Vector2(300, 300);

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        //sr = gameObject.GetComponent<SpriteRenderer>();
    }
    /*
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
        joystick.rectTransform.anchoredPosition = ClampStartPosition(originalJoystickPos);
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
            //joystick.rectTransform.anchoredPosition = ClampStartPosition(Camera.main.WorldToScreenPoint(TouchedFinger.screenPosition));
        }
    }
    */
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
   

    void Start()
    {
        LevelManager.instance.isPaused = false;

    }
    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            float maxMovement = joystickSize.x / 2;
            Touch t = Input.GetTouch(i);
            Vector2 touchPos = CameraController.instance.getTouchPosition(t.position);

            if (t.phase == TouchPhase.Began)
            {
                direction = Vector2.zero;
                
                if (t.position.x > Screen.width / 2)
                {
                    
                    Debug.Log("right touch");
                }
                else
                {
                    joystick.rectTransform.position = new Vector3(t.position.x - maxMovement, t.position.y - maxMovement, 0f);
                    leftTouch = t.fingerId;
                    startingPoint = touchPos;
                }
            }
            else if (t.phase == TouchPhase.Moved && leftTouch == t.fingerId)
            {
                Vector2 knobPosition;
                

                if (Vector2.Distance(t.position, joystick.rectTransform.position) > maxMovement)
                {
                    knobPosition = new Vector2(t.position.x - maxMovement - joystick.rectTransform.position.x, t.position.y - maxMovement - joystick.rectTransform.position.y).normalized * maxMovement;
                }
                else
                {
                    knobPosition = new Vector2(t.position.x - maxMovement - joystick.rectTransform.position.x, t.position.y - maxMovement - joystick.rectTransform.position.y);
                }

                joystick.knob.anchoredPosition = knobPosition;
                direction = knobPosition / maxMovement;

                
            }
            else if (t.phase == TouchPhase.Ended && leftTouch == t.fingerId)
            {
                joystick.knob.anchoredPosition = Vector2.zero;

                direction = Vector2.zero;
                leftTouch = 99;
            }
            ++i;
        }

    }

    

    public void DashBtn()
    {
        PlayerController.instance.canDash = true;
    }

    public void InteractBtn()
    {
    }

    public void PauseBtn()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            //pauseScreen.enabled = true;
            dashButton.SetActive(false);
            //pauseTxt.text = "Unpause";
            LevelManager.instance.isPaused = true;

        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            //pauseScreen.enabled = false;
            dashButton.SetActive(true);
            //pauseTxt.text = "Pause";
            LevelManager.instance.isPaused = false;
        }
    }

    void OptionBtn()
    {

    }

    
}
