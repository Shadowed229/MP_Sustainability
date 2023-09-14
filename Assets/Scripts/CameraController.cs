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
    private Transform target; //(To store the transform of the player to follow)


    private void Awake()
    {
        instance = this;
        
    }

    private void Start()
    {
        //originalPos = transform.position;
    }
    void Update() //Sets the max of the camera movement to a certain value which makes it stop moving when the character moves to the edge of the game
    {
        //Vector3 targetPosition = target.position + offset; 
        //Sets the max of the camera movement to a certain value which makes it stop moving when the character moves to the edge of the game
        transform.position = new Vector3(Mathf.Clamp(target.position.x,-4.5f,4.5f), Mathf.Clamp(target.position.y,-3,8), target.position.x - 30);
            //Debug.Log(Vector2.Distance(originalPos, gameObject.transform.position));
    }
    //commented codes are the previous function used to track the player position
    //new function is using mathf to declare the max and min position of x and y value of the distance main camera can travel so that the camera don’t extrude the wall

    public Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }
}
