using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RECON.Gameplay.Player.Movement
{
    public class PlayerMovingState : PlayerGroundedState
    {
        public PlayerMovingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        public override void Update()
        {
            base.Update();
            UpdateTargetRotation(GetMovementInputDirection());
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            RotateTowardsTargetRotation();
        }

        public override void Enter()
        {
            base.Enter();

            StartAnimation(animationData.MovingParaneterHash);
        }

        public override void Exit()
        {
            base.Exit();

            StopAnimation(animationData.MovingParaneterHash);
        }
    }
}
