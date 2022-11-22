using UnityEngine;
namespace Player
{
    public class MovingState : State
    {


        // constructor
        public MovingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.horizontalInput = 0f;
            player.verticalInput = 0f;
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


            if(Mathf.Abs(player.horizontalInput)< Mathf.Epsilon)
            {
                sm.ChangeState(player.standingState);
            }

            
            if(player.CanClimb() == true && player.verticalInput != 0)
            {
                sm.ChangeState(player.ladderState);
            }


            if(player.jumpReady == true && Mathf.Abs(player.horizontalInput)> Mathf.Epsilon && player.IsGrounded())
            {
                sm.ChangeState(player.movingJumpState);
            }

            if(player.horizontalInput > 0f)
            {
                player.playerSprite.flipX = true;
            }
            else if(player.horizontalInput < 0f)
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
            velocity.x = player.horizontalInput * player.playerSpeed;

            player.playerRigidbody.velocity = velocity; 

        }
    }
}