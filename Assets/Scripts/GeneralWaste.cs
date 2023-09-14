using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralWaste : MonoBehaviour
{
    public static bool isClose; //to check if the player is close enough to interact with the general waste bin
    public Text points; // this will later be shown if the player throw away the correct rubbish to show that player earned points by getting correct rubbish to the bin 
    public Animator animator; //animator for the rubbish bin. Animation will allow the bin to open and close
    public AudioSource audioSource; //audiosource to be played when the user throws away the rubbish into the bin
    public Image backdrop; //background image to better show if the player threw away correct/wrong rubbish
    //public Slider progress;

    // Update is called once per frame
    void Update()
    {
        DistanceFromPlayer(); //calling function below 
        if (PickUp.instance.holding) //below code will only run if the plyer is holding the rubbish 

        {
            if (isClose && RandomTrash.instance.isGeneralWaste())
            {
                //if the player is close enough and holding correct rubbish (general waste) player would be able to “recycle” the rubbish
                Recycling();
            }
            if (isClose && !RandomTrash.instance.isGeneralWaste())
            {
                //if the rubbish that player is holding is wrong rubbish, it will prompt error message to show that its wrong
                ErrorMessage();
            }
        }
    }

    //function to prompt the error message
    void ErrorMessage()
    {
        //check if the interact button has been pressed
        if (InteractButton.instance.buttonPressed == true || Input.GetButtonDown("Pickup"))
        {
            //below codes will generate the error message with white text and red background
            //Then call the coroutine function to deactivate the error message after few seconds
            InteractButton.instance.buttonPressed = false;
            points.color = Color.white;
            points.text = "Wrong Bin!";
            backdrop.GetComponent<Image>().color = new Color32(255, 0, 0, 150);
            points.gameObject.SetActive(true);
            backdrop.gameObject.SetActive(true);

            StartCoroutine(UpdateTextPos());
        }
    }

    //function to check the distance of the player from the general waste bin
    void DistanceFromPlayer()
    {
        //use vector3.distance function in unity to find the distance and according to the distance found, return back the bool value to check if the player is close enough to the waste bin to be able to interact with it
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

    //function to show that the player got the correct bin and it will increase the value in the “progressbar” and prompt the +points text to show that player is correct
    void Recycling()
    {
        if (InteractButton.instance.buttonPressed == true || Input.GetButtonDown("Pickup"))
        {
            InteractButton.instance.buttonPressed = false;
            Destroy(PlayerController.instance.objectHolding);
            LevelManager.instance.score += 1;
            points.color = Color.white;
            points.text = "+ 10 pts";
            backdrop.GetComponent<Image>().color = new Color32(0, 255, 0, 150);
            points.gameObject.SetActive(true);
            backdrop.gameObject.SetActive(true);
            PickUp.instance.holding = false;
            PlayerController.instance.animator.SetTrigger("drop");
            audioSource.Play();
            animator.SetBool("General", true);
            points.transform.Translate(Vector3.up * Time.deltaTime);
            StartCoroutine(UpdateTextPos());

        }
    }

    //function to disable the +point/error message prompt after few seconds
    //animation for opening and closing the general wast bin is also being called in this function
    IEnumerator UpdateTextPos()
    {
        Debug.Log("Updating");


        yield return new WaitForSeconds(1.5f);
        points.gameObject.SetActive(false);
        backdrop.gameObject.SetActive(false);
        animator.SetBool("General", false);
        audioSource.Stop();

    }

}

