using UnityEngine;
namespace Player
{
    public class MovingState : State
    {
        private float horizontalInput;
        private float verticalInput;

        // constructor
        public MovingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            horizontalInput = 0f;
            verticalInput = 0f;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            if(Mathf.Abs(horizontalInput)< Mathf.Epsilon)
            {
                sm.ChangeState(player.standingState);
            }

            if(player.CanClimb() == true && Mathf.Abs(verticalInput)> Mathf.Epsilon)
            {
                sm.ChangeState(player.ladderState);
            }


            if(Input.GetKey(KeyCode.Space) && Mathf.Abs(horizontalInput)> Mathf.Epsilon)
            {
                sm.ChangeState(player.movingJumpState);
            }

            if(horizontalInput > 0f)
            {
                player.playerSprite.flipX = true;
            }
            else if(horizontalInput < 0f)
            {
                player.playerSprite.flipX = false;
            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            player.playerAnimator.CrossFade(player.mario_Walk, 0 , 0);

            Vector2 velocity = player.playerRigidbody.velocity;
            velocity.x = 0;
            velocity.x = horizontalInput * player.playerSpeed;

            player.playerRigidbody.velocity = velocity; 

        }
    }
}