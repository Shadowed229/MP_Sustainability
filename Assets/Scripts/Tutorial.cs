using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject[] popUps;
    public GameObject characterMonologue;
    private int popUpIndex;
    private float waitTime = 30f;
    private float waitTimeIndex;
    public Text msgTxt;
    public GameObject touchToProceed;
    public TextWriter textWriter;

    public bool generalWasteTutDone;
    public bool glassTutDone;
    public bool washTutDone;
    public bool paperTutDone;
    public bool compostTutDone;
    public bool nonReguTutDone;
    public bool ReguTutDone;
    public string sceneName;
    public Scene currentScene;
    public static bool tutorialing;
    // Start is called before the first frame update
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }
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
        sceneName = currentScene.name;
        if (sceneName == "Level1")
        {
            Level1Tutorial();
        }
        if (sceneName == "Level2")
        {
            Level2Tutorial();
        }
        if (sceneName == "Level3")
        {
            Level3Tutorial();
        }

    }

    private void Level1Tutorial()
    {
        if (popUpIndex == 0) //intro to the game
        {
            tutorialing = true;

            if (textWriter.isGeneratingText == false)
            {
                characterMonologue.SetActive(true);
                textWriter.AddWriter(msgTxt, "Hello! Welcome to Eco Warrior! In this level, we will learn the basics of this game!", 0.02f, true);
            }

            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = 7;
            }

#if UNITY_EDITOR
            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = 7;
            }
# endif

        }
        else if (popUpIndex == 1) // tutorial on movement ----------------------------------------------------------------
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
                if (PlayerController.instance.objectHolding.CompareTag("GeneralWaste") && generalWasteTutDone == false)
                {
                    popUpIndex = 3;
                }
                if (PlayerController.instance.objectHolding.CompareTag("ContaminatedGlass") && glassTutDone == false)
                {
                    popUpIndex = 4;
                }
                if ((PlayerController.instance.objectHolding.CompareTag("ContaminatedPlastic") || PlayerController.instance.objectHolding.CompareTag("ContaminatedMetal")) && washTutDone == false)
                {
                    popUpIndex = 5;
                }
                if (PlayerController.instance.objectHolding.CompareTag("Paper") && paperTutDone == false)
                {
                    popUpIndex = 6;
                }
            }
        }
        else if (popUpIndex == 3) //general waste tutorial -----------------------------------------------------------------
        {
            tutorialing = true;
            generalWasteTutDone = true;

            if (textWriter.isGeneratingText == false)
            {
                characterMonologue.SetActive(true);
                textWriter.AddWriter(msgTxt, "These general wastes can be thrown directly to the general waste bin", 0.02f, true);

            }

            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = popUps.Length + 1;
            }

#if UNITY_EDITOR
            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = popUps.Length + 1;
            }
# endif
        }
        else if (popUpIndex == 4) // Glass tutorial -------------------------------------------------------------
        {
            tutorialing = true;
            glassTutDone = true;

            if (textWriter.isGeneratingText == false)
            {
                characterMonologue.SetActive(true);
                textWriter.AddWriter(msgTxt, "Glass need to be rinsed at the washing basin, cleaning it before throwing it into the recycling bin!", 0.02f, true);

            }

            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = popUps.Length + 1;
            }

#if UNITY_EDITOR
            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = popUps.Length + 1;
            }
# endif
        }
        else if (popUpIndex == 5) // Plastic and Can tutorial --------------------------------------------------
        {
            tutorialing = true;
            washTutDone = true;

            if (textWriter.isGeneratingText == false)
            {
                characterMonologue.SetActive(true);
                textWriter.AddWriter(msgTxt, "Plastic and Metal need to be rinsed at the washing basin, cleaning it before throwing it into the recycling bin!", 0.02f, true);

            }

            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = popUps.Length + 1;
            }

#if UNITY_EDITOR
            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = popUps.Length + 1;
            }
# endif
        }
        else if (popUpIndex == 6) // Paper --------------------------------------------------
        {
            tutorialing = true;
            paperTutDone = true;

            if (textWriter.isGeneratingText == false)
            {
                characterMonologue.SetActive(true);
                textWriter.AddWriter(msgTxt, "Paper waste items can be thrown directly into the recycling bins. However some papers such as napkins and paper towels cant be recycled", 0.02f, true);

            }

            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = popUps.Length + 1;
            }

#if UNITY_EDITOR
            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = popUps.Length + 1;

            }
#endif
        }

        else if (popUpIndex == 7) //intro to the timer ------------------------------------------------
        {
            tutorialing = true;

            if (textWriter.isGeneratingText == false)
            {
                characterMonologue.SetActive(true);
                textWriter.AddWriter(msgTxt, "In every level, there will be a timer running at the top middle of your screen, and you need to throw away all the rubbish within the given amount of time! Now, lets get started!", 0.02f, true);
            }

            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = 1;
            }

#if UNITY_EDITOR
            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = 1;
            }
