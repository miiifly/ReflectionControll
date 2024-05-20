using UnityEngine;

namespace RECON.Gameplay.Player.Utilities
{
    public class PlayerInput : MonoBehaviour
    {

        private PlayerInputActions _inputActions;

        public PlayerInputActions.PlayerActions PlayerActions => _inputActions.Player;

        private void Awake()
        {
            _inputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Disable();
        }
    }

}

