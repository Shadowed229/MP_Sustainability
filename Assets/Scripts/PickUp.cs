using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Transform rubbishpos;
    private Transform plasticpos;
    public GameObject trashBagPrefab;
    private GameObject rubbish;
    private GameObject plastic;
    public GameObject plasticPrefab;
    public Transform ItemHolder;
    public static bool holding;
    public static bool plastichold;
    public static bool trashhold;
    // Start is called before the first frame update
    void Start()
    {
        holding = false;
        plastichold = false;
        trashhold = false;
    }
    private void FixedUpdate()
    {
        rubbishpos = GameObject.FindGameObjectWithTag("Rubbish").transform;
        rubbish = GameObject.FindGameObjectWithTag("Rubbish");
        plastic = GameObject.FindGameObjectWithTag("Plastic");
        plasticpos = GameObject.FindGameObjectWithTag("Plastic").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (rubbish != null)
        {
            float distancebetweenRubbish = Vector3.Distance(transform.position, rubbish.transform.position);
            float distancebetweenPlastic = Vector3.Distance(transform.position, plastic.transform.position);
            if (distancebetweenRubbish < 2)
            {
                if (Input.GetButtonDown("Pickup") && holding == false )
                {
                    Vector3 target = new Vector3(100, 0, 0);
                    rubbishpos.transform.position = target;
                    RubbishConveyor.maxRubbish -= 1;
                    Destroy(rubbish);
                    Instantiate(trashBagPrefab, ItemHolder);
                    holding = true;
                    trashhold = true;
                }
            }
            if (distancebetweenPlastic < 2)
            {
                if (Input.GetButtonDown("Pickup") && holding == false)
                {
                    Vector3 target = new Vector3(100, 0, 0);
                    plasticpos.transform.position = target;
                    RubbishConveyor.maxRubbish -= 1;
                    Destroy(plastic);
                    Instantiate(plasticPrefab, ItemHolder);
                    holding = true;
                    plastichold = true;
                }
            }
        }
        
        
        
    }
}
