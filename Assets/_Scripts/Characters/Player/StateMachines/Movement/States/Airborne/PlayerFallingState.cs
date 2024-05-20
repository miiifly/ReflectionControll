using RECON.Gameplay.Player.Data;
using UnityEngine;

namespace RECON.Gameplay.Player.Movement
{
    public class PlayerFallingState : PlayerAirbornState
    {
        private PlayerFallData _fallData;

        private Vector3 _playerPositionOnEnter;

        public PlayerFallingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
            _fallData = airborneData.FallData;
        }

        #region State
        public override void Enter()
        {
            base.Enter();

            StartAnimation(animationData.FallParaneterHash);

            _playerPositionOnEnter = stateMachine.Player.transform.position;

            stateMachine.ReusableData.MovementSpeedModifier = 0f;

            ResetVerticalVelocty();
        }

        public override void Exit()
        {
            base.Exit();

            StopAnimation(animationData.FallParaneterHash);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            LimitVerticalVelocity();
        }
        #endregion

        //override ResetSprintState()
        //{

        //}

        protected override void OnContactWithGround(Collider collider)
        {
            float fallDistance = _playerPositionOnEnter.y - stateMachine.Player.transform.position.y;

            if (fallDistance < _fallData.MinDistanceToHardFall)
            {
                stateMachine.ChangeState(stateMachine.LightLandingState);

                return;
            }

            if (stateMachine.ReusableData.MovementInput == Vector2.zero)
            {
                stateMachine.ChangeState(stateMachine.HardLandingState);

                return;
            }
        }

        #region Main
        private void LimitVerticalVelocity()
        {
            Vector3 playerVerticalVelocity = GetPlayerVerticalVelocity();

            if (stateMachine.Player.PlayerRigidbody.velocity.y >= -_fallData.FallSpeedLimit)
            {
                return;
            }

            Vector3 limitedVelocity = new Vector3(0f, -_fallData.FallSpeedLimit - playerVerticalVelocity.y, 0f);

            stateMachine.Player.PlayerRigidbody.AddForce(limitedVelocity, ForceMode.VelocityChange);
        }
        #endregion
    }
}
