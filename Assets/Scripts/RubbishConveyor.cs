using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishConveyor : MonoBehaviour
{

    public Transform rubbish;
    //public Transform checkPoint;
    private float speed = 4;
    public GameObject trashBag;
    public GameObject plasticTrash;
    public Transform spawner;
    private float offset;
    public static float maxRubbish;
    public int spawnTime = 3;

    //public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        maxRubbish = 0;
        spawner = GameObject.FindGameObjectWithTag("Spawner").transform;
        //Instantiate(trashBag, spawner);

        //rubbish = GameObject.FindGameObjectWithTag("Rubbish").transform;
        //checkPoint = GameObject.FindGameObjectWithTag("checkpoint").transform;
        offset = 0.2f;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(maxRubbish < 3)
        {
            Invoke("Spawn",spawnTime);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Rubbish"))
        {
            Debug.Log("Rubbish has Entered!");

        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Rubbish"))
        {

            Instantiate(trashBag, spawner);
            Debug.Log("Rubbish has spawned!");
            
        }

    }

    void Spawn()
    {
        if (maxRubbish < 3)
        {
            
            int whichrubbish = Random.Range(0, 2);
            if(whichrubbish == 0)
            {
                Instantiate(trashBag, spawner);
                maxRubbish = maxRubbish + 1;
                whichrubbish = Random.Range(0, 2);
            }
            else if (whichrubbish == 1)
            {
                Instantiate(plasticTrash, spawner);
                maxRubbish = maxRubbish + 1;
                whichrubbish = Random.Range(0, 2);
            }
            
        }
        
    }


}
