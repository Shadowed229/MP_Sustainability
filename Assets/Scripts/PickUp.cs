using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    /*
    private Transform trashpile;
    public Transform Workstation;
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
        if (WorkStation.occupied == true)
        {
            float distancebetweenWorkstation = Vector3.Distance(transform.position, Workstation.transform.position);
            GameObject egg = GameObject.FindGameObjectWithTag("Egg");
            GameObject can = GameObject.FindGameObjectWithTag("Can");
            GameObject plasticBottle = GameObject.FindGameObjectWithTag("PlasticBottle");
            if (holding == false)
            {
                if (distancebetweenWorkstation < 2)
                {
                    
                }
            }
        }      
    }
    */
    public static PickUp instance;
    public float pickupRadius = 1f;
    public LayerMask pickupLayer;

    public Transform ItemHolder;
    public bool holding;
    public bool trashholding;
    //private Collider2D itemCollider;
    private Collider2D[] itemColliders;
    GameObject closestObject;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Pickup"))
        {
            if(holding == false)
            {
                itemColliders = Physics2D.OverlapCircleAll(transform.position, pickupRadius, pickupLayer);

                if (itemColliders != null)
                {
                    // We create two temporary variables that exist only in the scope of this if statement...
                    // Both are initialized in regards to the first element in the array...
                    float shortestDistanceSoFar = Vector2.Distance(this.gameObject.transform.position, itemColliders[0].gameObject.transform.position);
                    closestObject = itemColliders[0].gameObject;

                    // We loop through each element of the array...
                    for (int i = 0; i < itemColliders.Length; i++)
                    {
                        // Using a temporary float variable that holds the calculated distance for each element...
                        float currentDistance = Vector2.Distance(this.gameObject.transform.position, itemColliders[i].gameObject.transform.position);

                        // We check if said distance is smaller than the shortest distance we have stored so far...
                        if (currentDistance < shortestDistanceSoFar)
                        {
                            // If that's true, we make that element the closest object and set the new shortest distance as the current one...
                            closestObject = itemColliders[i].gameObject;
                            shortestDistanceSoFar = currentDistance;
                        }
                    }

                    Debug.Log("You picked up an item!");
                    closestObject.transform.position = ItemHolder.position;
                    closestObject.transform.SetParent(ItemHolder.transform);
                    holding = true;
                }
            }
            else if (holding == true)
            {
                Debug.Log("You dropped up an item!");
                closestObject.transform.position = ItemHolder.position;
                closestObject.transform.SetParent(null);
                holding = false;


            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}
