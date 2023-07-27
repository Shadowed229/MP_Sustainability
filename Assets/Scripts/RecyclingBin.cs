using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecyclingBin : MonoBehaviour
{
    public static bool isClose;
    //public Slider progress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DistanceFromPlayer();
        if(PickUp.instance.holding)
        {
            if (isClose && isRecyclable())
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

    bool isRecyclable()
    {
        if(PlayerController.instance.objectHolding.tag == "Glass")
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

    void Recycling()
    {
        if (Input.GetButtonDown("Pickup"))
        {
            Destroy(PlayerController.instance.objectHolding);
            // add points or in progress bar
            PickUp.instance.holding = false;
            //StartCoroutine(UpdateProgressBar());

        }
    }

    /*
    IEnumerator UpdateProgressBar() //washing anim
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
        if (score == 3f)
        {
            StartCoroutine(FinishWashing());
        }

    }
    IEnumerator FinishWashing()
    {
        progress.gameObject.SetActive(false);
        PlayerController.instance.isWorking = false;


        progress.value = progress.minValue;
        yield break;
    }
    */
}
