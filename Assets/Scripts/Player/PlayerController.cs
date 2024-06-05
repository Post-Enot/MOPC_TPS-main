using UnityEngine;

namespace MOPC
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class PlayerController : MonoBehaviour
    {
        [Header(HeaderTitles.ComponentReferences)]
        [SerializeField] private Animator _animator;

        [Header(HeaderTitles.Params)]
        [SerializeField] private float _gravity = 9.8f;
        [SerializeField] private float _speed = 2.0f;

        [Header(HeaderTitles.AnimationParams)]
        [SerializeField] private string _animationParamIsMoving;

        public bool IsMoving { get; private set; }

        private CharacterController _characterController;
        private Vector3 _movement;
        private float _fallVelocity;

        private void Awake()
        {
            InitReferences();
        }

        private void Update()
        {
            HandleInput();
            CheckIsMoving();
            UpdateIsMovingParam();
        }

        private void FixedUpdate()
        {
            UpdateMovement();
        }

        public void Stop()
        {
            IsMoving = false;
            _animator.SetBool(_animationParamIsMoving, IsMoving);
        }

        private void HandleInput()
        {
            _movement.x = Input.GetAxis("Horizontal");
            _movement.z = Input.GetAxis("Vertical");
        }

        private void UpdateMovement()
        {
            _movement = transform.rotation * _movement;
            _characterController.Move(_speed * Time.fixedDeltaTime * _movement);
            _fallVelocity += (_gravity * Time.deltaTime);
            _characterController.Move(_fallVelocity * Time.fixedDeltaTime * Vector3.down);
            if (_characterController.isGrounded)
            {
                _fallVelocity = 0.0f;
            }
        }

        private void CheckIsMoving()
        {
            IsMoving = (_movement.x != 0.0f) || (_movement.z != 0.0f);
        }

        private void UpdateIsMovingParam()
        {
            _animator.SetBool(_animationParamIsMoving, IsMoving);
        }

        private void InitReferences()
        {
            _characterController = GetComponent<CharacterController>();
        }
    }
}
