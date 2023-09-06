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
        if(Tutorial.tutorialing == false && LevelManager.instance.isGameOver == false)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                loseMenu.SetActive(true);
                Debug.Log("GAME OVER!!!");
                LevelManager.instance.pauseBtn.SetActive(false);
                LevelManager.instance.isGameOver = true;

            }
        }
       
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
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
