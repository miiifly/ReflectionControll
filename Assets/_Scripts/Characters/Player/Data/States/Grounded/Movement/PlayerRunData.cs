using System;
using UnityEngine;

namespace RECON.Gameplay.Player.Data
{
    [Serializable]
    public class PlayerRunData
    {
        [SerializeField]
        [Range(1f, 2f)]
        private float _speedModifier = 1f;

        public float SpeedModifier => _speedModifier;
    }
}
