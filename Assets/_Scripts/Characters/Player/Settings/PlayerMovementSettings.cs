using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RECON.Gameplay.Player.Movement
{
    public class PlayerMovementSettings : ScriptableObject
    {
        [SerializeField] private float _baseSpeed = 5f;
        [SerializeField] private float _walkModifier = 0.225f;
        [SerializeField] private float _runModifier = 1f;

        public float BaseSpeed => _baseSpeed;
        public float WalkModifier => _walkModifier;
        public float RunModifier => _runModifier;
    }
}

