using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform rubbishpos;
    public GameObject trashBag;
    public GameObject rubbish;
    public Transform ItemHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        rubbishpos = GameObject.FindGameObjectWithTag("Rubbish").transform;
        rubbish = GameObject.FindGameObjectWithTag("Rubbish");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pickup"))
        {
            Vector3 target = new Vector3(100, 0, 0);
            rubbishpos.transform.position = target;
            Destroy(rubbish);
            Instantiate(trashBag, ItemHolder);
        }
    }
}
