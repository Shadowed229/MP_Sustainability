using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPile : MonoBehaviour
{
    public static TrashPile instance;
    public GameObject playerRef;
    public GameObject trashBagPrefab;
    public float distancebetweentrashpile;
    public bool isClose;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerRef = PlayerController.instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (distancebetweentrashpile < 2)
        {
            isClose = true;
        }
        else
        {
            isClose = false;
        }

        distancebetweentrashpile = Vector3.Distance(transform.position, playerRef.transform.position);
        if (isClose)
        {
            Debug.Log("Close to Pile");
            if (InteractButton.instance.buttonPressed == true || Input.GetButtonDown("Pickup"))
            {
                if (PickUp.instance.holding == false)
                {


                    PickUp.instance.holding = true;
                    PlayerController.instance.objectHolding = Instantiate(trashBagPrefab, PlayerController.instance.itemHolder);

                }
                else
                {
                    Debug.Log("drop your item first");
                }
            }
        }
    }
}
