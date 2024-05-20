using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RECON.Gameplay.Player.Movement
{
    public class PlayerWalkStoppingState : PlayerStoppingState
    {
        public PlayerWalkStoppingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        #region State
        public override void Enter()
        {
            base.Enter();

            stateMachine.ReusableData.MovementDecelerationForce = groundData.StopData.WalkDecelerationForce;

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JunpData.WeakForce;
        }
        #endregion

        #region Reusable


        #endregion
    }
}
