using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RECON.Gameplay.Player.Movement
{
    public class PlayerStoppingState : PlayerGroundedState
    {
        public PlayerStoppingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        #region State

        public override void Enter()
        {
            stateMachine.ReusableData.MovementSpeedModifier = 0f;

            StartAnimation(animationData.StoppingParaneterHash);

            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();

            StopAnimation(animationData.StoppingParaneterHash);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            RotateTowardsTargetRotation();

            if (!IsMovingHorizontally())
            {
                stateMachine.ChangeState(stateMachine.IdlingState);
                return;
            }

            DecelerateHorizontally();
        }

        public override void OnAnimationTransitionEvent()
        {
            stateMachine.ChangeState(stateMachine.IdlingState);
        }

        #endregion

        #region Reusable
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

        #endregion

        #region Input

        protected void OnMovementStarted(InputAction.CallbackContext context)
        {
            OnMove();
        }

        #endregion


    }
}
