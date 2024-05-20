using System;
using UnityEngine;

namespace RECON.Gameplay.Player.Data
{
    [Serializable]
    public class PlayerWalkData
    {
        [SerializeField]
        [Range(0f, 1f)]
        private float _speedModifier = 0.225f;

        public float SpeedModifier => _speedModifier;
    }
}
