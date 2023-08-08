using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompostBin : MonoBehaviour
{
    public static bool isClose;
    public Text points;
    public Transform textTrans;
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
            if (isClose && isCompost())
            {
                Debug.Log("much close");
                Recycling();
            }
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

    bool isCompost()
    {
        if (PlayerController.instance.objectHolding.tag == "Compostable")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Recycling()
    {
        if (InteractButton.instance.buttonPressed == true || Input.GetButtonDown("Pickup"))
        {
            Destroy(PlayerController.instance.objectHolding);
            LevelManager.instance.score += 1;
            points.color = Color.green;
            points.text = "+ 10 pts";
            PickUp.instance.holding = false;
            points.gameObject.SetActive(true);
            points.transform.Translate(Vector3.up * Time.deltaTime);
            StartCoroutine(UpdateTextPos());

        }
    }


    IEnumerator UpdateTextPos() //washing anim
    {
        Debug.Log("Updating");


        yield return new WaitForSeconds(1.5f);
        points.gameObject.SetActive(false);
        points.gameObject.transform.position = textTrans.position;
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
