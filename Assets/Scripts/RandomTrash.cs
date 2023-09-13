using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomTrash : MonoBehaviour
{
    public static RandomTrash instance;
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
        instance = this;
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }
    void Start()
    {
        meow = 0;
    }

    public bool isGeneralWaste()
    {
        if (PlayerController.instance.objectHolding.tag == "GeneralWaste")
        {


            return true;


        }
        else
        {
            return false;
        }
    }
    public bool isCompost()
    {
        if (PlayerController.instance.objectHolding.tag == "Compostable")
        {
            //animator.SetBool("CompostOpen", true);
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool isRecyclable()
    {

        if (PlayerController.instance.objectHolding.tag == "Glass")
        {

            return true;
        }
        else if (PlayerController.instance.objectHolding.tag == "Plastic")
        {

            return true;
        }
        else if (PlayerController.instance.objectHolding.tag == "Metal")
        {

            return true;
        }
        else if (PlayerController.instance.objectHolding.tag == "Paper")
        {

            return true;
        }
        else
        {
            return false;
        }
    }
    public bool isNotWashed()
    {
        if (PlayerController.instance.objectHolding.tag == "ContaminatedPlastic")
        {
            return true;
        }
        else if (PlayerController.instance.objectHolding.tag == "ContaminatedMetal")
        {
            return true;
        }
        else if (PlayerController.instance.objectHolding.tag == "ContaminatedGlass")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool isNonRegulated()
    {
        if (PlayerController.instance.objectHolding.tag == "NonRegulated")
        {

            return true;

        }
        else
        {
            return false;
        }
    }
    public bool isRegulated()
    {
        if (PlayerController.instance.objectHolding.tag == "Regulated")
        {
            return true;
        }
        else
        {
            return false;
        }
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

                whichrubbish = Random.Range(5, 6); 
                GameObject spawnable3 = allTrash[whichrubbish]; // Either chips, toothbrush 
                Instantiate(spawnable3, spawn8);

                whichrubbish = Random.Range(3, 4);
                GameObject spawnable4 = allTrash[whichrubbish]; // spawns random glass item
                Instantiate(spawnable4, spawn1);

                whichrubbish = 8;
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

                whichrubbish = Random.Range(5, 6);
                GameObject spawnable3 = allTrash[whichrubbish]; // Either chips, toothbrush or plastic bag
                Instantiate(spawnable3, spawn8);

                whichrubbish = Random.Range(3, 4);
                GameObject spawnable4 = allTrash[whichrubbish]; // spawns random glass item
                Instantiate(spawnable4, spawn1);

                whichrubbish = 8;
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

                whichrubbish = Random.Range(5, 6);
                GameObject spawnable3 = allTrash[whichrubbish]; // Either chips, toothbrush or plastic bag
                Instantiate(spawnable3, spawn8);

                whichrubbish = Random.Range(3, 4);
                GameObject spawnable4 = allTrash[whichrubbish]; // spawns random glass item
                Instantiate(spawnable4, spawn1);

                whichrubbish = Random.Range(7, 8);
                GameObject spawnable5 = allTrash[whichrubbish]; // spawns random compost item
                Instantiate(spawnable5, spawn3);

                whichrubbish = 9;
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

                whichrubbish = Random.Range(5, 6);
                GameObject spawnable3 = allTrash[whichrubbish]; // Either chips, toothbrush or plastic bag
                Instantiate(spawnable3, spawn8);

                whichrubbish = Random.Range(3, 4);
                GameObject spawnable4 = allTrash[whichrubbish]; // spawns random glass item
                Instantiate(spawnable4, spawn1);

                whichrubbish = Random.Range(7, 8);
                GameObject spawnable5 = allTrash[whichrubbish]; // spawns random compost item
                Instantiate(spawnable5, spawn3);

                whichrubbish = 9;
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
                whichrubbish = Random.Range(0, 7);
                GameObject spawnable = allTrash[whichrubbish]; // spawns random item 
                Instantiate(spawnable, spawn5);

                whichrubbish = Random.Range(0, 7);
                GameObject spawnable2 = allTrash[whichrubbish]; // spawns random item 
                Instantiate(spawnable2, spawn2);

                whichrubbish = Random.Range(0, 7);
                GameObject spawnable3 = allTrash[whichrubbish]; // spawns random item 
                Instantiate(spawnable3, spawn8);

                whichrubbish = Random.Range(0, 7);
                GameObject spawnable4 = allTrash[whichrubbish]; // spawns random item 
                Instantiate(spawnable4, spawn1);

                whichrubbish = Random.Range(8,9);
                GameObject spawnable5 = allTrash[whichrubbish]; // spawns random NR item
                Instantiate(spawnable5, spawn3);

                whichrubbish = Random.Range(10, 11);
                GameObject spawnable6 = allTrash[whichrubbish]; // spawns random R item
                Instantiate(spawnable6, spawn4);

                Debug.Log("Spawning 6 Rubbish");
            }
            if (LevelManager.instance.rubbishspawn == 7) //6 rubbish spawn
            {
                whichrubbish = Random.Range(0, 7);
                GameObject spawnable = allTrash[whichrubbish]; // spawns random item 
                Instantiate(spawnable, spawn5);

                whichrubbish = Random.Range(0, 7);
                GameObject spawnable2 = allTrash[whichrubbish]; // spawns random item 
                Instantiate(spawnable2, spawn2);

                whichrubbish = Random.Range(0, 7);
                GameObject spawnable3 = allTrash[whichrubbish]; // spawns random item 
                Instantiate(spawnable3, spawn8);

                whichrubbish = Random.Range(0, 7);
                GameObject spawnable4 = allTrash[whichrubbish]; // spawns random item 
                Instantiate(spawnable4, spawn1);

                whichrubbish = Random.Range(8, 9);
                GameObject spawnable5 = allTrash[whichrubbish]; // spawns random NR item
                Instantiate(spawnable5, spawn3);

                whichrubbish = Random.Range(10, 11);
                GameObject spawnable6 = allTrash[whichrubbish]; // spawns random R item
                Instantiate(spawnable6, spawn4);

                whichrubbish = Random.Range(0, 7);
                GameObject spawnable7 = allTrash[whichrubbish]; // random rubbish
                Instantiate(spawnable7, spawn7);

                Debug.Log("Spawning 7 Rubbish");
            }
        }
    }
}
