using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB; //"the rigid body"
    private Vector2 moveInput; //can not edit in the unity editor
    public float moveSpeed = 6f;
    public float dashSpeed = 10f;
    private float activeMoveSpeed;

    private bool CanDash()
    {
        if(dashCounter <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private float dashCounter = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        CanDash();
        Movement();
        
    }

    void Movement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal"); //using unity input system to get the value of x (right: 1, Left: -1)
        moveInput.y = Input.GetAxisRaw("Vertical"); //using unity input system to get the value of y (up: 1, down: -1)

        moveInput.Normalize(); //make the player movement more consistent by noramlizing all the distance (can imagine the distance to be in a circle)

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            activeMoveSpeed = dashSpeed;
            dashCounter -= Time.deltaTime * 100;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            activeMoveSpeed = moveSpeed;
            dashCounter += Time.deltaTime * 50;
        }

        //transform.position += new Vector3(moveInput.x, moveInput.y, 0) * Time.deltaTime * moveSpeed;

        theRB.velocity = moveInput * activeMoveSpeed; //this is to set the speed(velocity) in the rididBody2D by doing vector2 value * moveSpeed(float)
        Debug.Log(dashCounter);
    }

}
