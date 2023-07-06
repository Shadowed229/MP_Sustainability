using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishConveyor : MonoBehaviour
{

    public Transform checkpoint;
    private float speed = 1;
    //public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(checkpoint.transform.position.x, checkpoint.transform.position.y, checkpoint.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }

    
}
