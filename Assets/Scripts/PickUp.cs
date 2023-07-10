using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform rubbishpos;
    public GameObject trashBag;
    public GameObject rubbish;
    public Transform ItemHolder;
    private bool holding;
    // Start is called before the first frame update
    void Start()
    {
        holding = false;
    }
    private void FixedUpdate()
    {
        rubbishpos = GameObject.FindGameObjectWithTag("Rubbish").transform;
        rubbish = GameObject.FindGameObjectWithTag("Rubbish");
    }

    // Update is called once per frame
    void Update()
    {
        if (rubbish != null)
        {
            float distancebetween = Vector3.Distance(transform.position, rubbish.transform.position);
            if (distancebetween < 3)
            {
                if (Input.GetButtonDown("Pickup") && holding == false)
                {
                    Vector3 target = new Vector3(100, 0, 0);
                    rubbishpos.transform.position = target;
                    RubbishConveyor.maxRubbish -= 1;
                    Destroy(rubbish);
                    Instantiate(trashBag, ItemHolder);
                    holding = true;
                }
            }
        }
        
        
        
    }
}
