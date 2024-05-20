using System;
using UnityEngine;

namespace RECON.Gameplay.Player.Data
{
    [Serializable]
    public class PlayerRotationData
    {
        [SerializeField]
        private Vector3 _targetRotationReachTime;

        public Vector3 TargetRotationReachTime => _targetRotationReachTime;
    }
}