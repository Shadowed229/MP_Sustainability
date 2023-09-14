using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance; //public static var of the script so that the other scripts can refer to the variables and functions in this script 
    public bool isPaused; //bool variable to check if the game is paused or not paused
    public bool isGameOver; //bool variable to check if the game has ended/lost the game 
    public float score; //float variable to keep track of the score throughout the game to determine if the player has won the game/levels
    public int rubbishspawn; //int variable to keep track of the number of rubbish that spawned in the game scene 
    public GameObject winMenu; //gameobject which contains image/ui element for winmenu this will be enabled once the player win the game/level
    public string sceneName; //string variable to keep track of the current level scene 
    public GameObject pauseBtn; //UI element which stores image of pause btn. It will be disabled once the game ends(either win or lose)

    //during awake, instance is called so that if there are somehow multiple of levelmanager script is present in one game scene, the other scripts will refer to the latest updated script
    //then, we used getActiveScene to keep track of the current scene and the scenes name, which are then stored inside string var sceneName
    private void Awake()
    {
        instance = this;
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    //at the start phase, based on the current level, it will spawm random number of rubbish per stage (level 1, 5 to 6 rubbish will spawn and so on)
    void Start() //Checks the scene name and will determine how many trash spawns in that level
    {
        if (sceneName == "Level1")
        {
            rubbishspawn = Random.Range(5, 6);
        }
        else if (sceneName == "Level2")
        {
            rubbishspawn = Random.Range(6, 7);
        }
        else if (sceneName == "Level3")
        {
            rubbishspawn = Random.Range(6, 7);
        }
        //this will ensure the initial score is set to 0 when player first start the game
        score = 0;
        //then, we will set the maximum value of the score based on the number of rubbish that spawned in the scene. This will ensure each game levels will only be completed once the player clears all the trash in the scene 
        UIController.instance.progressbar.maxValue = rubbishspawn; // it will update the progress bar to the amount of rubbish spawned.
    }

    void Update()
    {
        //the progressbar, which we will use to determine the progress of completion of the level, will be updated as the value of score changes
        UIController.instance.progressbar.value = score;
        //Once the score become more or equals to (should be always equals to, but to make sure there are no errors we used more or equals to sign) it will run the code inside this if statement
        if (score >= rubbishspawn)
        {
            //And if the score reaches the same amount of rubbish spawned the progress bar will fill up and the win menu will be shown.
            //Code to show the winmenu for the player. We will activate the gameobject for winmenu and disable other ui elements in the scene such as pause so that player is only able to interact with the elements inside the winmenu
            winMenu.SetActive(true);
            Debug.Log("YOU WIN!");
            pauseBtn.SetActive(false);
            isGameOver = true;
        }
    }

}
