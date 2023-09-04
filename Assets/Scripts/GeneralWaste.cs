using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralWaste : MonoBehaviour
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
            if (isClose && RandomTrash.instance.isGeneralWaste())
            {
                Debug.Log("much close");
                Recycling();
            }
            if (isClose && !RandomTrash.instance.isGeneralWaste())
            {
                ErrorMessage();
            }
        }
    }
    void ErrorMessage()
    {
        if (InteractButton.instance.buttonPressed == true || Input.GetButtonDown("Pickup"))
        {
            InteractButton.instance.buttonPressed = false;
            points.color = Color.white;
            points.text = "Wrong Bin!";
            backdrop.GetComponent<Image>().color = new Color32(255, 0, 0, 150);
            points.gameObject.SetActive(true);
            backdrop.gameObject.SetActive(true);

            StartCoroutine(UpdateTextPos());
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


    IEnumerator UpdateTextPos() //washing anim
    {
        Debug.Log("Updating");


        yield return new WaitForSeconds(1.5f);
        points.gameObject.SetActive(false);
        backdrop.gameObject.SetActive(false);
        //points.gameObject.transform.position = textTrans.position;
        animator.SetBool("General", false);
        audioSource.Stop();

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

