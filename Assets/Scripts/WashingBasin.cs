using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using JetBrains.Annotations;

public class WashingBasin : MonoBehaviour
{
    
    public Slider progress;
    public GameObject[] contaminatedGlass; //arraylist to store all the contaminated glass objects
    public GameObject[] cleanGlass; //arraylist to store all the clean glass objects
    public GameObject[] contaminatedPlastic; //arraylist to store all the contaminated plastic objects
    public GameObject[] cleanPlastic; //arraylist to store all the clean plastic objects
    public GameObject[] contaminatedMetal; //arraylist to store all the contaminated metal objects
    public GameObject[] cleanMetal; //arraylist to store all the clean metal objects
    public Transform Wash;
    public GameObject washCurrent;
    public AudioSource audioSource;
    public static bool isClose;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //find the distance between the player and the washing basin and player can only interact with the washing basin within certain distance
        //and while holding either contaminated glass, plastic, metal rubbish 
        DistanceFromPlayer();

        if(isClose && PickUp.instance.holding == true && PlayerController.instance.objectHolding != null)
        {
            WashingWaste();
           
        }
        else
        {
            //Debug.Log("invalid action"); //maybe can do some prompt to show the action that they are doing is not possible
           
        }
    }

    void DistanceFromPlayer()
    {
        float distancebetweenPlayer = Vector3.Distance(transform.position, PlayerController.instance.transform.position);
        if (distancebetweenPlayer < 3.5)
        {
            isClose = true;
        }
        else
        {
            isClose = false;
        }
    }
    //The washing basin checks what the player is holding and If the item is washable it will allow the player to put it into the washing basin to wash,
    //once the player interacts with the basin it will put the item into basin wash the item and put it back into the players hands.

    void WashingWaste() //checks if interact button is pressed and if the player is holding a washable item
    {
        //will only work if the player press the interact button while holding contaminated plastic, metal and glass objects
        if ((InteractButton.instance.buttonPressed == true || Input.GetButtonDown("Pickup")) && (PlayerController.instance.objectHolding.tag == "ContaminatedPlastic" || PlayerController.instance.objectHolding.tag == "ContaminatedMetal" || PlayerController.instance.objectHolding.tag == "ContaminatedGlass"))
        {
            //set back the bool value for buttonPressed in InteracrtButton.cs to false, then run the coroutine to show the progress of the “washing”
            //while washing, player will be busy and wont be able to move or perform any other action
            //instantiate the same object that the player was holding into the wash position, then destroy the object that player was holding

            InteractButton.instance.buttonPressed = false;
            //PickUp.instance.holding = false;
            //PlayerController.instance.objectHolding.SetActive(false);
            StartCoroutine(UpdateProgressBar());
            PlayerController.instance.animator.SetBool("busy", true);
            washCurrent = Instantiate(PlayerController.instance.objectHolding, Wash);
            Destroy(PlayerController.instance.objectHolding);
            animator.SetBool("Basinon", true);
            audioSource.Play();
        }
        
    }

    //coroutine to show the progress of player washing visually. Little progress bar will appear and filled up as the time pass by
    IEnumerator UpdateProgressBar() //washing anim
    {
        Debug.Log("Updating");
        PlayerController.instance.isWorking = true; //sets the boolean of isworking to true(not allowing the player to move)
        progress.gameObject.SetActive(true); //sets progress bar to true

        float score = 0f; //sets the score to 0 
        while (score < 2f)
        {
            yield return new WaitForSeconds(1f); //waits for 1 second
            score += 1;
            Debug.Log(score);
            progress.value = score; //sets the progress bar value to the score
        }
        if (score == 2f) //once 2 sec has passed
        {
            StartCoroutine(FinishWashing());
            animator.SetBool("Basinon", false);
            

        }

    }
    //once the updateprogressbar coroutine is done, finishwashing coroutine will run
    IEnumerator FinishWashing()
    {
        //deactivate the progresbar. Then using the tag in each rubbish object, perform different tasks accordingly
        //once the rubbish objects are sorted using the tag, we will then use the gameobjects name to find the index of the identical contaminated object in the array list
        //then, using that index, instantiate the clean object inside the cleanobj arraylist. Hence, when setting up the project the index for both clean and contaminated objects must be the same (e.g. if contaminated glassJar is in index 0 of contaminated obj array list, clean glassJar needs to be in index 0 of clean obj array list as well) 

        progress.gameObject.SetActive(false); //sets progress bar to false
        PlayerController.instance.isWorking = false; //sets the boolean of isworking to false(allowing the player to move)
        if (washCurrent.tag == "ContaminatedPlastic") //check the tag of the item
        {
            
            for (int i = 0; i < contaminatedPlastic.Length; i++)
            {
                Debug.Log(washCurrent.name + "(Clone)");
                if (washCurrent.name == contaminatedPlastic[i].name + "(Clone)" + "(Clone)")
                {
                    Destroy(washCurrent);
                    PlayerController.instance.objectHolding = Instantiate(cleanPlastic[i], PlayerController.instance.itemHolder); //gives the player the same rubbish placed in but clean
                    PlayerController.instance.objectHolding.GetComponent<Collider2D>().enabled = false; //turns off the collider
                    Debug.Log("cleaned plastic");
                    
                    
                    break;
                    
}
            }
        }
        else if(washCurrent.tag == "ContaminatedMetal") //check the tag of the item
        {
            for (int i = 0; i < contaminatedMetal.Length; i++)
            {
                //Debug.Log(PlayerController.instance.objectHolding.name + "(Clone)");
                if (washCurrent.name == contaminatedMetal[i].name + "(Clone)" + "(Clone)")
                {
                    Destroy(washCurrent);
                    PlayerController.instance.objectHolding = Instantiate(cleanMetal[i], PlayerController.instance.itemHolder); //gives the player the same rubbish placed in but clean
                    PlayerController.instance.objectHolding.GetComponent<Collider2D>().enabled = false; //turns off the collider
                    break;
                }
            }
        }
        else if (washCurrent.tag == "ContaminatedGlass")
        {
            for (int i = 0; i < contaminatedGlass.Length; i++)
            {
                //Debug.Log(PlayerController.instance.objectHolding.name + "(Clone)");
                if (washCurrent.name == contaminatedGlass[i].name + "(Clone)" + "(Clone)")
                {
                    Destroy(washCurrent);
                    PlayerController.instance.objectHolding = Instantiate(cleanGlass[i], PlayerController.instance.itemHolder); //gives the player the same rubbish placed in but clean
                    PlayerController.instance.objectHolding.GetComponent<Collider2D>().enabled = false; //turns off the collider
                    break;
                }
            }
        }
        audioSource.Stop(); //stops the water sound
        PlayerController.instance.animator.SetBool("busy", false); 
        PlayerController.instance.animator.SetBool("is carrying", true);
        progress.value = progress.minValue;
        yield break;
    }
}
