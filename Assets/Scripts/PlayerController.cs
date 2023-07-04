using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB; // rigid body component attached in player
    private Vector2 moveInput; // to get vecotr2 value of the player object

    [Serializable]
    public struct PlayerStats
    {
        public float moveSpeed;
        public float dashSpeed;
        public float stamina;
    }

    [SerializeField]
    private PlayerStats stats;

    private float activeMoveSpeed;

    [HideInInspector]
    public float dashLength = 0.5f, dashCooldown = 1f;
    [HideInInspector]
    public float dashCounter;
    private float dashCoolCounter;

    // Start is called before the first frame update
    void Start()
    {
        stats.moveSpeed = 6f;
        stats.dashSpeed = 20f;
        activeMoveSpeed = stats.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Dash();
        Debug.Log(stats.stamina);
    }

    void Movement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal"); //using unity input system to get the value of x (right: 1, Left: -1)
        moveInput.y = Input.GetAxisRaw("Vertical"); //using unity input system to get the value of y (up: 1, down: -1)

        moveInput.Normalize(); //make the player movement more consistent by noramlizing all the distance (can imagine the distance to be in a circle)

        theRB.velocity = moveInput * activeMoveSpeed; //this is to set the speed(velocity) in the rididBody2D by doing vector2 value * moveSpeed(float)
    }

    void Dash()
    {
        //-------player dash-------
        if (Input.GetKeyDown(KeyCode.Space)) //when player press space
        {
            
            if (dashCoolCounter <= 0 && dashCounter <= 0) ///player dashing
            {
                activeMoveSpeed = stats.dashSpeed;
                dashCounter = dashLength; //declaring how long the dash speed will last
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime*2; //minusing off deltaTime(sescond) from the duration of dash speed
            if (dashCounter <= 0) //when dashCounter turns to 0, the player will go back to normal speed
            {
                activeMoveSpeed = stats.moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime; //minusing off deltaTime(per second) from the duration of dashCooldown
        }
    }

    

}
