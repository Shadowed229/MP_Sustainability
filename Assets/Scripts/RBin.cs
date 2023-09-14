using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RBin : MonoBehaviour
{
    public static bool isClose;
    public Text points;
    public Transform textTrans;
    public Animator animator;
    public AudioSource audioSource;
    public Image backdrop;
    //public Slider progress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DistanceFromPlayer();
        if (PickUp.instance.holding)
        {
            if (isClose && RandomTrash.instance.isRegulated())
            {
                Recycling();
            }
            if (isClose && !RandomTrash.instance.isRegulated())
            {
                Debug.Log("wrong bin bozo!");
                ErrorMessage();
            }
        }
    }
    void ErrorMessage() //if rubbish is not supposed to be in this bin, error message plays, which says wrong bin in red
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
    void DistanceFromPlayer() //checks the distance from player in relation to compost bin
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
    //if the correct rubbish is thrown, rubbish is destroyed and there will be points showing and a animation to let the player know that they are correct
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
            points.gameObject.SetActive(true);

            backdrop.GetComponent<Image>().color = new Color32(0, 255, 0, 150);
            backdrop.gameObject.SetActive(true);
            animator.SetBool("NROpen", true);
            audioSource.Play();
            //points.transform.Translate(Vector3.up * Time.deltaTime);
            StartCoroutine(UpdateTextPos());

        }
    }

    //show the points for a few seconds before turning it off.
    IEnumerator UpdateTextPos() //washing anim
    {
        Debug.Log("Updating");


        yield return new WaitForSeconds(1.5f);
        points.gameObject.SetActive(false);
        backdrop.gameObject.SetActive(false);
        animator.SetBool("ROpen", false);
        audioSource.Stop();
        //points.gameObject.transform.position = textTrans.position;
    }

    /*
    IEnumerator FinishWashing()
    {
        progress.gameObject.SetActive(false);
        PlayerController.instance.isWorking = false;


        progress.value = progress.minValue;
        yield break;
    }
    */
}
