using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    //private Vector3 offset = new Vector3(0f, 0f, -30f);
    //private float cameraSpeed = 0.2f;
    //private Vector3 velocity = Vector3.zero;
    //private Vector3 originalPos;

    [SerializeField]
    private Transform target;

   
    private void Awake()
    {
        instance = this;
        
    }

    private void Start()
    {
        //originalPos = transform.position;
    }
    void Update()
    {
            //Vector3 targetPosition = target.position + offset;
            transform.position = new Vector3(Mathf.Clamp(target.position.x,-4.5f,4.5f), Mathf.Clamp(target.position.y,-3,8), target.position.x - 30);
            //Debug.Log(Vector2.Distance(originalPos, gameObject.transform.position));
    }
    public Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }
}
