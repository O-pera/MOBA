using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Insomnia {
    public class PlayerLocomotion : InputActor {
        [Header("Components")]
        #region Animator Controller
        [SerializeField] private Animator _animator = null;
        private int _hashHorizontal = 0;
        private int _hashVertical = 0;

        private float _curAnimHorizontal = 0f;
        private float _curAnimVertical = 0f;
        #endregion

        [SerializeField] private GroundChecker _ground = null;

        [SerializeField] private Rigidbody _rigid = null;

        [SerializeField] private Vector3 _inputVector = Vector3.zero;
        [SerializeField] private float _walkSpeed = 5.0f;
        [SerializeField] private float _runSpeed = 10.0f;
        [SerializeField] private float _jumpForce = 5.0f;
        [SerializeField] private bool _isRun = false;
        [SerializeField] private bool _isJump = false;

        private void Awake() {
            //_controller = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
            _hashHorizontal = Animator.StringToHash("Horizontal");
            _hashVertical = Animator.StringToHash("Vertical");

            _ground = transform.parent.GetComponentInChildren<GroundChecker>();
            _rigid = transform.parent.GetComponent<Rigidbody>();
        }

        private void Update() {
            ModifyAnimationProperties();
            PlayAnimation();
            CalculateGravity();
        }

        private void FixedUpdate() {
            _rigid.velocity = transform.TransformDirection(_inputVector.normalized)
                * ( _isRun ? _runSpeed : _walkSpeed );
        }

        public override void KeyCheck() {
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

            _inputVector = new Vector3(inputX, 0, inputY);
            _isRun = Input.GetKey(KeyCode.LeftShift);
            _isJump = Input.GetKeyDown(KeyCode.Space);
        }

        public override void ListenerEnabled() {
            
        }

        public override void ListenerDisabled() {
            
        }

        private void ModifyAnimationProperties() {
            float horizontalParam = (Mathf.Abs(_inputVector.x) <= 0.1f ? 0 : _inputVector.x) * (_isRun ? 1 : 0.5f);
            float verticalParam = (Mathf.Abs(_inputVector.z) <= 0.1f ? 0 : _inputVector.z) * (_isRun ? 1 : 0.5f);

            _curAnimHorizontal = Mathf.Lerp(_curAnimHorizontal, horizontalParam, 0.05f);
            _curAnimVertical = Mathf.Lerp(_curAnimVertical, verticalParam, 0.05f);
        }

        private void PlayAnimation() {
            _animator.SetFloat(_hashHorizontal, _curAnimHorizontal);
            _animator.SetFloat(_hashVertical, _curAnimVertical);
        }

        private void CalculateGravity() {
            if(_isJump) {
                _inputVector.y = _ground.IsGrounded ? _jumpForce : _inputVector.y;
                _isJump = false;
                //TODO: 애니메이션 점프 트리거 활성화
                return;
            }

            _inputVector.y = _ground.IsGrounded ? 0 : _inputVector.y - 0.3f;
        }
    }
}