using UnityEngine;

namespace Player
{
    public class JumpingState : State
    {
        

        // constructor
        public JumpingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.isJumping = true;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();

            float horizontalInput = player.joystick.Horizontal;
            float verticalInput = player.joystick.Vertical;
            
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            
            if(player.isJumping == true && player.IsGrounded() == false)
            {
                sm.ChangeState(player.fallingState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            player.playerAnimator.CrossFade(player.mario_Jump, 0 , 0);
            //player.playerRigidbody.AddForce(Vector2.up * player.jumpHeight, ForceMode2D.Impulse);
            player.playerRigidbody.velocity = new Vector2(player.playerRigidbody.velocity.x  , player.jumpHeight);
        }
    }
}
