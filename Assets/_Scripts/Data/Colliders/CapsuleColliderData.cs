using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RECON.Gameplay.Data.Colliders
{
    public class CapsuleColliderData
    {
        private CapsuleCollider _collider;
        private Vector3 _colliderInLocalSpace;
        private Vector3 _colliaderVerticalExtents;

        public CapsuleCollider Collider => _collider;
        public Vector3 ColliderInLocalSpace => _colliderInLocalSpace;
        public Vector3 ColliderVerticalExtents => _colliaderVerticalExtents;

        public void Initialize(GameObject gameObject)
        {
            if(_collider != null)
            {
                return;
            }

            _collider = gameObject.GetComponent<CapsuleCollider>();
            UpdateColliderData();
        }

        public void UpdateColliderData()
        {
            _colliderInLocalSpace = _collider.center;

            _colliaderVerticalExtents = new Vector3(0f, _collider.bounds.extents.y, 0f);
        }
    }
}