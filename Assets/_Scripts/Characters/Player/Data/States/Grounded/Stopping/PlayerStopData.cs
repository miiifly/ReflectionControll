using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RECON.Gameplay.Player.Data
{
    [Serializable]
    public class PlayerStopData
    {
        [SerializeField]
        [Range(0f, 15f)]
        private float _walkDecelerationForce = 5f;
        [SerializeField]
        [Range(0f, 15f)]
        private float _runDecelerationForce = 6.5f;

        public float WalkDecelerationForce => _walkDecelerationForce;
        public float RunDecelerationForce => _runDecelerationForce;

    }
}
