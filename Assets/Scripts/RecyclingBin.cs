using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecyclingBin : MonoBehaviour
{
    public static bool isClose; //Variable to check if the player is near the recycling bin
    public Text points; //Variable to prompt the score once the player either get the correct or wrong rubbish into the recycling bin
    public Transform textTrans;
    public Animator animator;
    public AudioSource audioSource;
    public Image backdrop;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        DistanceFromPlayer();//function to constantly check if the player is close to the recycle bin to interact with it
        if (PickUp.instance.holding)
        {   //if the player is near the recycling and the object its holding is recyclable (clean) object player will be able to recycle 
            if (isClose && RandomTrash.instance.isRecyclable())
            {
                Debug.Log("much close");
                Recycling();
            } //if else, prompt different thing like error message or different set of instruction to make it right
            if (isClose && RandomTrash.instance.isNotWashed())
            {
                Debug.Log("Item not washed!");
                notWash();
            }
            else if (isClose && !RandomTrash.instance.isRecyclable())
            {
                ErrorMessage();
            }

        }
    }
    // this is to prompt the player that the player is trying to throw away the rubbish in the wrong bin 
    void ErrorMessage()
    {
        if (InteractButton.instance.buttonPressed == true || Input.GetButtonDown("Pickup"))
        {
            InteractButton.instance.buttonPressed = false;
            points.color = Color.white;
            points.text = "Wrong Bin!";
            points.gameObject.SetActive(true);
            backdrop.GetComponent<Image>().color = new Color32(255, 0, 0, 150);
            backdrop.gameObject.SetActive(true);

            StartCoroutine(UpdateTextPos());
        }
    }

    //function to find the distance between the player using vector3 distance
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

    //recycling function. destroy the object that player is holding and prompt things like points, to show that the player got the correct bin
    void Recycling()
    {
        if (InteractButton.instance.buttonPressed == true || Input.GetButtonDown("Pickup"))
        {
            InteractButton.instance.buttonPressed = false;
            Destroy(PlayerController.instance.objectHolding);
            LevelManager.instance.score += 1;
            points.color = Color.white;
            points.text = "+ 10 pts";
            PickUp.instance.holding = false;
            backdrop.GetComponent<Image>().color = new Color32(0, 255, 0, 150);
            points.gameObject.SetActive(true);
            backdrop.gameObject.SetActive(true);
            points.transform.Translate(Vector3.up * Time.deltaTime);
            StartCoroutine(UpdateTextPos());
            PlayerController.instance.animator.SetTrigger("drop");
            audioSource.Play();
            animator.SetBool("Recycle", true);

        }
    }

    // prompting the points text for few seconds
    IEnumerator UpdateTextPos() //washing anim
    {
        Debug.Log("Updating");


        yield return new WaitForSeconds(1.5f);
        points.gameObject.SetActive(false);
        backdrop.gameObject.SetActive(false);
        //points.gameObject.transform.position = textTrans.position;
        yield return true;
        animator.SetBool("Recycle", false);
        audioSource.Stop();

    }
    // if the player did not wash the item before recycling, we will prompt other message to let the player know that they should clean the rubbish before throwing
    void notWash()
    {
        if (InteractButton.instance.buttonPressed == true || Input.GetButtonDown("Pickup"))
        {
            InteractButton.instance.buttonPressed = false;
            points.color = Color.white;
            points.text = "Wash Item!";
            points.gameObject.SetActive(true);
            backdrop.GetComponent<Image>().color = new Color32(255, 0, 0, 150);
            backdrop.gameObject.SetActive(true);

            StartCoroutine(UpdateTextPos());
        }
    }

}
