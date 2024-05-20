using System;
using UnityEngine;

namespace RECON.Gameplay.Player.Data
{
    [Serializable]
    public class PlayerJumpData
    {
        [SerializeField]
        private Vector3 _stationaryForce;
        [SerializeField]
        private Vector3 _weakForce;
        [SerializeField]
        private Vector3 _mediumForce;
        [SerializeField]
        private Vector3 _strongForce;

        public Vector3 StationaryForce => _stationaryForce;
        public Vector3 WeakForce => _weakForce;
        public Vector3 MediumForce => _mediumForce;
        public Vector3 StrongForce => _strongForce;
    }
}
