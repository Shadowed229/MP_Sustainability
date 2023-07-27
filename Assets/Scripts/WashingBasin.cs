using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WashingBasin : MonoBehaviour
{
    private GameObject trash;
    public Slider progress;
    public GameObject[] allTrash;

    public Transform placeholder;
    public Transform placeholder2;
    public Transform placeholder3;
    public static bool occupied;
    public static bool Rubbish1;
    public static bool Rubbish2;
    public static bool Rubbish3;
    public GameObject player;
    private float fillTime;

    public static bool isClose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator UpdateProgressBar()
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
            StartCoroutine(WorkstationSpawn());
        }

    }
    IEnumerator WorkstationSpawn()
    {
        int whichrubbish = Random.Range(0, 12);
        int rubbishspawn = Random.Range(0, 3);
        if (rubbishspawn == 0) //1 rubbish spawn
        {
            GameObject spawnable = allTrash[whichrubbish];
            Instantiate(spawnable, placeholder);
            whichrubbish = Random.Range(0, 2);
            Rubbish1 = true;
        }
        else if (rubbishspawn == 1) //2 rubbish spawn
        {
            GameObject spawnable = allTrash[whichrubbish];
            Instantiate(spawnable, placeholder);
            whichrubbish = Random.Range(0, 2);
            GameObject spawnable2 = allTrash[whichrubbish];
            Instantiate(spawnable2, placeholder2);
            Rubbish2 = true;
        }
        else if (rubbishspawn == 2) //3 rubbish spawn
        {
            GameObject spawnable = allTrash[whichrubbish];
            Instantiate(spawnable, placeholder);
            whichrubbish = Random.Range(0, 2);
            GameObject spawnable2 = allTrash[whichrubbish];
            Instantiate(spawnable2, placeholder2);
            whichrubbish = Random.Range(0, 2);
            GameObject spawnable3 = allTrash[whichrubbish];
            Instantiate(spawnable3, placeholder3);
            Rubbish3 = true;
        }
        progress.gameObject.SetActive(false);
        PlayerController.instance.isWorking = false;
        progress.value = progress.minValue;
        yield break;
    }
}
