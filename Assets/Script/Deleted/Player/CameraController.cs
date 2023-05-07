using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Insomnia {
    public class CameraController : InputActor {
        [SerializeField] private Transform _rotationPivot = null;
        [SerializeField] private Transform _lookAt = null;
        [SerializeField] private Transform _head = null;
        [SerializeField] private Quaternion _headOffset;
        [SerializeField] private float mouseX = 0f;
        [SerializeField] private float mouseY = 0f;

        [SerializeField] private float sensitivityX = 1.0f;
        [SerializeField] private float sensitivityY = 1.0f;

        [SerializeField] private float _minY = -60f;
        [SerializeField] private float _maxY = 60f;

        public override void ListenerEnabled() {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public override void ListenerDisabled() {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void Awake() {
            if(_lookAt == null) {
                _lookAt = transform.parent.Find("LookAt").transform;
            }

            if(_head != null) {
                _headOffset = _head.rotation;
            }
        }

        private void Update() {

        }

        private void FixedUpdate() {
            transform.parent.rotation = Quaternion.Euler(0f, mouseX, 0f);
            _rotationPivot.rotation = Quaternion.Euler(-mouseY, mouseX, 0f);
            _head.rotation = Quaternion.Euler(0, mouseX -90f, mouseY - 90f);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(_lookAt.position - transform.position), 0.1f);
            //transform.LookAt(_lookAt.position);
        }

        public override void KeyCheck() {
            mouseX += Input.GetAxis("Mouse X") * sensitivityX;
            mouseY += Input.GetAxis("Mouse Y") * sensitivityY;

            mouseY = Mathf.Clamp(mouseY, _minY, _maxY);

            //_rotationPivot.rotation = Quaternion.Euler(_rotationPivot.rotation.eulerAngles + new Vector3(-mouseY, 0, 0));
            //transform.parent.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }

}