#endif
        }

        if (PlayerController.instance.objectHolding != null)
        {
            if (PlayerController.instance.objectHolding.CompareTag("GeneralWaste") && generalWasteTutDone == false)
            {
                popUpIndex = 3;
            }
            if (PlayerController.instance.objectHolding.CompareTag("ContaminatedGlass") && glassTutDone == false)
            {
                popUpIndex = 4;
            }
            if ((PlayerController.instance.objectHolding.CompareTag("ContaminatedPlastic") || PlayerController.instance.objectHolding.CompareTag("ContaminatedMetal")) && washTutDone == false)
            {
                popUpIndex = 5;
            }
            if (PlayerController.instance.objectHolding.CompareTag("Paper") && paperTutDone == false)
            {
                popUpIndex = 6;
            }
        }
    }


    void Level2Tutorial()
    {
        if (popUpIndex == 0) //intro to the game
        {
            tutorialing = true;

            if (textWriter.isGeneratingText == false)
            {
                characterMonologue.SetActive(true);
                textWriter.AddWriter(msgTxt, "Welcome to Level 2, a new compost bin has been added!", 0.02f, true);
            }

            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = popUps.Length + 1;
            }

#if UNITY_EDITOR
            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = popUps.Length + 1;
            }
# endif

        }
        else if (popUpIndex == 1) //general waste tutorial -----------------------------------------------------------------
        {
            tutorialing = true;
            compostTutDone = true;

            if (textWriter.isGeneratingText == false)
            {
                characterMonologue.SetActive(true);
                textWriter.AddWriter(msgTxt, "Compostables like food waste can be thrown into the brown compost bin", 0.02f, true);

            }

            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = popUps.Length + 1;
                Debug.Log(popUpIndex);
            }

#if UNITY_EDITOR
            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = popUps.Length + 1;
                Debug.Log(popUpIndex);
            }
# endif
        }
        if(PlayerController.instance.objectHolding != null)
        {
            if (PlayerController.instance.objectHolding.CompareTag("Compostable") && compostTutDone == false)
            {
                popUpIndex = 1;
            }
        }
    }
    void Level3Tutorial()
    {
        if (popUpIndex == 0) //intro to the game
        {
            tutorialing = true;

            if (textWriter.isGeneratingText == false)
            {
                characterMonologue.SetActive(true);
                textWriter.AddWriter(msgTxt, "Welcome to Level 3, there is 2 bins added, Non-Regulated Bin and Regulated Bin. This are both for E-Waste!", 0.02f, true);
            }

            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = popUps.Length + 1;
            }

#if UNITY_EDITOR
            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = popUps.Length + 1;
            }
# endif

        }
        else if (popUpIndex == 1) //general waste tutorial -----------------------------------------------------------------
        {
            tutorialing = true;
            nonReguTutDone = true;

            if (textWriter.isGeneratingText == false)
            {
                characterMonologue.SetActive(true);
                textWriter.AddWriter(msgTxt, "This are Non Regulated E-Waste, They are to be thrown into the Non-Regulated Bin!", 0.02f, true);

            }

            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = popUps.Length + 1;
                Debug.Log(popUpIndex);
            }

#if UNITY_EDITOR
            if (textWriter.uiText == null && waitTimeIndex <= 0)
            {
                touchToProceed.SetActive(true);
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
                touchToProceed.SetActive(false);
                tutorialing = false;
                popUpIndex = popUps.Length + 1;
                Debug.Log(popUpIndex);
            }
#endif
        }

            else if (popUpIndex == 2) //general waste tutorial -----------------------------------------------------------------
            {
                tutorialing = true;
                ReguTutDone = true;

                if (textWriter.isGeneratingText == false)
                {
                    characterMonologue.SetActive(true);
                    textWriter.AddWriter(msgTxt, "This are Regulated E-Waste, They are to be thrown into the Regulated Bin!", 0.02f, true);

                }

                if (textWriter.uiText == null && waitTimeIndex <= 0)
                {
                    touchToProceed.SetActive(true);
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
                    touchToProceed.SetActive(false);
                    tutorialing = false;
                    popUpIndex = popUps.Length + 1;
                    Debug.Log(popUpIndex);
                }

#if UNITY_EDITOR
                if (textWriter.uiText == null && waitTimeIndex <= 0)
                {
                    touchToProceed.SetActive(true);
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
                    touchToProceed.SetActive(false);
                    tutorialing = false;
                    popUpIndex = popUps.Length + 1;
                    Debug.Log(popUpIndex);
                }
#endif
            }
        if (PlayerController.instance.objectHolding != null)
        {
            if (PlayerController.instance.objectHolding.CompareTag("NonRegulated") && nonReguTutDone == false)
            {
                popUpIndex = 1;
            }
            if (PlayerController.instance.objectHolding.CompareTag("Regulated") && ReguTutDone == false)
            {
                popUpIndex = 2;
            }
        }   
    } 
}


