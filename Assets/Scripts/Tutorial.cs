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
                popUpIndex++;
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
                popUpIndex++;
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
        else if (popUpIndex == 3 ) //general waste tutorial -----------------------------------------------------------------
        {
            tutorialing = true;
            generalWasteTutDone = true;

            if (textWriter.isGeneratingText == false)
            {
                characterMonologue.SetActive(true);
                textWriter.AddWriter(msgTxt, "Those general wastes can be thrown directly to the general waste bin", 0.02f, true);

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
        else if (popUpIndex == 4 ) // Glass tutorial -------------------------------------------------------------
        {
            tutorialing = true;
            glassTutDone = true;

            if (textWriter.isGeneratingText == false)
            {
                characterMonologue.SetActive(true);
                textWriter.AddWriter(msgTxt, "Glass materials need to be washed at washing basin to cleanse it before throwing it inside the recycling bin", 0.02f, true);

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
                textWriter.AddWriter(msgTxt, "Plastic and Metal materials need to be washed at washing basin to cleanse it before throwing it inside the recycling bin", 0.02f, true);

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
            washTutDone = true;

            if (textWriter.isGeneratingText == false)
            {
                characterMonologue.SetActive(true);
                textWriter.AddWriter(msgTxt, "Paper waste items can be recyvled without any process. However some papers such as napkins and paper towels cant be recycled", 0.02f, true);

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

            if (PickUp.instance.holding == true)
        
            if (PlayerController.instance.objectHolding.tag == "GeneralWaste" && generalWasteTutDone == false)
            {
                popUpIndex = 3;
            }
            if (PlayerController.instance.objectHolding.tag == "Glass" && glassTutDone == false)
            {
                popUpIndex = 4;
            }
            if ((PlayerController.instance.objectHolding.tag == "ContaminatedPlastic" || PlayerController.instance.objectHolding.tag == "ContaminatedMetal") && washTutDone == false)
            {
                popUpIndex = 5;
            }
        }
       
    }

    private void Level2Tutorial()
    {
        if (popUpIndex == 0) //intro to the game
        {
            tutorialing = true;

            if (textWriter.isGeneratingText == false)
            {
                characterMonologue.SetActive(true);
                textWriter.AddWriter(msgTxt, "Welcome! Good job on making it to Level 2 in this level you will experience a new compost bin.", 0.02f, true);
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
                popUpIndex++;
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
                popUpIndex++;
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
                if (PlayerController.instance.objectHolding.tag == "Compostable")
                {
                    popUpIndex = 3;
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
                textWriter.AddWriter(msgTxt, "Compostables like food waste can be thrown to the brown compost bin", 0.02f, true);

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


    }
}

