using UnityEngine.InputSystem;

namespace RECON.Gameplay.Player.Movement
{
    public class PlayerWalkingState : PlayerMovingState
    {
        public PlayerWalkingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        #region State
        public override void Enter()
        {
            base.Enter();

            StartAnimation(animationData.WalkParaneterHash);

            stateMachine.ReusableData.MovementSpeedModifier = base.groundData.WalkData.SpeedModifier;

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JunpData.WeakForce;
        }

        public override void Exit()
        {
            base.Exit();

            StopAnimation(animationData.WalkParaneterHash);
        }

        #endregion


        #region Input 

        protected override void OnMoveCanceled(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.WalkStoppingState);
        }

        protected override void OnWalkToggleStarted(InputAction.CallbackContext context)
        {
            base.OnWalkToggleStarted(context);

            stateMachine.ChangeState(stateMachine.RunningState);
        }

        #endregion
    }
}

