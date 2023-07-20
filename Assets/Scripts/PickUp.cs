using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private Transform trashpile;
    public GameObject trashBagPrefab;
    public Transform ItemHolder;
    public static bool holding;
    public static bool trashholding;

    // Start is called before the first frame update
    void Start()
    {
        holding = false;
        trashholding = false;

    }
    private void FixedUpdate()
    {


        trashpile = GameObject.FindGameObjectWithTag("TrashPile").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distancebetweentrashpile = Vector3.Distance(transform.position, trashpile.transform.position);
        if (distancebetweentrashpile < 2)
        {
            Debug.Log("Close to Pile");
            if (holding == false)
            {
                if (Input.GetButtonDown("Pickup"))
                {
                    holding = true;
                    trashholding = true;
                    Instantiate(trashBagPrefab, ItemHolder);
                    
                  
                }
            }
            
        }
        
        
        
    }
}
