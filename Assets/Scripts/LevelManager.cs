using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public bool isPaused;
    public bool isGameOver;
    public float score;
    
    
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UIController.instance.progressbar.maxValue = 3;
    }

    // Update is called once per frame
    void Update()
    {
        UIController.instance.progressbar.value = score;
        if (score >= 3)
        {
            Debug.Log("YOU WIN!");
            isGameOver = true;
        }
    }
}
