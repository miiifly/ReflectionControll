using UnityEngine;

namespace RECON.Gameplay.Player.Movement
{
    public class PlayerJumpState : PlayerAirbornState
    {

        private bool _canStartFalling;
        public PlayerJumpState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        #region State
        public override void Enter()
        {
            stateMachine.ReusableData.MovementSpeedModifier = 0f;

            base.Enter();

            Jump();
        }

        public override void Exit()
        {
            base.Exit();

            _canStartFalling = false;
        }

        public override void Update()
        {
            base.Update();

            if (!_canStartFalling && IsMovingVerticaly(0f))
            {
                _canStartFalling = true;
            }

            if (!_canStartFalling || IsMovingVerticaly(0f))
            {
                return;
            }

            stateMachine.ChangeState(stateMachine.FallingState);
        }

        public override void FixedUpdate()
        {

        }
        #endregion

        #region Main
        private void Jump()
        {
            Vector3 jumpForce = stateMachine.ReusableData.CurrentJumpForce;

            Vector3 playerForward = stateMachine.Player.transform.forward;

            jumpForce.x *= playerForward.x;
            jumpForce.z *= playerForward.z;

            ResetVelocity();

            stateMachine.Player.PlayerRigidbody.AddForce(jumpForce, ForceMode.VelocityChange);

        }
        #endregion
    }
}
