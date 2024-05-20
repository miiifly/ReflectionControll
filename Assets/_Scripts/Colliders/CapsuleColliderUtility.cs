using RECON.Gameplay.Data.Colliders;
using System;
using UnityEngine;

namespace RECON.Gameplay.Player.Utilities
{
    [Serializable]
    public class CapsuleColliderUtility
    {
        public CapsuleColliderData CapsuleColliderData => _capsuleColliderData;
        public SlopeData SlopeData => _slopeData;

        [SerializeField]
        private DefaultColliderData _defaultColliderData;
        [SerializeField]
        private SlopeData _slopeData;

        private CapsuleColliderData _capsuleColliderData;

        public void Initialize(GameObject gameObject)
        {
            if(_capsuleColliderData != null)
            {
                return;
            }

            _capsuleColliderData = new CapsuleColliderData();

            _capsuleColliderData.Initialize(gameObject);

            OnInitialize();
        }

        protected virtual void OnInitialize()
        {

        }

        public void CapsulateCapsuleColliderDimensions()
        {
            SetCapsuleColliderRadius(_defaultColliderData.Radius);
            SetCapsuleColliderHeight(_defaultColliderData.Height * (1f - _slopeData.StepHeightPercentage));

            RecalculateCapsuleColliderColliderCenter();

            float halfColliderHeight = _capsuleColliderData.Collider.height / 2f;

            if (halfColliderHeight < _capsuleColliderData.Collider.radius)
            {
                SetCapsuleColliderRadius(halfColliderHeight);
            }

            _capsuleColliderData.UpdateColliderData();
        }

        private void SetCapsuleColliderRadius(float radius)
        {
            _capsuleColliderData.Collider.radius = radius;
        }

        private void SetCapsuleColliderHeight(float height)
        {
            _capsuleColliderData.Collider.height = height;
        }

        private void RecalculateCapsuleColliderColliderCenter()
        {
            float colliderHeightDifference = _defaultColliderData.Height - _capsuleColliderData.Collider.height;

            Vector3 newColliderCenter = new Vector3(0f, _defaultColliderData.CenterY + (colliderHeightDifference / 2f), 0f);

            _capsuleColliderData.Collider.center = newColliderCenter;
        }
    }
}

