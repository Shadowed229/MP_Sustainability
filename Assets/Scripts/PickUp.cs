using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public static PickUp instance; //declaring public static variable of the script to let other scripts access to the variables in this script
    public float pickupRadius = 1f; //float variable which determines how far can player reach out to pick up the rubbish 
    public LayerMask pickupLayer;

    public bool holding; //bool var to check if the player is holding any of the object
    //public bool trashholding 
    public Collider2D[] itemColliders = new Collider2D[0]; //collider list to store all the rubbish that are within the pickUpRadius
    public GameObject closestObject; //var to store the closest object identified
    private GameObject[] allTrash; //gameobject list to store all the existing rubbish item in the game scene =
    public int arrayLen; //int var to store the length of the array of itemColliders list 
    public Animator animator; //animator var to play the pickup/drop animation

    //during awake phase, declare the instance to be the latest script that’s running so that the system can always to the latest script that’s present in the scene 
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        allTrash = FindGameObjectsInLayer(6); //This function will add all the items in the layer 6 and store them in allTrash array. Layer 6 is for the rubbish item in the game.
        pickUp(); //This function will control whether if the player can pick up the rubbish item/put down or not   
    }

    public void pickUp() 
    {
        itemColliders = Physics2D.OverlapCircleAll(transform.position, pickupRadius, pickupLayer);
        //we create two temporary variables that exist only in the scope of this if statement
        //both are initialized in regards to the first element in the array
        if (itemColliders.Length >= 1) //we added if statement here to make sure we only check the distance from player to the closest object if there are any objects present in the list. This is to prevent null ref error from happening
        {
            float shortestDistanceSoFar = Vector2.Distance(gameObject.transform.position, itemColliders[0].gameObject.transform.position);

            closestObject = itemColliders[0].gameObject;

            //we loop through each element of the array
            for (int i = 0; i < itemColliders.Length; i++)
            {
                //using a temporary float variable that holds the calculated distance for each element
                float currentDistance = Vector2.Distance(gameObject.transform.position, itemColliders[i].gameObject.transform.position);
                Debug.Log(itemColliders[i]);
                //we check if said distance is smaller than the shortest distance we have stored so far
                if (currentDistance < shortestDistanceSoFar)
                {
                    //if that's true, we make that element the closest object and set the new shortest distance as the current one
                    closestObject = itemColliders[i].gameObject;
                    shortestDistanceSoFar = currentDistance;
                }
            }
            //this code is here to essentially “highlight” the closest object that is within the pickUpRadius to visually show which rubbish will the player going to pick up   
            closestObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (itemColliders.Length < 1 && closestObject != null) //for the remaining objects that are within the pickUpRadius that’s not the closest object, we will set the highlighted sprite in the child object to false   
        {
            closestObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        //we used while loop to ensure the child object that contains the highlighted sprite of the rubbish to be false as a failsafe from the above script
        int x = 0;
        while(allTrash.Length > x)
        {
            if (allTrash[x].gameObject != closestObject)
            {
                allTrash[x].gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            x++;
        }
        //referencing back from the interactBtn.cs, once the button is pressed we will call the below function to either pick up or drop the items

        if (InteractButton.instance.buttonPressed == true || Input.GetButtonDown("Pickup"))
        {
            
            if (holding == false)
            {
                if (itemColliders.Length >= 1)
                {
                    //if the player is not holding any object and if there are any objets within the pickUpRadius, this code will declare a closest object to be the players “holding object”
                    PlayerController.instance.objectHolding = closestObject;
                    //afterwards, we disabled the collider of the rubbish that player is holding, so the object that player is holding wont collide with other in game objects 
                    PlayerController.instance.objectHolding.GetComponent<Collider2D>().enabled = false;
                    Debug.Log("You picked up an item!");
                    //Then, we change the transform of the object that player is holding to be in the same position as the assigned position for items that are being held by the player. Then, we set the object to be the child object of the players itemholder position so that the assigned rubbish will follow along the player 
                    PlayerController.instance.objectHolding.transform.position = PlayerController.instance.itemHolder.position;
                    PlayerController.instance.objectHolding.transform.SetParent(PlayerController.instance.itemHolder.transform);
                    holding = true;
                    //triggering animation to show that player is carrying a rubbish
                    PlayerController.instance.animator.SetTrigger("carry");
                    //PlayerController.instance.animator.SetBool("carry and walk", true);
                    Debug.Log("hiiiiii");
                    //declare the button pressed to be false
                    InteractButton.instance.buttonPressed = false;
                }
                else //there were no rubbish nearby to pickup. So we just declared the button pressed to be false only.
                {
                    InteractButton.instance.buttonPressed = false;
                }

            } //if the player is holding the object and not near any of the rubbish bin and working stations,
            else if (holding == true && WorkStation.isClose == false && RecyclingBin.isClose == false && WashingBasin.isClose == false && WrappingStation.isClose == false && WrapGlass.isClose == false && GeneralWaste.isClose == false && CompostBin.isClose == false && NRBin.isClose == false && RBin.isClose == false)
            {
                //we will firstly enable the collider of the rubbish item back on 
                PlayerController.instance.objectHolding.GetComponent<Collider2D>().enabled = true;
                Debug.Log("You dropped up an item!");
                //then using translate, we make it seem like the player have put down the rubbish on the ground
                PlayerController.instance.objectHolding.transform.Translate(Vector3.down * 2);
                //then we clear the rubbish from the players “objectholding” child object so that the rubbish wont follow the player. Afterwards, play the animations for the player accordingly 
                PlayerController.instance.objectHolding.transform.SetParent(null);
                holding = false;
                PlayerController.instance.animator.SetBool("carry and walk", false);
                PlayerController.instance.animator.SetTrigger("drop");
                PlayerController.instance.animator.SetBool("walk", true);

                //once all the functions run, make the bool value of buttonPressed back to false
                InteractButton.instance.buttonPressed = false;

            }
            
        }
    }

    //delclaring another var with function inside to determine the gameobjects inside this gamobject list
    GameObject[] FindGameObjectsInLayer(int layer)
    {
        //finding all the gameobjects and putting it in the goArry
        var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        //declare another array for us to store the gameobjects inside
        var goList = new System.Collections.Generic.List<GameObject>();
        for (int i = 0; i < goArray.Length; i++)
        {
            //using for loop, go through all the gameobjects that are in goArray. If there are any objects that are in this array is in the chosen layer, it will add that specific gameobject into goList
            if (goArray[i].layer == layer)
            {
                goList.Add(goArray[i]);
            }
        } //return null if we cant find any gameobject in the chosen layer. If not, return the goList with the objects in the chosen layer
        if (goList.Count == 0)
        {
            return null;
        }
        return goList.ToArray();
    }

    //this function is to draw a red circle around the player with the same radius as pickupRadius. This way, the developer can easily visualise how long is pickUpRadius 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}
