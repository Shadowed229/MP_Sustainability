using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomTrash : MonoBehaviour
{
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public Transform spawn5;
    public Transform spawn6;
    public Transform spawn7;
    public Transform spawn8;
    public string sceneName;
    private int meow;
    public GameObject[] allTrash;
    // Start is called before the first frame update
    private void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }
    void Start()
    {
        meow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if(meow == 0)
        {
            spawnTrash();
            meow += 1;
        }
    }
    
    public void spawnTrash()
    {
        if (sceneName == "Level1")
        {
            int whichrubbish = Random.Range(0, 7);
            //rubbishspawn = Random.Range(5, 6);
            if (LevelManager.instance.rubbishspawn == 5) //5 rubbish spawn
            {
                whichrubbish = Random.Range(0, 2);
                GameObject spawnable = allTrash[whichrubbish];
                Instantiate(spawnable, spawn5);
                whichrubbish = Random.Range(0, 2);
                GameObject spawnable2 = allTrash[whichrubbish];
                Instantiate(spawnable2, spawn2);
                whichrubbish = Random.Range(0, 7);
                GameObject spawnable3 = allTrash[whichrubbish];
                Instantiate(spawnable3, spawn8);
                whichrubbish = Random.Range(0, 7);
                GameObject spawnable4 = allTrash[whichrubbish];
                Instantiate(spawnable4, spawn1);
                whichrubbish = Random.Range(0, 7);
                GameObject spawnable5 = allTrash[whichrubbish];
                Instantiate(spawnable5, spawn3);
                Debug.Log("Spawning 5 Rubbish");
            }
            if (LevelManager.instance.rubbishspawn == 6) //6 rubbish spawn
            {
                whichrubbish = Random.Range(0, 2);
                GameObject spawnable = allTrash[whichrubbish];
                Instantiate(spawnable, spawn5);
                whichrubbish = Random.Range(0, 2);
                GameObject spawnable2 = allTrash[whichrubbish];
                Instantiate(spawnable2, spawn2);
                whichrubbish = Random.Range(0, 7);
                GameObject spawnable3 = allTrash[whichrubbish];
                Instantiate(spawnable3, spawn8);
                whichrubbish = Random.Range(0, 7);
                GameObject spawnable4 = allTrash[whichrubbish];
                Instantiate(spawnable4, spawn1);
                whichrubbish = Random.Range(0, 7);
                GameObject spawnable5 = allTrash[whichrubbish];
                Instantiate(spawnable5, spawn3);
                whichrubbish = Random.Range(0, 7);
                GameObject spawnable6 = allTrash[whichrubbish];
                Instantiate(spawnable6, spawn2);
                Debug.Log("Spawning 6 Rubbish");
            }
        }
    }
}
