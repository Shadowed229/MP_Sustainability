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
    private float maxStamina = 100f;
    private float staminaFallRate = 50f;
    private float staminaChargeRate = 25f;
    private bool CanDash()
    {
        if(stats.stamina <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        stats.moveSpeed = 6f;
        stats.dashSpeed = 10f;
        stats.stamina = maxStamina;
        activeMoveSpeed = stats.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        CanDash();
        Movement();
        Dash();
        
    }

    void Movement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal"); //using unity input system to get the value of x (right: 1, Left: -1)
        moveInput.y = Input.GetAxisRaw("Vertical"); //using unity input system to get the value of y (up: 1, down: -1)

        moveInput.Normalize(); //make the player movement more consistent by noramlizing all the distance (can imagine the distance to be in a circle)

       
        theRB.velocity = moveInput * activeMoveSpeed; //this is to set the speed(velocity) in the rididBody2D by doing vector2 value * moveSpeed(float)
        Debug.Log(maxStamina);
    }

    void Dash()
    {
        // Dash
        if (Input.GetKey(KeyCode.LeftShift) && CanDash() == true)
        {
            activeMoveSpeed = stats.dashSpeed;
            stats.stamina -= Time.deltaTime * staminaChargeRate;
        }
        else
        {
            activeMoveSpeed = stats.moveSpeed;
            if (stats.stamina <= maxStamina)
            {
                stats.stamina += Time.deltaTime * staminaFallRate;
                if (stats.stamina >= maxStamina)
                {
                    stats.stamina = maxStamina;
                }
            }

        }
    }

}
