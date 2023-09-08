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

    public Button interactBtn;
    public bool InteractBtnPressed;
    public Slider progressbar;
    public Text timerText;
    public GameObject dashButton;

    // new joystick
    private Vector2 startingPoint;
    private int leftTouch = 99;
    public Vector2 movementAmt;

    [SerializeField]
    private FloatingJoystick joystick;
    [SerializeField]
    private Vector2 joystickSize = new Vector2(300, 300);
    private Vector2 joystickPos;

    // Start is called before the first frame update
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

        int i = 0;
        while (i < Input.touchCount)
        {
            float maxMovement = joystickSize.x / 2;
            Touch t = Input.GetTouch(i);

            joystickPos = new Vector2(joystick.rectTransform.anchoredPosition.x + maxMovement, joystick.rectTransform.anchoredPosition.y + maxMovement);

            if (t.phase == TouchPhase.Began)
            {
                movementAmt = Vector2.zero;
                
                if (t.position.x > Screen.width / 3)
                {
                    
                    Debug.Log("right touch");
                }
                else
                {
                   
                    leftTouch = t.fingerId;
                }
            }
            else if (t.phase == TouchPhase.Moved && leftTouch == t.fingerId)
            {
                Vector2 knobPosition;

                
                if (Vector2.Distance(t.position, joystickPos) > maxMovement)
                {
                    knobPosition = (t.position - joystickPos).normalized * maxMovement;
                }
                else
                {
                    knobPosition = t.position - joystickPos;
                }

                Debug.Log(Vector2.Distance(t.position, joystickPos));
                joystick.knob.anchoredPosition = knobPosition;
                movementAmt = knobPosition / maxMovement;

                
            }
            else if (t.phase == TouchPhase.Ended && leftTouch == t.fingerId)
            {
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
