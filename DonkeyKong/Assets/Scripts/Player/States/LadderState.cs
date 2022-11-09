using UnityEngine;

namespace Player
{
    public class LadderState : State
    {
        private float verticalInput;

        // constructor
        public LadderState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("climb ladder");
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

            
           
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            Vector2 direction;

            player.playerAnimator.CrossFade(player.mario_Ladder, 0 , 0);

            direction.y = Input.GetAxis("Vertical") * player.playerSpeed;

        
        }
    }
}
