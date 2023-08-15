using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorkStation : MonoBehaviour
{
    
    private GameObject trash;
    public Slider progress;
    public GameObject[] allTrash;

    public Transform placeholder;
    public Transform placeholder2;
    public Transform placeholder3;
    public static bool occupied;
    public static bool Rubbish1;
    public static bool Rubbish2;
    public static bool Rubbish3;
    public GameObject player;
    private float fillTime;
    public string sceneName;

    public static bool isClose;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Rubbish1 = false;
        Rubbish2 = false;
        Rubbish3 = false;
        occupied = false;
        //progress = (Slider)FindObjectOfType(typeof(Slider));
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        float distancebetweenPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distancebetweenPlayer < 5)
        {
            isClose = true;
        }
        else
        {
            isClose = false;
        }

        if (PickUp.instance.holding == true && occupied == false  && isClose == true)
        {
            Debug.Log("Close to Workstation!"); 
            if ((InteractButton.instance.buttonPressed == true || Input.GetButtonDown("Pickup")) && PlayerController.instance.objectHolding.tag == "Trash")
            {
                InteractButton.instance.buttonPressed = false;
                Destroy(PlayerController.instance.objectHolding);
                PickUp.instance.holding = false;
                StartCoroutine(UpdateProgressBar());
                
            }
        }

        if(placeholder.childCount == 0 && placeholder2.childCount == 0 && placeholder3.childCount == 0)
        {
            occupied = false;
        }
        else
        {
            occupied = true;
        }
    }
    
    IEnumerator UpdateProgressBar()
    {
        Debug.Log("Updating");
        PlayerController.instance.isWorking = true;
        progress.gameObject.SetActive(true);

        float score = 0f;
        while (score < 3f)
        {
            yield return new WaitForSeconds(1f);
            score += 1;
            Debug.Log(score);
            progress.value = score;
        }
        if(score == 3f)
        {
            StartCoroutine(WorkstationSpawn());
        }
           
    }
    IEnumerator WorkstationSpawn()
    {
        if (sceneName == "Level1")
        {
            int whichrubbish = Random.Range(0, 7);
            int rubbishspawn = Random.Range(0, 3);
            if (rubbishspawn == 0) //1 rubbish spawn
            {
                whichrubbish = Random.Range(0, 2);
                GameObject spawnable = allTrash[whichrubbish];
                Instantiate(spawnable, placeholder);
                whichrubbish = Random.Range(0, 2);
                Rubbish1 = true;
            }
            else if (rubbishspawn == 1) //2 rubbish spawn
            {
                whichrubbish = Random.Range(0, 2);
                GameObject spawnable = allTrash[whichrubbish];
                Instantiate(spawnable, placeholder);
                whichrubbish = Random.Range(0, 7);
                GameObject spawnable2 = allTrash[whichrubbish];
                Instantiate(spawnable2, placeholder2);
                Rubbish2 = true;
            }
            else if (rubbishspawn == 2) //3 rubbish spawn
            {
                whichrubbish = Random.Range(0, 2);
                GameObject spawnable = allTrash[whichrubbish];
                Instantiate(spawnable, placeholder);
                whichrubbish = Random.Range(0, 7);
                GameObject spawnable2 = allTrash[whichrubbish];
                Instantiate(spawnable2, placeholder2);
                whichrubbish = Random.Range(0, 7);
                GameObject spawnable3 = allTrash[whichrubbish];
                Instantiate(spawnable3, placeholder3);
                Rubbish3 = true;
            }
        }
        if (sceneName == "Level2")
        {
            int whichrubbish = Random.Range(0, 7);
            int rubbishspawn = Random.Range(0, 3);
            if (rubbishspawn == 0) //1 rubbish spawn
            {
                whichrubbish = Random.Range(0, 2);
                GameObject spawnable = allTrash[whichrubbish];
                Instantiate(spawnable, placeholder);
                whichrubbish = Random.Range(0, 2);
                Rubbish1 = true;
            }
            else if (rubbishspawn == 1) //2 rubbish spawn
            {
                whichrubbish = Random.Range(0, 2);
                GameObject spawnable = allTrash[whichrubbish];
                Instantiate(spawnable, placeholder);
                whichrubbish = Random.Range(0, 7);
                GameObject spawnable2 = allTrash[whichrubbish];
                Instantiate(spawnable2, placeholder2);
                Rubbish2 = true;
            }
            else if (rubbishspawn == 2) //3 rubbish spawn
            {
                whichrubbish = Random.Range(0, 2);
                GameObject spawnable = allTrash[whichrubbish];
                Instantiate(spawnable, placeholder);
                whichrubbish = Random.Range(0, 7);
                GameObject spawnable2 = allTrash[whichrubbish];
                Instantiate(spawnable2, placeholder2);
                whichrubbish = Random.Range(0, 7);
                GameObject spawnable3 = allTrash[whichrubbish];
                Instantiate(spawnable3, placeholder3);
                Rubbish3 = true;
            }
        }

        progress.gameObject.SetActive(false);
        PlayerController.instance.isWorking = false;
        progress.value = progress.minValue;
        yield break;
    }

}
