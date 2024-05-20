using RECON.Gameplay.Player.Data;
using RECON.Gameplay.Player.Movement;
using RECON.Gameplay.Player.Utilities;
using UnityEngine;

namespace RECON.Gameplay.Player
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        public PlayerInput Input => _input;
        public PlayerSO Data => _data;
        public PlayerColliderUtilities ColliderUtility => _capsuleColliderUtility;
        public PlayerLayerData LayersData => _layerData;
        public Animator Animator => _animator;
        public PlayerAnimationData AnimationData => _animationData;
        public Rigidbody PlayerRigidbody => _playerRigidBody;
        public Transform MainCameraTransform => _mainCamera.transform;

        private Rigidbody _playerRigidBody;
        private PlayerInput _input;
        private PlayerMovementStateMachine _movementStateMachine;

        [Header("Reference")]
        [SerializeField]
        private PlayerSO _data;
        [Header("Collision")]
        [SerializeField]
        private PlayerColliderUtilities _capsuleColliderUtility;
        [SerializeField]
        private PlayerLayerData _layerData;
        [SerializeField]
        private GameObject _colliderObject;

        [Header("Camera")]
        [SerializeField]
        private Camera _mainCamera;

        [Header("Animations")]
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private PlayerAnimationData _animationData;

        private void Awake()
        {
            _playerRigidBody = GetComponent<Rigidbody>();
            _input = GetComponent<PlayerInput>();

            _capsuleColliderUtility.Initialize(_colliderObject);
            _capsuleColliderUtility.CapsulateCapsuleColliderDimensions();

            _animationData.Initialize();

            _movementStateMachine = new PlayerMovementStateMachine(this);
        }

        private void OnValidate()
        {
            _capsuleColliderUtility.Initialize(_colliderObject);
            _capsuleColliderUtility.CapsulateCapsuleColliderDimensions();
        }

        private void OnTriggerEnter(Collider collider)
        {
            _movementStateMachine.OnTriggerEnter(collider);
        }

        private void OnTriggerExit(Collider collider)
        {
            _movementStateMachine.OnTriggerExit(collider);
        }

        private void Start()
        {
            _movementStateMachine.ChangeState(_movementStateMachine.IdlingState);
        }

        private void Update()
        {
            _movementStateMachine.HandleInput();

            _movementStateMachine.Update();
        }

        private void FixedUpdate()
        {
            _movementStateMachine.FixedUpdate();
        }
    }
}
