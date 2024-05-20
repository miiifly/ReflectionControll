using RECON.Gameplay.Player;
using RECON.Gameplay.Player.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RECON
{
    public class PlayerKickState : PlayerGroundedState
    {
        public PlayerKickState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {

        }

    }
}
