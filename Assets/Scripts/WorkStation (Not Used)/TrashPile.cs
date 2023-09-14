using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPile : MonoBehaviour
{
    public static TrashPile instance;
    private GameObject playerRef;
    public GameObject trashBagPrefab;
    public float distancebetweentrashpile;
    public bool isClose;
    public Animator animator;
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
        if (distancebetweentrashpile < 2) //checks the distance between the trashpile
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
            if (InteractButton.instance.buttonPressed == true || Input.GetButtonDown("Pickup")) // checks if interact button is pressed
            {
                Debug.Log("trashh");
                InteractButton.instance.buttonPressed = false;
                if (PickUp.instance.holding == false) //checks if the player is holding anything
                {

                    PlayerController.instance.animator.SetTrigger("carry");
                    PickUp.instance.holding = true;
                    PlayerController.instance.objectHolding = Instantiate(trashBagPrefab, PlayerController.instance.itemHolder); //instantiates the trashbag in the hands of the player

                }
                else
                {
                    Debug.Log("drop your item first");
                    
                }
            }
        }
    }
}
