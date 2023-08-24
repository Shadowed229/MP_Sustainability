using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    private Vector3 offset = new Vector3(0f, 0f, -30f);
    private float cameraSpeed = 0.2f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private Transform target;

   
    private void Awake()
    {
        instance = this;
    }
    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, cameraSpeed);

       
    }
    public Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }
}
