using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RECON.Gameplay.Player.Data
{
    [Serializable]
    public class PlayerAnimationData
    {
        [Header("State Group Parameters Names")]
        [SerializeField] private string _groundedParameterName = "Grounded";
        [SerializeField] private string _movingParameterName = "Moving";
        [SerializeField] private string _stoppingParameterName = "Stopping";
        [SerializeField] private string _landingParameterName = "Landing";
        [SerializeField] private string _airborneParameterName = "Air";

        [Header("Grounded Parameter Names")]
        [SerializeField] private string _idleParameterName = "isIdling";
        [SerializeField] private string _walkParameterName = "isWalking";
        [SerializeField] private string _runParameterName = "isRunning";
        [SerializeField] private string _hardStopParameterName = "isHardStopping";
        [SerializeField] private string _hardLandParameterName = "isHardLanding";
        [SerializeField] private string _fallParameterName = "isFalling";

        public int GroundedParaneterHash { get; private set; }
        public int MovingParaneterHash { get; private set; }
        public int StoppingParaneterHash { get; private set; }
        public int LandingParaneterHash { get; private set; }
        public int AirborneParaneterHash { get; private set; }

        public int IdleParaneterHash { get; private set; }
        public int WalkParaneterHash { get; private set; }
        public int RunParaneterHash { get; private set; }
        public int HardStopParaneterHash { get; private set; }
        public int HardLandParaneterHash { get; private set; }
        public int FallParaneterHash { get; private set; }

        public void Initialize()
        {
            GroundedParaneterHash = Animator.StringToHash(_groundedParameterName);
            MovingParaneterHash = Animator.StringToHash(_movingParameterName);
            StoppingParaneterHash = Animator.StringToHash(_stoppingParameterName);
            LandingParaneterHash = Animator.StringToHash(_landingParameterName);
            AirborneParaneterHash = Animator.StringToHash(_airborneParameterName);

            IdleParaneterHash = Animator.StringToHash(_idleParameterName);
            WalkParaneterHash = Animator.StringToHash(_walkParameterName);
            RunParaneterHash = Animator.StringToHash(_runParameterName);
            HardStopParaneterHash = Animator.StringToHash(_hardStopParameterName);
            HardLandParaneterHash = Animator.StringToHash(_hardLandParameterName);

            FallParaneterHash = Animator.StringToHash(_fallParameterName);
        }
    }
}
