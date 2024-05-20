using RECON.Gameplay.Player.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RECON.Gameplay.Player.Utilities
{
    [Serializable]
    public class PlayerColliderUtilities : CapsuleColliderUtility
    {
        [SerializeField]
        private PlayerTriggerColliderData _triggerColliderData;


        public PlayerTriggerColliderData TriggerColliderData => _triggerColliderData;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            _triggerColliderData.Initialize();
        }
    }
}
