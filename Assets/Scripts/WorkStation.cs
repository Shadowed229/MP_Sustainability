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
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distancebetweenPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (PickUp.holding == true && occupied == false && PickUp.trashhold == true && distancebetweenPlayer < 2)
        {
            Debug.Log("Access Passed"); 
            if (Input.GetButtonDown("Pickup"))
            {
                PickUp.trashhold = false;
                trash = GameObject.FindGameObjectWithTag("Trash");
                Destroy(trash);
                PickUp.holding = false;
                int whichrubbish = Random.Range(0, 2);
                int rubbishspawn = Random.Range(0, 3);
                if (rubbishspawn == 0) //1 rubbish spawn
                {
                    GameObject spawnable = allTrash[whichrubbish];
                    Instantiate(spawnable,placeholder);
                    whichrubbish = Random.Range(0, 2);
                }
                else if (rubbishspawn == 1) //2 rubbish spawn
                {
                    GameObject spawnable = allTrash[whichrubbish];
                    Instantiate(spawnable, placeholder);
                    whichrubbish = Random.Range(0, 2);
                    GameObject spawnable2 = allTrash[whichrubbish];
                    Instantiate(spawnable2, placeholder2);
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
                }


            }
        }
    }
}
