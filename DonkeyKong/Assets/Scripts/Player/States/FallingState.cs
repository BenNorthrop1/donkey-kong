using UnityEngine;

namespace Player
{
    public class FallingState : State
    {
        

        // constructor
        public FallingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
            player.isJumping = false;

        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(player.IsGrounded() == true)
            {
                sm.ChangeState(player.standingState);
            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            player.playerAnimator.CrossFade(player.mario_Falling, 0.1f, 0);
            
        }
    }
}
