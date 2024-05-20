using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RECON.Gameplay.Player.Data
{
    public class PlayerStateReusableData : MonoBehaviour
    {
        public Vector2 MovementInput { get; set; }
        public float MovementOnSlopeSpeedModifier { get; set; } = 1f;
        public float MovementSpeedModifier { get; set; } = 1f;
        public float MovementDecelerationForce { get; set; } = 1f;
        public bool ShouldWalk { get; set; }
        public Vector3 CurrentJumpForce { get; set; }

        private Vector3 _currentTargetRotation;
        private Vector3 _timeToReachTargetRotation;
        private Vector3 _dampedTargetRotationCurrentVelocity;
        private Vector3 _dampedTargetRotationPassedTime;

        public ref Vector3 CurrentTargetRotation => ref _currentTargetRotation;
        public ref Vector3 TimeToReachTargetRotation => ref _timeToReachTargetRotation;
        public ref Vector3 DampedTargetRotationCurrentVelocity => ref _dampedTargetRotationCurrentVelocity;
        public ref Vector3 DampedTargetRotationPassedTime => ref _dampedTargetRotationPassedTime;
        
    }
}
