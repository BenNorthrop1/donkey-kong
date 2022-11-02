using UnityEngine;
namespace Player
{
    public class MovingState : State
    {
        private float horizontalInput;

        // constructor
        public MovingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            horizontalInput = 0f;
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
            if(Mathf.Abs(horizontalInput)< Mathf.Epsilon)
            {
                sm.ChangeState(player.standingState);
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