using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    private Vector3 offset = new Vector3(0f, 0f, -30f);
    private float cameraSpeed = 0.2f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 originalPos;

    [SerializeField]
    private Transform target;

   
    private void Awake()
    {
        instance = this;
        
    }

    private void Start()
    {
        originalPos = transform.position;
    }
    void Update()
    {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, cameraSpeed);
            Debug.Log(Vector2.Distance(originalPos, gameObject.transform.position));
    }
    public Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }
}
