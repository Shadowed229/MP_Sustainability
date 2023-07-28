using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -30f);
    private float cameraSpeed = 0.2f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private Transform target;

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, cameraSpeed);
    }
}
