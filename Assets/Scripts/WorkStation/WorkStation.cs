using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkStation : MonoBehaviour
{
    private GameObject trash;
    public GameObject[] allTrash;

    public Transform placeholder;
    public Transform placeholder2;
    public Transform placeholder3;
    public static bool occupied;
    public static bool Rubbish1;
    public static bool Rubbish2;
    public static bool Rubbish3;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Rubbish1 = false;
        Rubbish2 = false;
        Rubbish3 = false;
        occupied = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distancebetweenPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (PickUp.trashholding == true && occupied == false  && distancebetweenPlayer < 2)
        {
            Debug.Log("Close to Workstation!"); 
            if (Input.GetButtonDown("Pickup"))
            {
                PickUp.trashholding = false;
                trash = GameObject.FindGameObjectWithTag("Trash");
                Destroy(trash);
                PickUp.holding = false;
                //occupied = true;
                int whichrubbish = Random.Range(0, 12);
                int rubbishspawn = Random.Range(0, 3);
                if (rubbishspawn == 0) //1 rubbish spawn
                {
                    GameObject spawnable = allTrash[whichrubbish];
                    Instantiate(spawnable,placeholder);
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


            }
        }
    }
}
