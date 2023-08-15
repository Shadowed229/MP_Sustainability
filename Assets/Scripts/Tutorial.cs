using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    private float waitTime = 5f;
    public float waitTimeIndex;
    // Start is called before the first frame update
    void Start()
    {
        popUpIndex = 0;
        waitTimeIndex = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(popUpIndex);
        for(int i = 0; i<popUps.Length; i++)
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

        Level1Tutorial();
        
    }

    void Level1Tutorial()
    {
        if (popUpIndex == 0)
        {
            if (PlayerController.instance.theRB.velocity != Vector2.zero)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (TrashPile.instance.isClose == true)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (PlayerController.instance.objectHolding != null)
            {
                if (PlayerController.instance.objectHolding.name == "TrashBag" + "(Clone)")
                {
                    popUpIndex++;
                }
            }
        }
        else if (popUpIndex == 3)
        {
            if (WorkStation.isClose == true)
            {
                popUpIndex++;
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
            }
            else
            {
                waitTimeIndex -= Time.deltaTime;
            }
        }
    }
}
