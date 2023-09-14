using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    public Text timeText;
    public GameObject loseMenu;

    // Update is called once per frame
    void Update()
    {
        if(Tutorial.tutorialing == false && LevelManager.instance.isGameOver == false) //checks if the time should continue counting down
        {
            if (timeValue > 0) //if the time value is more then 0
            {
                timeValue -= Time.deltaTime; //minus the time
            }
            else
            {
                loseMenu.SetActive(true); //once time value is less then 0, lose menu is activated
                Debug.Log("GAME OVER!!!");
                LevelManager.instance.pauseBtn.SetActive(false); //hides the pause button
                LevelManager.instance.isGameOver = true; //sets the isGameOver to true

            }
        }
       
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay) //displays the time in the timer in the scene
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
