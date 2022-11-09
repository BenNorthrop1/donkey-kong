using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

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



        //This calls all the components needed to make the player work  
        [Header("Player Components")]
        public Rigidbody2D playerRigidbody;
        public SpriteRenderer playerSprite;
        public Animator playerAnimator;


        
        //This sets the values for the movement
        [Header("Player Values")]
        public float playerSpeed;
        public float jumpHeight;
        public float jumpForwardBoost;
        public bool isJumping;



        //This sets the ground layers
        [Header("Layers")]
        public LayerMask groundMask;
        public LayerMask ladderMask;




        //This allows the player to changes the animations played in inspector
        [Header("Animations")]
        public string mario_Idle = "mario_Idle";
        public string mario_Walk = "mario_Walk";
        public string mario_Jump = "mario_Jump";
        public string mario_Falling = "mario_Falling";
        public string mario_Ladder = "mario_Ladder";
        


        //This defines the colliders so I can do things like crouching
        [Header("Player Colliders")]
        public BoxCollider2D playerCollider;



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

            playerRigidbody = GetComponent<Rigidbody2D>();
            playerSprite = GetComponent<SpriteRenderer>();
            playerAnimator = GetComponent<Animator>();

            
            // initialise the statemachine with the default state
            sm.Init(standingState);
        }

        public void Update()
        {
            sm.CurrentState.HandleInput();
            sm.CurrentState.LogicUpdate();


        }

        public bool ReadSpaceBar()
        {
            if( Input.GetKey("space"))
            {
                return true;
            }
            return false;

        }

        public bool IsGrounded()
        {
            return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f , groundMask);
        
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