using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public bool isPaused;
    public bool isGameOver;
    public float score;
    public int rubbishspawn;
    
    
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rubbishspawn = Random.Range(5, 6);
        score = 0;
        UIController.instance.progressbar.maxValue = rubbishspawn;
    }

    // Update is called once per frame
    void Update()
    {
        UIController.instance.progressbar.value = score;
        if (score >= rubbishspawn)
        {
            GameObject.FindWithTag("WinMenu").SetActive(true);
            Debug.Log("YOU WIN!");
            isGameOver = true;
        }
    }
}
