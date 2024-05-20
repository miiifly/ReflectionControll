using RECON.Gameplay.Data.Colliders;
using RECON.Gameplay.Player.Data;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RECON.Gameplay.Player.Movement
{
    public class PlayerGroundedState : PlayerMovementState
    {

        private SlopeData _slopeData;

        public PlayerGroundedState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
            _slopeData = stateMachine.Player.ColliderUtility.SlopeData;
        }

        #region State

        public override void Enter()
        {
            base.Enter();

            StartAnimation(animationData.GroundedParaneterHash);
        }

        public override void Exit()
        {
            base.Exit();

            StopAnimation(animationData.GroundedParaneterHash);
        }

        public override void FixedUpdate()
        {
            Float();
            base.FixedUpdate();
        }

        #endregion

        #region Main

        private void Float()
        {
            Vector3 capsuleColliderCenterInWorldSpace = stateMachine.Player.ColliderUtility.CapsuleColliderData.Collider.bounds.center;

            Ray downwardsRayFromCapsuleCenter = new Ray(capsuleColliderCenterInWorldSpace, Vector3.down);

            if (Physics.Raycast(downwardsRayFromCapsuleCenter, out RaycastHit hit, stateMachine.Player.ColliderUtility.SlopeData.FloatRayDistance, stateMachine.Player.LayersData.GroundLayer, QueryTriggerInteraction.Ignore))
            {
                float groundAngle = Vector3.Angle(hit.normal, -downwardsRayFromCapsuleCenter.direction);

                float slopeSpeedModifier = SetSlopeSpeedModifierOnAngle(groundAngle);

                if (slopeSpeedModifier == 0f)
                {
                    return;
                }

                float distanceToFloatingPoint = stateMachine.Player.ColliderUtility.CapsuleColliderData.ColliderInLocalSpace.y * stateMachine.Player.transform.localScale.y - hit.distance;

                if (distanceToFloatingPoint == 0f)
                {
                    return;
                }

                float amountToLift = distanceToFloatingPoint * stateMachine.Player.ColliderUtility.SlopeData.StepReachForce - GetPlayerVerticalVelocity().y;

                Vector3 liftForce = new Vector3(0f, amountToLift, 0f);

                stateMachine.Player.PlayerRigidbody.AddForce(liftForce, ForceMode.VelocityChange);
            }
        }

        private float SetSlopeSpeedModifierOnAngle(float angle)
        {
            float slopeSpeedModifier = groundData.SlopeSpeedAngles.Evaluate(angle);

            if (stateMachine.ReusableData.MovementOnSlopeSpeedModifier != slopeSpeedModifier)
            {
                stateMachine.ReusableData.MovementOnSlopeSpeedModifier = slopeSpeedModifier;
            }

            return slopeSpeedModifier;
        }

        private bool IsTherGroundUnderneath()
        {
            PlayerTriggerColliderData triggerColliderData = stateMachine.Player.ColliderUtility.TriggerColliderData;

            BoxCollider groundCheckCollider = stateMachine.Player.ColliderUtility.TriggerColliderData.GroundChekcCollider;

            Vector3 groundColliderCenterInWorldSpace = groundCheckCollider.bounds.center;

            Collider[] overlappedGroundColliders = Physics.OverlapBox(groundColliderCenterInWorldSpace, triggerColliderData.GroundCheckColliderVerticalExtents, groundCheckCollider.transform.rotation, stateMachine.Player.LayersData.GroundLayer, QueryTriggerInteraction.Ignore);

            return overlappedGroundColliders.Length > 0;
        }

        #endregion

        #region Reusable
        protected override void AddInputActionsCallbacks()
        {
            base.AddInputActionsCallbacks();

            stateMachine.Player.Input.PlayerActions.Movement.canceled += OnMoveCanceled;

            stateMachine.Player.Input.PlayerActions.Jump.started += OnJumpStarted;

            stateMachine.Player.Input.PlayerActions.Kick.started += OnKickStarted;
        }

        protected override void RemoveInputActionsCallbacks()
        {
            base.RemoveInputActionsCallbacks();

            stateMachine.Player.Input.PlayerActions.Movement.canceled -= OnMoveCanceled;

            stateMachine.Player.Input.PlayerActions.Jump.started -= OnJumpStarted;

            stateMachine.Player.Input.PlayerActions.Kick.started -= OnKickStarted;
        }

        protected virtual void OnMove()
        {
            if (stateMachine.ReusableData.ShouldWalk)
            {
                stateMachine.ChangeState(stateMachine.WalkingState);

                return;
            }

            stateMachine.ChangeState(stateMachine.RunningState);
        }

        protected override void OnContactWithGroundExited(Collider collider)
        {
            base.OnContactWithGroundExited(collider);

            if(IsTherGroundUnderneath())
            {
                return;
            }

            Vector3 capsuleColliderCenterInWorldSpace = stateMachine.Player.ColliderUtility.CapsuleColliderData.Collider.bounds.center;

            Ray downwardsRayFromCapsuleBottom = new Ray(capsuleColliderCenterInWorldSpace - stateMachine.Player.ColliderUtility.CapsuleColliderData.ColliderVerticalExtents, Vector3.down);

            if(!Physics.Raycast(downwardsRayFromCapsuleBottom, out _,groundData.GroundToFallDistance,stateMachine.Player.LayersData.GroundLayer,QueryTriggerInteraction.Ignore))
            {
                OnFall();
            }
        }

        protected virtual void OnFall()
        {
            stateMachine.ChangeState(stateMachine.FallingState);
        }
        #endregion


        #region Input 
        protected virtual void OnMoveCanceled(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.IdlingState);
        }

        protected virtual void OnJumpStarted(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.JumpState);
        }
        protected virtual void OnKickStarted(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.KickState);
        }

        #endregion
    }
}