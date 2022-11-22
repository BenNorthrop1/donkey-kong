using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

namespace Player
{


    public class PlayerScript : MonoBehaviour
    {


        //This calls all the states so they can be used
        [Header("Player States")]
        public StateMachine sm;

        [HideInInspector]
        public StandingState standingState;

        [HideInInspector]
        public MovingState movingState;

        [HideInInspector]
        public JumpingState jumpingState;

        [HideInInspector]
        public MovingJumpState movingJumpState;

        [HideInInspector]
        public FallingState fallingState;

        [HideInInspector]
        public LadderState ladderState;

        [HideInInspector]
        public DeathState deathState;
        
        //This calls all the components needed to make the player work  
        [Header("Player Components")]
        public Rigidbody2D playerRigidbody;
        public SpriteRenderer playerSprite;
        public Animator playerAnimator;
        public BoxCollider2D playerCollider;
        public Joystick joystick;

        public LevelEnd levelEnd;

        //This sets the values for the movement
        [Header("Player Values")]
        public float playerSpeed;
        public float ladderClimbSpeed;
        public float jumpHeight;
        public float jumpForwardBoost;


        public bool isJumping;
        public bool jumpReady;
        public bool isDead;

        //This sets the ground layers
        [Header("Layers")]
        public LayerMask groundMask;
        public LayerMask ladderMask;
        public LayerMask barrelMask;


        //This allows the player to changes the animations played in inspector
        [Header("Animations")]
        public string mario_Idle = "mario_Idle";
        public string mario_Walk = "mario_Walk";
        public string mario_Jump = "mario_Jump";
        public string mario_Death = "mario_Death";
        public string mario_Ladder = "mario_Ladder";

        public float horizontalInput;
        public float verticalInput;
    

        void Start()
        {
            sm = gameObject.AddComponent<StateMachine>();

            // set up the variables for your new states here
            standingState = new StandingState(this, sm);
            movingState = new MovingState(this, sm);
            jumpingState = new JumpingState(this, sm);
            fallingState = new FallingState(this, sm);
            movingJumpState = new MovingJumpState(this, sm);
            ladderState = new LadderState(this, sm);
            deathState = new DeathState(this, sm);
            

            playerRigidbody = GetComponent<Rigidbody2D>();
            playerSprite = GetComponent<SpriteRenderer>();
            playerAnimator = GetComponent<Animator>();

            playerRigidbody.isKinematic = false;

            levelEnd = FindObjectOfType<LevelEnd>();
            
            // initialise the statemachine with the default state
            sm.Init(standingState);

            jumpReady = false;
            isDead = false;
        }

        public void Update()
        {
            sm.CurrentState.HandleInput();
            sm.CurrentState.LogicUpdate();
            


            if(Input.touchCount == 1)
            {
                if(levelEnd.isEnd && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
                    playerRigidbody.velocity = Vector2.zero;          
                    playerRigidbody.isKinematic = true;          
                }
            }

            horizontalInput = joystick.Horizontal;
            verticalInput = joystick.Vertical;

            if(Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size * 1.2f, 0f, transform.position, .1f, barrelMask))
            {
                isDead = true;
                sm.ChangeState(deathState);
            }



        }

        public void HandleJumpReady()
        {
            jumpReady = true;
            print("Jump");
        }

        public void HandleJumpCancel()
        {
            jumpReady = false;
            print("No Jump");
        }


        public bool IsGrounded()
        {  
            return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f, groundMask);
        }

        public bool CanClimb()
        {
            return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f , ladderMask);
        }



     

        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }
    }

}