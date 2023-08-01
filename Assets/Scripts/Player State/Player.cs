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
    public SpriteRenderer sr;
    public Animator anim;

    public bool holding;

    public Transform itemHolder;
    public GameObject objectHolding;
    private Collider2D[] itemColliders;
    public GameObject closestObject;
    public float pickupRadius = 1f;
    public LayerMask pickupLayer;
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
        activeMoveSpeed = moveSpeed;

        moveInput.x = UIController.instance.movementAmount.x; //using unity input system to get the value of x (right: 1, Left: -1)
        moveInput.y = UIController.instance.movementAmount.y; //using unity input system to get the value of y (up: 1, down: -1)

        moveInput.Normalize(); //make the player movement more consistent by noramlizing all the distance 

        theRB.velocity = moveInput * activeMoveSpeed; //this is to set the speed(velocity) in the rididBody2D by doing vector2 value * moveSpeed(float)
        /*
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
        */
        if (moveInput.x < 0)
        {
            sr.flipX = true;
            //gameObject.transform.rotation.y + 180;
        }
        else if (moveInput.x > 0)
        {
            sr.flipX = false;
        }
        Debug.Log(activeMoveSpeed);

    }

    public void PickUp()
    {
        if (holding == false)
        {
            itemColliders = Physics2D.OverlapCircleAll(transform.position, pickupRadius, pickupLayer);

            if (itemColliders.Length >= 1)
            {
                // We create two temporary variables that exist only in the scope of this if statement...
                // Both are initialized in regards to the first element in the array...
                float shortestDistanceSoFar = Vector2.Distance(gameObject.transform.position, itemColliders[0].gameObject.transform.position);
                closestObject = itemColliders[0].gameObject;

                // We loop through each element of the array...
                for (int i = 0; i < itemColliders.Length; i++)
                {
                    // Using a temporary float variable that holds the calculated distance for each element...
                    float currentDistance = Vector2.Distance(gameObject.transform.position, itemColliders[i].gameObject.transform.position);

                    // We check if said distance is smaller than the shortest distance we have stored so far...
                    if (currentDistance < shortestDistanceSoFar)
                    {
                        // If that's true, we make that element the closest object and set the new shortest distance as the current one...
                        closestObject = itemColliders[i].gameObject;
                        shortestDistanceSoFar = currentDistance;

                    }
                }
                PlayerController.instance.objectHolding = closestObject;
                Debug.Log("You picked up an item!");
                PlayerController.instance.objectHolding.transform.position = PlayerController.instance.itemHolder.position;
                PlayerController.instance.objectHolding.transform.SetParent(PlayerController.instance.itemHolder.transform);
                holding = true;
            }
        }
        else if (holding == true && WorkStation.isClose == false && TrashPile.instance.isClose == false && RecyclingBin.isClose == false && WashingBasin.isClose == false)
        {
            Debug.Log("You dropped up an item!");
            PlayerController.instance.objectHolding.transform.Translate(Vector3.down * 2);
            PlayerController.instance.objectHolding.transform.SetParent(null);
            holding = false;
        }
    }
    private void Awake()
    {
        moveSpeed = 6;
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
