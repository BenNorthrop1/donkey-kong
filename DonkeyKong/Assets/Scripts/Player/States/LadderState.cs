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
            player.playerCollider.isTrigger = true;
            player.playerRigidbody.isKinematic = true;
            Debug.Log("climb ladder");
        }

        public override void Exit()
        {
            base.Exit();
            player.playerCollider.isTrigger = false;
            player.playerRigidbody.isKinematic = false;
        }

        public override void HandleInput()
        {
            base.HandleInput();
            
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            verticalInput = Input.GetAxis("Vertical");

            if(player.CanClimb() == false || Input.GetKey(KeyCode.Space))
            {
                sm.ChangeState(player.standingState);
            }
            
           
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();


            player.playerAnimator.CrossFade(player.mario_Ladder, 0 , 0);

            
            Vector2 velocity = player.playerRigidbody.velocity;
            velocity.x = 0;

            velocity.y = verticalInput * player.ladderClimbSpeed;



            player.playerRigidbody.velocity = velocity; 

        
        }
    }
}
