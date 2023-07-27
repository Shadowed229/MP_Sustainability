using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class WashingBasin : MonoBehaviour
{
    
    public Slider progress;
    public GameObject[] contaminatedPlastic;
    public GameObject[] cleanPlastic;
    public GameObject[] contaminatedMetal;
    public GameObject[] cleanMetal;

    public static bool isClose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

    void WashingWaste()
    {
        if(Input.GetButtonDown("Pickup") && (PlayerController.instance.objectHolding.tag == "ContaminatedPlastic" || PlayerController.instance.objectHolding.tag == "ContaminatedMetal"))
        {
            PickUp.instance.holding = false;
            //PlayerController.instance.objectHolding.SetActive(false);
            StartCoroutine(UpdateProgressBar());
        }
        
    }

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
        if(PlayerController.instance.objectHolding.tag == "ContaminatedPlastic")
        {
            
            for (int i = 0; i < contaminatedPlastic.Length; i++)
            {
                if (PlayerController.instance.objectHolding.name == contaminatedPlastic[i].name)
                {
                    Destroy(PlayerController.instance.objectHolding);
                    PlayerController.instance.objectHolding = Instantiate(cleanPlastic[i], PlayerController.instance.itemHolder);
                    Debug.Log("cleaned plastic");
                    break;
                }
            }
        }
        else if(PlayerController.instance.objectHolding.tag == "ContaminatedMetal")
        {
            for (int i = 0; i < contaminatedMetal.Length; i++)
            {
                if (PlayerController.instance.objectHolding.name == contaminatedMetal[i].name)
                {
                    Destroy(PlayerController.instance.objectHolding);
                    PlayerController.instance.objectHolding = Instantiate(cleanMetal[i], PlayerController.instance.itemHolder);
                    break;
                }
            }
        }
        
        progress.value = progress.minValue;
        yield break;
    }
}
