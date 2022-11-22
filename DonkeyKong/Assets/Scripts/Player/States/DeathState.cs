using UnityEngine;
using UnityEngine.SceneManagement;
namespace Player
{
    public class DeathState : State
    {


        // constructor
        public DeathState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.playerRigidbody.isKinematic = true;

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
            if(Input.touchCount == 1)
            {
                if(player.isDead && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
                }
            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            player.playerRigidbody.velocity = Vector2.zero;
            player.playerAnimator.CrossFade(player.mario_Death, 0, 0);

        }



    }

    
}