using UnityEngine;

namespace RECON.Gameplay.Player.Movement
{
    public class PlayerAirbornState : PlayerMovementState
    {
        public PlayerAirbornState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        #region State
        public override void Enter()
        {
            base.Enter();

            StartAnimation(animationData.AirborneParaneterHash);
        }

        public override void Exit()
        {
            base.Exit();

            StopAnimation(animationData.AirborneParaneterHash);
        }

        #endregion

        #region Reusable
        protected override void OnContactWithGround(Collider collider)
        {
            base.OnContactWithGround(collider);

            Debug.LogError("Contatc with ground");
            stateMachine.ChangeState(stateMachine.LightLandingState);
        }
        #endregion
    }
}
