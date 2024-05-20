using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RECON.Gameplay.Player.Data
{
    [Serializable]
    public class PlayerFallData
    {
        [SerializeField]
        [Range(1f, 15f)]
        private float _fallSpeedLimit = 15f;
        [SerializeField]
        [Range(0f, 100f)]
        private float _minDistanceToHardFall = 3f;


        public float FallSpeedLimit => _fallSpeedLimit;
        public float MinDistanceToHardFall => _minDistanceToHardFall;

    }
}
