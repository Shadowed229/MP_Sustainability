using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance; 

    public Image pauseScreen;
    public Button interactBtn;
    public Text pauseTxt;
    public Button aimBtn;
    public Image optionScreen;
    public Slider progressbar;
    public Text timerText;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    public void DashBtn()
    {
        PlayerController.instance.canDash = true;
    }

    public void PauseBtn()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            pauseScreen.enabled = true;
            pauseTxt.text = "Unpause";
            LevelManager.instance.isPaused = true;
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseScreen.enabled = false;
            pauseTxt.text = "Pause";
            LevelManager.instance.isPaused = false;
        }
    }

    void OptionBtn()
    {

    }
}
