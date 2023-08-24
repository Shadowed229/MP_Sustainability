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
    public Camera mainCamera;
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
    public Transform circle;
    public Transform outerCircle;
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
    */

    void Start()
    {
        LevelManager.instance.isPaused = false;

    }
    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            Vector2 touchPos = getTouchPosition(t.position) * -1;
            if(t.phase == TouchPhase.Began)
            {
                if(t.position.x > Screen.width / 2)
                {

                }
                else
                {
                    leftTouch = t.fingerId;
                    startingPoint = touchPos;
                }
            }
            else if(t.phase == TouchPhase.Moved && leftTouch == t.fingerId)
            {
                Vector2 offset = touchPos - startingPoint;
                Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

                PlayerController.instance.moveInput = direction;

                circle.transform.position = new Vector2(outerCircle.transform.position.x + direction.x, outerCircle.transform.position.y + direction.y);
            }
            else if(t.phase == TouchPhase.Ended && leftTouch == t.fingerId)
            {
                leftTouch = 99;
            }
        }

    }

    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, mainCamera.gameObject.transform.position.z));
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
