using RECON.Gameplay.Player.Data;
using RECON.Gameplay.Player.Movement;

namespace RECON.Gameplay.Player
{
    public class PlayerMovementStateMachine : StateMachine
    {
        public Player Player => _player;
        public PlayerStateReusableData ReusableData => _reusableData;
        public PlayerIdlingState IdlingState => _idlingState;
        public PlayerWalkingState WalkingState => _walkingState;
        public PlayerRunningState RunningState => _runningState;
        public PlayerWalkStoppingState WalkStoppingState => _walkStoppingState;
        public PlayerRunStoppingState RunStoppingState => _runStoppingState;
        public PLayerLightLandingState LightLandingState => _lightLandingState;
        public PlayerHardLandingState HardLandingState => _hardLandingState;
        public PlayerAirbornState AirbornState => _airborneState;
        public PlayerFallingState FallingState => _fallingState;
        public PlayerJumpState JumpState => _jumpState;
        public PlayerKickState KickState => _kickState;

        private Player _player;

        private PlayerStateReusableData _reusableData;
        private PlayerIdlingState _idlingState;
        private PlayerWalkingState _walkingState;
        private PlayerRunningState _runningState;

        private PlayerWalkStoppingState _walkStoppingState;
        private PlayerRunStoppingState _runStoppingState;

        private PLayerLightLandingState _lightLandingState;
        private PlayerHardLandingState _hardLandingState;

        private PlayerAirbornState _airborneState;
        private PlayerFallingState _fallingState;
        private PlayerJumpState _jumpState;
        private PlayerKickState _kickState;


        public PlayerMovementStateMachine(Player player)
        {
            _player = player;
            _reusableData = new PlayerStateReusableData();

            _idlingState = new PlayerIdlingState(this);
            _walkingState = new PlayerWalkingState(this);
            _runningState = new PlayerRunningState(this);

            _walkStoppingState = new PlayerWalkStoppingState(this);
            _runStoppingState = new PlayerRunStoppingState(this);

            _lightLandingState = new PLayerLightLandingState(this);
            _hardLandingState = new PlayerHardLandingState(this);

            _airborneState = new PlayerAirbornState(this);
            _fallingState = new PlayerFallingState(this);
            _jumpState = new PlayerJumpState(this);
            _kickState = new PlayerKickState(this);
        }
    }
}

