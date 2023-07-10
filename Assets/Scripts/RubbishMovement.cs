using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishMovement : MonoBehaviour
{
    private float offset;
    private float speed = 4;
    private Transform checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        offset = 0.2f;
        checkpoint = GameObject.FindGameObjectWithTag("CheckPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distancebetween = Vector3.Distance(transform.position, checkpoint.transform.position);
        
        Vector3 target = new Vector3(checkpoint.transform.position.x, checkpoint.transform.position.y + offset, checkpoint.transform.position.z);
        if(distancebetween > 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        }
       
    }
}
