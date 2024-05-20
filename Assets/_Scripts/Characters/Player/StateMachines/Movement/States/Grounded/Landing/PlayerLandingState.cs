using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RECON.Gameplay.Player.Movement
{
    public class PlayerLandingState : PlayerGroundedState
    {
        public PlayerLandingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            StartAnimation(animationData.LandingParaneterHash);
        }

        public override void Exit()
        {
            base.Exit();

            StopAnimation(animationData.LandingParaneterHash);
        }

        #region Inputy
        protected override void OnMoveCanceled(InputAction.CallbackContext context)
        {
            base.OnMoveCanceled(context);
        }
        #endregion
    }
}
