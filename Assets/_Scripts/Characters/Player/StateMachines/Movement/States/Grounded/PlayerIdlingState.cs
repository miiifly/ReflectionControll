using Unity.VisualScripting;
using UnityEngine;

namespace RECON.Gameplay.Player.Movement
{
    public class PlayerIdlingState : PlayerGroundedState
    {
        public PlayerIdlingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        #region State
        public override void Enter()
        {
            stateMachine.ReusableData.MovementSpeedModifier = 0f;

            base.Enter();

            StartAnimation(animationData.IdleParaneterHash);

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JunpData.StationaryForce;

            ResetVelocity();
        }

        public override void Exit()
        {
            base.Exit();

            StopAnimation(animationData.IdleParaneterHash);
        }

        public override void Update()
        {
            base.Update();

            if(stateMachine.ReusableData.MovementInput == Vector2.zero)
            {
                return;
            }

            base.OnMove();

        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if(!IsMovingHorizontally())
            {
                return;
            }

            ResetVelocity();
        }
        #endregion
    }
}

