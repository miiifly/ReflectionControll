using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RECON.Gameplay.Player.Movement
{
    public class PlayerRunStoppingState : PlayerStoppingState
    {
        public PlayerRunStoppingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        #region State

        protected override void OnMoveCanceled(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.WalkStoppingState);
        }

        public override void Enter()
        {

            base.Enter();

            StartAnimation(animationData.HardStopParaneterHash);

            stateMachine.ReusableData.MovementDecelerationForce = groundData.StopData.RunDecelerationForce;

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JunpData.MediumForce;
        }

        public override void Exit()
        {
            base.Exit();

            StopAnimation(animationData.HardStopParaneterHash);
        }
        #endregion

    }
}
