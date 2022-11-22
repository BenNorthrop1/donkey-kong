using UnityEngine;
namespace Player
{
    public class StandingState : State
    {


        // constructor
        public StandingState(PlayerScript player, StateMachine sm) : base(player, sm)
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


            if(Mathf.Abs(player.horizontalInput)> Mathf.Epsilon)
            {
                sm.ChangeState(player.movingState);
            }

            if(player.CanClimb() == true && player.verticalInput != 0)
            {
                sm.ChangeState(player.ladderState);
            }


            if(player.jumpReady == true && Mathf.Abs(player.horizontalInput)< Mathf.Epsilon && player.IsGrounded())
            {
                sm.ChangeState(player.jumpingState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            player.playerAnimator.CrossFade(player.mario_Idle, 0 , 0);
            player.playerRigidbody.velocity = Vector2.zero;
        }
    }
}