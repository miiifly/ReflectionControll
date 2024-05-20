using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RECON.Gameplay.Player.Data
{
    [Serializable]
    public class PlayerAirborneData 
    {
        [SerializeField]
        private PlayerJumpData _jumpData;
        [SerializeField]
        private PlayerFallData _fallData;

        public PlayerJumpData JunpData => _jumpData;
        public PlayerFallData FallData => _fallData;
    }
}
