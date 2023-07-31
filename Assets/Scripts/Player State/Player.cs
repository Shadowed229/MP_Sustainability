using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 moveInput;

    public StateMachine sm;
    public IdleState idle;

    public Rigidbody2D theRB;
    AudioSource audioSource;
    public float moveSpeed;
    private float activeMoveSpeed;
    private SpriteRenderer sr;
    public Animator anim;

    public int walking => Animator.StringToHash("Walking");

    // Start is called before the first frame update
    public void SetAnimationBool(int param, bool value)
    {
        anim.SetBool(param, value);
    }

    public void TriggerAnimation(int param)
    {
        anim.SetTrigger(param);
    }

    public void Movement()
    {
        moveInput.x = UIController.instance.movementAmount.x; //using unity input system to get the value of x (right: 1, Left: -1)
        moveInput.y = UIController.instance.movementAmount.y; //using unity input system to get the value of y (up: 1, down: -1)

        moveInput.Normalize(); //make the player movement more consistent by noramlizing all the distance 

        theRB.velocity = moveInput * activeMoveSpeed; //this is to set the speed(velocity) in the rididBody2D by doing vector2 value * moveSpeed(float)
        if (theRB.velocity.x != 0 || theRB.velocity.y != 0)
        {
            if (!audioSource.isPlaying && LevelManager.instance.isPaused == false && LevelManager.instance.isGameOver == false)
            {
                audioSource.Play();

            }
            SetAnimationBool(walking, true);
        }
        else
        {
            SetAnimationBool(walking, false);
            audioSource.Stop();
        }

        if (moveInput.x < 0)
        {
            sr.flipX = true;
            //gameObject.transform.rotation.y + 180;
        }
        else if (moveInput.x > 0)
        {
            sr.flipX = false;
        }

    }

    private void Start()
    {
        sm = new StateMachine();
        
        idle = new IdleState(this, sm);
        /*
        ducking = new DuckingState(this, movementSM);
        jumping = new JumpingState(this, movementSM);
        drawing = new DrawState(this, movementSM); // instantiating new state for fsm
        swinging = new SwingState(this, movementSM); // instantiating new state for fsm
        sheathing = new SheathState(this, movementSM); // instantiating new state for fsm
        */

        sm.Initialize(idle); // standing state is the default state
        
    }

    private void Update()
    {
        sm.CurrentState.HandleInput();

        sm.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        sm.CurrentState.PhysicsUpdate();
    }
}
