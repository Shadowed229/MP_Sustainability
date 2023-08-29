using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public bool isPaused;
    public bool isGameOver;
    public float score;
    public int rubbishspawn;
    public GameObject winMenu;
    public string sceneName;

    private void Awake()
    {
        instance = this;
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(sceneName == "Level1")
        {
            rubbishspawn = Random.Range(5, 6);
        }
        else if(sceneName == "Level2")
        {
            rubbishspawn = Random.Range(6, 7);
        }

        score = 0;
        UIController.instance.progressbar.maxValue = rubbishspawn;
    }

    // Update is called once per frame
    void Update()
    {
        UIController.instance.progressbar.value = score;
        if (score >= rubbishspawn)
        {
            winMenu.SetActive(true);
            Debug.Log("YOU WIN!");
            isGameOver = true;
        }
    }
}
