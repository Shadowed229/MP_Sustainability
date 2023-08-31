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
                whichrubbish = Random.Range(0, 1);
                GameObject spawnable = allTrash[whichrubbish]; //either spawns dirty can or dirty metal can
                Instantiate(spawnable, spawn5);

                whichrubbish = 2;
                GameObject spawnable2 = allTrash[whichrubbish]; // spawns dirty plastic bottle
                Instantiate(spawnable2, spawn2);

                whichrubbish = Random.Range(5, 7); 
                GameObject spawnable3 = allTrash[whichrubbish]; // Either chips, toothbrush or plastic bag
                Instantiate(spawnable3, spawn8);

                whichrubbish = Random.Range(3, 4);
                GameObject spawnable4 = allTrash[whichrubbish]; // spawns random glass item
                Instantiate(spawnable4, spawn1);

                whichrubbish = 9;
                GameObject spawnable5 = allTrash[whichrubbish]; // random rubbish
                Instantiate(spawnable5, spawn3);

                Debug.Log("Spawning 5 Rubbish");
            }
            if (LevelManager.instance.rubbishspawn == 6) //6 rubbish spawn
            {
                whichrubbish = Random.Range(0, 1);
                GameObject spawnable = allTrash[whichrubbish]; //either spawns dirty can or dirty metal can
                Instantiate(spawnable, spawn5);

                whichrubbish = 2;
                GameObject spawnable2 = allTrash[whichrubbish]; // spawns dirty plastic bottle
                Instantiate(spawnable2, spawn2);

                whichrubbish = Random.Range(5, 7);
                GameObject spawnable3 = allTrash[whichrubbish]; // Either chips, toothbrush or plastic bag
                Instantiate(spawnable3, spawn8);

                whichrubbish = Random.Range(3, 4);
                GameObject spawnable4 = allTrash[whichrubbish]; // spawns random glass item
                Instantiate(spawnable4, spawn1);

                whichrubbish = 9;
                GameObject spawnable5 = allTrash[whichrubbish]; // random rubbish
                Instantiate(spawnable5, spawn3);

                whichrubbish = Random.Range(0, 7);
                GameObject spawnable6 = allTrash[whichrubbish]; // random rubbish
                Instantiate(spawnable6, spawn7);

                Debug.Log("Spawning 6 Rubbish");
            }
        }
        if (sceneName == "Level2")
        {
            int whichrubbish = Random.Range(0, 7);
            //rubbishspawn = Random.Range(5, 6);
            if (LevelManager.instance.rubbishspawn == 6) //5 rubbish spawn
            {
                whichrubbish = Random.Range(0, 1);
                GameObject spawnable = allTrash[whichrubbish]; //either spawns dirty can or dirty metal can
                Instantiate(spawnable, spawn5);

                whichrubbish = 2;
                GameObject spawnable2 = allTrash[whichrubbish]; // spawns dirty plastic bottle
                Instantiate(spawnable2, spawn2);

                whichrubbish = Random.Range(5, 7);
                GameObject spawnable3 = allTrash[whichrubbish]; // Either chips, toothbrush or plastic bag
                Instantiate(spawnable3, spawn8);

                whichrubbish = Random.Range(3, 4);
                GameObject spawnable4 = allTrash[whichrubbish]; // spawns random glass item
                Instantiate(spawnable4, spawn1);

                whichrubbish = Random.Range(8, 9);
                GameObject spawnable5 = allTrash[whichrubbish]; // spawns random compost item
                Instantiate(spawnable5, spawn3);

                whichrubbish = 10;
                GameObject spawnable6 = allTrash[whichrubbish]; // spawns newspaper
                Instantiate(spawnable6, spawn4);

                Debug.Log("Spawning 6 Rubbish");
            }
            if (LevelManager.instance.rubbishspawn == 7) //6 rubbish spawn
            {
                whichrubbish = Random.Range(0, 1);
                GameObject spawnable = allTrash[whichrubbish]; //either spawns dirty can or dirty metal can
                Instantiate(spawnable, spawn5);

                whichrubbish = 2;
                GameObject spawnable2 = allTrash[whichrubbish]; // spawns dirty plastic bottle
                Instantiate(spawnable2, spawn2);

                whichrubbish = Random.Range(5, 7);
                GameObject spawnable3 = allTrash[whichrubbish]; // Either chips, toothbrush or plastic bag
                Instantiate(spawnable3, spawn8);

                whichrubbish = Random.Range(3, 4);
                GameObject spawnable4 = allTrash[whichrubbish]; // spawns random glass item
                Instantiate(spawnable4, spawn1);

                whichrubbish = Random.Range(8, 9);
                GameObject spawnable5 = allTrash[whichrubbish]; // spawns random compost item
                Instantiate(spawnable5, spawn3);

                whichrubbish = 10;
                GameObject spawnable6 = allTrash[whichrubbish]; // spawns newspaper
                Instantiate(spawnable6, spawn4);

                whichrubbish = Random.Range(0, 9);
                GameObject spawnable7 = allTrash[whichrubbish]; // random rubbish
                Instantiate(spawnable7, spawn7);

                Debug.Log("Spawning 7 Rubbish");
            }
        }
        if (sceneName == "Level3")
        {
            int whichrubbish = Random.Range(0, 7);
            //rubbishspawn = Random.Range(5, 6);
            if (LevelManager.instance.rubbishspawn == 6) //5 rubbish spawn
            {
                whichrubbish = Random.Range(0, 8);
                GameObject spawnable = allTrash[whichrubbish]; // spawns random item 
                Instantiate(spawnable, spawn5);

                whichrubbish = Random.Range(0, 8);
                GameObject spawnable2 = allTrash[whichrubbish]; // spawns random item 
                Instantiate(spawnable2, spawn2);

                whichrubbish = Random.Range(0, 8);
                GameObject spawnable3 = allTrash[whichrubbish]; // spawns random item 
                Instantiate(spawnable3, spawn8);

                whichrubbish = Random.Range(0, 8);
                GameObject spawnable4 = allTrash[whichrubbish]; // spawns random item 
                Instantiate(spawnable4, spawn1);

                whichrubbish = Random.Range(9, 10);
                GameObject spawnable5 = allTrash[whichrubbish]; // spawns random NR item
                Instantiate(spawnable5, spawn3);

                whichrubbish = Random.Range(11,12);
                GameObject spawnable6 = allTrash[whichrubbish]; // spawns random R item
                Instantiate(spawnable6, spawn4);

                Debug.Log("Spawning 6 Rubbish");
            }
            if (LevelManager.instance.rubbishspawn == 7) //6 rubbish spawn
            {
                whichrubbish = Random.Range(0, 8);
                GameObject spawnable = allTrash[whichrubbish]; // spawns random item 
                Instantiate(spawnable, spawn5);

                whichrubbish = Random.Range(0, 8);
                GameObject spawnable2 = allTrash[whichrubbish]; // spawns random item 
                Instantiate(spawnable2, spawn2);

                whichrubbish = Random.Range(0, 8);
                GameObject spawnable3 = allTrash[whichrubbish]; // spawns random item 
                Instantiate(spawnable3, spawn8);

                whichrubbish = Random.Range(0, 8);
                GameObject spawnable4 = allTrash[whichrubbish]; // spawns random item 
                Instantiate(spawnable4, spawn1);

                whichrubbish = Random.Range(9, 10);
                GameObject spawnable5 = allTrash[whichrubbish]; // spawns random NR item
                Instantiate(spawnable5, spawn3);

                whichrubbish = Random.Range(11, 12);
                GameObject spawnable6 = allTrash[whichrubbish]; // spawns random R item
                Instantiate(spawnable6, spawn4);

                whichrubbish = Random.Range(0, 8);
                GameObject spawnable7 = allTrash[whichrubbish]; // random rubbish
                Instantiate(spawnable7, spawn7);

                Debug.Log("Spawning 7 Rubbish");
            }
        }
    }
}
