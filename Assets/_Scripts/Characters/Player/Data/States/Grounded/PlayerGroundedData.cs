using System;
using UnityEngine;

namespace RECON.Gameplay.Player.Data
{
    [Serializable]
    public class PlayerGroundedData
    {
        [SerializeField]
        [Range(0f, 25f)]
        private float _baseSpeed = 5f;
        [SerializeField]
        [Range(0f, 25f)]
        private float _groundToFallDistance = 1f;
        [SerializeField]
        private AnimationCurve _slopeSpeedAngles;
        [SerializeField]
        private PlayerRotationData _baseRotationData;
        [SerializeField]
        private PlayerWalkData _walkData;
        [SerializeField]
        private PlayerRunData _runData;
        [SerializeField]
        private PlayerStopData _stopData;

        public float BaseSpeed => _baseSpeed;
        public float GroundToFallDistance => _groundToFallDistance;
        public AnimationCurve SlopeSpeedAngles => _slopeSpeedAngles;
        public PlayerRotationData BaseRotationData => _baseRotationData;
        public PlayerWalkData WalkData => _walkData;
        public PlayerRunData RunData => _runData;
        public PlayerStopData StopData => _stopData;
    }
}