using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Insomnia {
    public class MouseAxisInput : AnalogInputActor {
        [SerializeField] private float _scrollSpeed = 20f;

        [SerializeField] private float _heightBarrier = 0f;
        [SerializeField] private float _widthBarrier = 0f;

        [SerializeField] private Vector3 _mouseMovePos = Vector3.zero;
        [SerializeField] private GameObject _cameraHolder = null;

        private Vector3 upVector = new Vector3(-1, 0, 1);
        private Vector3 rightVector = new Vector3(1, 0, 1);

        float screenHeight = 0f;
        float screenWidth = 0f;

        private void Awake() {
            if(_cameraHolder == null)
                _cameraHolder = GameObject.Find("CameraHolder");

            screenHeight = Screen.height;
            screenWidth = Screen.width;
        }

        public override void KeyCheck() {
            Vector3 mousePos =  Input.mousePosition;
            Vector3 moveDir = Vector3.zero;
            
            if(mousePos.y <= screenHeight * _heightBarrier || mousePos.y >= screenHeight * (1- _heightBarrier )) 
                moveDir += upVector * ( Mathf.Abs(mousePos.y - ( screenHeight * 0.5f )) / (mousePos.y - ( screenHeight * 0.5f )));

            if(mousePos.x <= screenWidth * _widthBarrier || mousePos.x >= screenWidth * ( 1 - _widthBarrier ))
                moveDir += rightVector * ( Mathf.Abs(mousePos.x - ( screenWidth * 0.5f )) / (mousePos.x - ( screenWidth * 0.5f )));

            _mouseMovePos = moveDir.normalized;
        }

        private void Update() {
            if(IsEnabled == false)
                return;

            if(_mouseMovePos == Vector3.zero)
                return;

            Camera.main.transform.Translate(_mouseMovePos * _scrollSpeed * Time.deltaTime, Space.World);
        }
    }
}