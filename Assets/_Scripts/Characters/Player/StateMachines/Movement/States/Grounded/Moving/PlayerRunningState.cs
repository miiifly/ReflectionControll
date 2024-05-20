using UnityEngine;
using UnityEngine.InputSystem;

namespace RECON.Gameplay.Player.Movement
{
    public class PlayerRunningState : PlayerMovingState
    {

        private float _startTime;
        public PlayerRunningState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        #region State
        public override void Enter()
        {
            stateMachine.ReusableData.MovementSpeedModifier = base.groundData.RunData.SpeedModifier;

            base.Enter();

            StartAnimation(animationData.RunParaneterHash);

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JunpData.MediumForce;

            _startTime = Time.time;
        }

        public override void Exit()
        {
            base.Exit();
            StopAnimation(animationData.RunParaneterHash);
        }

        public override void Update()
        {
            base.Update();

            if (!stateMachine.ReusableData.ShouldWalk)
            {
                return;
            }

            StopRunning();
        }

        private void StopRunning()
        {
            if (stateMachine.ReusableData.MovementInput == Vector2.zero)
            {
                stateMachine.ChangeState(stateMachine.IdlingState);

                return;
            }

            stateMachine.ChangeState(stateMachine.WalkingState);
        }
        #endregion


        #region Input
        protected override void OnMoveCanceled(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.RunStoppingState);
        }

        protected override void OnWalkToggleStarted(InputAction.CallbackContext context)
        {
            base.OnWalkToggleStarted(context);

            stateMachine.ChangeState(stateMachine.WalkingState);
        }

        #endregion
    }
}
