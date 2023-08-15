using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using JetBrains.Annotations;

public class WrappingStation : MonoBehaviour
{

    public Slider progress;
    public GameObject[] RegulatedItems;
    public GameObject Box;


    public static bool isClose;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetTrigger("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        DistanceFromPlayer();

        if (isClose && PickUp.instance.holding == true && PlayerController.instance.objectHolding != null)
        {
            InteractButton.instance.buttonPressed = false;
            WrappingWaste();

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

    void WrappingWaste()
    {
        if ((InteractButton.instance.buttonPressed == true || Input.GetButtonDown("Pickup")) && (PlayerController.instance.objectHolding.tag == "Regulated"))
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
            StartCoroutine(FinishWrapping());
            //animator.SetTrigger("Basinoff");
        }

    }
    IEnumerator FinishWrapping()
    {
        progress.gameObject.SetActive(false);
        PlayerController.instance.isWorking = false;
        if (PlayerController.instance.objectHolding.tag == "Regulated")
        {

            for (int i = 0; i < RegulatedItems.Length; i++)
            {
                Debug.Log(PlayerController.instance.objectHolding.name + "(Clone)");
                if (PlayerController.instance.objectHolding.name == RegulatedItems[i].name + "(Clone)")
                {
                    Debug.Log("Wrapping");
                    Destroy(PlayerController.instance.objectHolding);
                    PlayerController.instance.objectHolding = Instantiate(Box, PlayerController.instance.itemHolder);
                    Debug.Log("cleaned plastic");
                    //PlayerController.instance.animator.SetBool("busy", false);

                    break;

                }
            }
        }

        progress.value = progress.minValue;
        yield break;
    }
}
