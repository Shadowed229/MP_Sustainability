using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishConveyor : MonoBehaviour
{

    public Transform rubbish;
    //public Transform checkPoint;
    private float speed = 1;
    private bool occupied;
    public GameObject trashBag;
    public Transform spawner;
    private float offset;
    
    //public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner").transform;
        Instantiate(trashBag, spawner);
        occupied = false;
        //rubbish = GameObject.FindGameObjectWithTag("Rubbish").transform;
        //checkPoint = GameObject.FindGameObjectWithTag("checkpoint").transform;
        offset = 0.2f;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //rubbish = GameObject.FindGameObjectWithTag("Rubbish").transform;
        if (occupied == false)
        {
            Vector3 target = new Vector3(transform.position.x, transform.position.y + offset , transform.position.z);
            rubbish = GameObject.FindGameObjectWithTag("Rubbish").transform;
            rubbish.transform.position = Vector3.MoveTowards(rubbish.transform.position, target, Time.deltaTime * speed);
        }
            
        
        
    }
    private void FixedUpdate()
    {
        rubbish = GameObject.FindGameObjectWithTag("Rubbish").transform;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Rubbish"))
        {
            Debug.Log("Rubbish has Entered!");
            occupied = true;
        }
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Rubbish"))
        {
            occupied = false;

            Instantiate(trashBag, spawner);
            Debug.Log("Rubbish has spawned!");
            
        }

    }


}
