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
        Scene currentScene = SceneManager.GetActiveScene(); //checks which scene that player is on
        sceneName = currentScene.name;
        float distancebetweenPlayer = Vector3.Distance(transform.position, player.transform.position); //checks distance between workstation and player
        if(distancebetweenPlayer < 5) // if player is between 5f away from the workstation, is close = true
        {
            isClose = true;
        }
        else
        {
            isClose = false;
        }

        if (PickUp.instance.holding == true && occupied == false  && isClose == true) //checks whether player is holding anything, if the table has objects, and if the player is close
        {
            Debug.Log("Close to Workstation!"); 
            if ((InteractButton.instance.buttonPressed == true || Input.GetButtonDown("Pickup")) && PlayerController.instance.objectHolding.tag == "Trash") //checks for button press and if the player is holding a trash bag.
            {
                InteractButton.instance.buttonPressed = false; //sets the button press to false
                Destroy(PlayerController.instance.objectHolding); //deletes the trash bag
                PickUp.instance.holding = false; //sets the holding value to false as player put bag on workstation
                StartCoroutine(UpdateProgressBar());
                
            }
        }

        if(placeholder.childCount == 0 && placeholder2.childCount == 0 && placeholder3.childCount == 0)
        {
            occupied = false; //checks if the workstation is occupied by checking the placeholders
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
        progress.gameObject.SetActive(true); //sets the progress bar on the workstation to show

        float score = 0f; //sets the score of progress bar
        while (score < 3f)
        {
            yield return new WaitForSeconds(1f); //waits 1 second to add 1 score
            score += 1;
            Debug.Log(score);
            progress.value = score; //progress.value is the progress on the progress bar
        }
        if(score == 3f)
        {
            StartCoroutine(WorkstationSpawn()); // when score reaches 3 which is 3 seconds rubbish will spawn
        }
           
    }
    IEnumerator WorkstationSpawn() ////Has a chance to spawn 1-3 items in the workbench, the it will randomly spawn different types of trash in the placeholders.
                                   ////It also checks the scene it is in so it spawns the appropriate trash for each level.
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

        progress.gameObject.SetActive(false); //sets the progress to false to hide it
        PlayerController.instance.isWorking = false; //sets the value of isworking to false
        progress.value = progress.minValue; //resets the progress bar for next trash bag
        yield break;
    }

}
