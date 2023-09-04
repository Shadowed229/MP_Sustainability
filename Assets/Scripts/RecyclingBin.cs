using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecyclingBin : MonoBehaviour
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
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        DistanceFromPlayer();
        if(PickUp.instance.holding)
        {
            if (isClose && RandomTrash.instance.isRecyclable())
            {
                Debug.Log("much close");
                Recycling();
            }
            if (isClose && !RandomTrash.instance.isRecyclable())
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
            points.gameObject.SetActive(true);
            backdrop.GetComponent<Image>().color = new Color32(255, 0, 0, 150);
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



}
