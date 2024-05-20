using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RECON.Gameplay.Player.Data
{
    [Serializable]
    public class PlayerTriggerColliderData 
    {
        [SerializeField]
        private BoxCollider _groundCheckCollider;
        private Vector3 _groundCheckColliderVerticalExtents;
         
        public BoxCollider GroundChekcCollider => _groundCheckCollider;
        public Vector3 GroundCheckColliderVerticalExtents => _groundCheckColliderVerticalExtents;

        public void Initialize()
        {
            _groundCheckColliderVerticalExtents = _groundCheckCollider.bounds.extents;
        }

    }
}
