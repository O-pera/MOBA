using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Insomnia {
    public class MouseAxisActor : AnalogInputActor {
        #region External Variables
        [SerializeField] private MouseAction _action = null;

        #endregion
        [SerializeField] private float _scrollSpeed = 20f;

        [SerializeField] private float _heightBarrier = 0f;
        [SerializeField] private float _widthBarrier = 0f;

        [SerializeField] private Vector3 _mouseMoveDir = Vector3.zero;
        [SerializeField] private GameObject _cameraHolder = null;

        private Vector3 upVector = new Vector3(-1, 0, 1);
        private Vector3 rightVector = new Vector3(1, 0, 1);

        private float screenHeight = 0f;
        private float screenWidth = 0f;
        private int _tileLayerMask = -1;

        private IEnumerator _raycasting = null;
        private Tile _curTile = null;

        private void Awake() {
            if(_cameraHolder == null)
                _cameraHolder = GameObject.Find("CameraHolder");

            screenHeight = Screen.height;
            screenWidth = Screen.width;
            _tileLayerMask = LayerMask.NameToLayer("Tile");

            _raycasting = CoRaycastTile();
            _action = GetComponent<MouseAction>();
        }

        private void Start() {
            StartCoroutine(_raycasting);
        }

        public override void KeyCheck() {
            Vector3 mousePos =  Input.mousePosition;
            Vector3 moveDir = Vector3.zero;
            
            if(mousePos.y <= screenHeight * _heightBarrier || mousePos.y >= screenHeight * (1- _heightBarrier )) 
                moveDir += upVector * ( Mathf.Abs(mousePos.y - ( screenHeight * 0.5f )) / (mousePos.y - ( screenHeight * 0.5f )));

            if(mousePos.x <= screenWidth * _widthBarrier || mousePos.x >= screenWidth * ( 1 - _widthBarrier ))
                moveDir += rightVector * ( Mathf.Abs(mousePos.x - ( screenWidth * 0.5f )) / (mousePos.x - ( screenWidth * 0.5f )));

            _mouseMoveDir = moveDir.normalized;
        }

        private void Update() {
            if(IsEnabled == false)
                return;

            if(_mouseMoveDir == Vector3.zero)
                return;

            return;

            Camera.main.transform.Translate(_mouseMoveDir * _scrollSpeed * Time.deltaTime, Space.World);
        }

        private void OnDisable() {
            StopCoroutine(_raycasting);
        }

        private void OnApplicationQuit() {
            OnDisable();
        }

        private IEnumerator CoRaycastTile() {
            while(true) {
                //TODO: 내 턴일 때나 Move 액션 선택했을 때 작동하도록 조건문 걸어주기
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red, 0.1f);
                if(Physics.Raycast(ray, out hit, 100f, 1 << _tileLayerMask)) {
                    if(hit.collider.TryGetComponent(out Tile tile)) {
                        _action.SetPointedTile(tile);
                    }
                    else
                        _action.SetPointedTile(null);
                }
                else {
                    _action.SetPointedTile(null);
                }

                yield return null;
            }

            yield break;
        }
    }
}