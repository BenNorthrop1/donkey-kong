using UnityEngine;
namespace Player
{
    public class StandingState : State
    {
        private float horizontalInput;

        // constructor
        public StandingState(PlayerScript player, StateMachine sm) : base(player, sm)
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
            if(Mathf.Abs(horizontalInput)> Mathf.Epsilon)
            {
                sm.ChangeState(player.movingState);
            }


            if(Input.GetKey(KeyCode.Space) && Mathf.Abs(horizontalInput)< Mathf.Epsilon)
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