using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject[] popUps;
    public GameObject characterMonologue;
    private int popUpIndex;
    private float waitTime = 5f;
    private float waitTimeIndex;
    public Text msgTxt;
    public Text touch;
    public TextWriter textWriter;
    // Start is called before the first frame update
    void Start()
    {
        popUpIndex = 0;
        waitTimeIndex = waitTime;
        
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < popUps.Length; i++)
        {
            if (LevelManager.instance.isPaused != true)
            {
                if (i == popUpIndex)
                {
                    popUps[i].SetActive(true);
                }
                else
                {
                    popUps[i].SetActive(false);
                }
            }
            else
            {
                popUps[i].SetActive(false);
            }

        }

        Level1Tutorial();
        
    }

    void Level1Tutorial()
    {
        if (popUpIndex == 0)
        {

            if (textWriter.isGeneratingText == false)
            {
                characterMonologue.SetActive(true);
                textWriter.AddWriter(msgTxt, "Hello! Welcome to Eco Warrior! In this levl, we will learn the basics of this game!", 0.02f, true);             
            }

            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touch.gameObject.SetActive(true);
                waitTimeIndex = waitTime;
            }
            else
            {
                waitTimeIndex -= Time.deltaTime;
            }

            if (textWriter.uiText == null && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {        
                textWriter.isGeneratingText = false;
                characterMonologue.SetActive(false);
                touch.gameObject.SetActive(false);
                popUpIndex++;
            }

#if UNITY_EDITOR
            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touch.gameObject.SetActive(true);
                waitTimeIndex = waitTime;

            }
            else
            {
                waitTimeIndex -= Time.deltaTime;
            }

            if (textWriter.uiText == null && Input.GetMouseButtonDown(0))
            {
                textWriter.isGeneratingText = false;
                characterMonologue.SetActive(false);
                touch.gameObject.SetActive(false);
                popUpIndex++;
            }
# endif

        }
        else if (popUpIndex == 1)
        {
            if (PlayerController.instance.theRB.velocity != Vector2.zero)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (PlayerController.instance.objectHolding != null)
            {
                if (PlayerController.instance.objectHolding.tag == "GeneralWaste")
                {
                    popUpIndex = 3;
                }
                if (PlayerController.instance.objectHolding.tag == "Glass")
                {
                    popUpIndex = 4;
                }
                if (PlayerController.instance.objectHolding.tag == "ContaminatedPlastic" || PlayerController.instance.objectHolding.tag == "ContaminatedMetal")
                {
                    popUpIndex = 5;
                }
            }
        }
        else if (popUpIndex == 3)
        {
            if (textWriter.isGeneratingText == false)
            {
                characterMonologue.SetActive(true);
                textWriter.AddWriter(msgTxt, "What you've picked up is General Waste. General waste is any rubbish businesses and households throw away that you can't usually recycle", 0.02f, true);

            }

            if (WorkStation.isClose == true)
            {
                popUpIndex = popUps.Length + 1;
            }
        }
        else if (popUpIndex == 4)
        {
            if (PlayerController.instance.isWorking == true)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 5)
        {
            if (waitTimeIndex <= 0f)
            {
                popUpIndex++;
                waitTimeIndex = waitTime;
            }
            else if(PlayerController.instance.objectHolding != null)
            {
                waitTimeIndex -= Time.deltaTime;
            }
        }
        else if (popUpIndex == 6)
        {
            if (waitTimeIndex <= 0f)
            {
                popUpIndex++;
                waitTimeIndex = waitTime;
            }
            else
            {
                waitTimeIndex -= Time.deltaTime;
            }
        }
    }
}
