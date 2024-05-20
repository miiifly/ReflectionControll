using RECON.Gameplay.Player;
using RECON.Gameplay.Player.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RECON.Gameplay.Player.Movement
{
    public class PlayerHardLandingState : PlayerLandingState
    {
        public PlayerHardLandingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        #region State
        public override void Enter()
        {
            stateMachine.ReusableData.MovementSpeedModifier = 0f;

            base.Enter();

            StartAnimation(animationData.HardLandParaneterHash);

            stateMachine.Player.Input.PlayerActions.Movement.Disable();


            ResetVelocity();
        }


        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (!IsMovingHorizontally())
            {
                return;
            }

            ResetVelocity();
        }

        public override void Exit()
        {
            base.Exit();
            
            StopAnimation(animationData.HardLandParaneterHash);

            stateMachine.Player.Input.PlayerActions.Movement.Enable();
        }

        public override void OnAnimationExitEvent()
        {
            base.OnAnimationExitEvent();

            stateMachine.Player.Input.PlayerActions.Movement.Enable();
        }

        public override void OnAnimationTransitionEvent()
        {
            stateMachine.ChangeState(stateMachine.IdlingState);
        }

        protected override void AddInputActionsCallbacks()
        {
            base.AddInputActionsCallbacks();
            stateMachine.Player.Input.PlayerActions.Movement.started += OnMovementStarted;
        }

        protected override void RemoveInputActionsCallbacks()
        {
            base.RemoveInputActionsCallbacks();

            stateMachine.Player.Input.PlayerActions.Movement.started -= OnMovementStarted;
        }

        protected override void OnMove()
        {
            if(stateMachine.ReusableData.ShouldWalk)
            {
                return;
            }

            stateMachine.ChangeState(stateMachine.RunningState);
        }
        #endregion

        protected override void OnJumpStarted(InputAction.CallbackContext context)
        {
            
        }

        private void OnMovementStarted(InputAction.CallbackContext context)
        {
            OnMove();
        }
    }
}
