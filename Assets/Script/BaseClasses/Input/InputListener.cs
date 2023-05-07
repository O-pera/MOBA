using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Insomnia {
    public class InputListener : MonoBehaviour {
        [SerializeField] protected ushort _priority = 0;
        public ushort Priority { get => _priority; }

        private InputActor[] _actors = null;
        private InputManager _manager = null;


        #region Unity Event Functions
        private void Awake() {
            _actors = GetComponentsInChildren<InputActor>();
        }

        private void Start() {
            Managers.Input.AddListener(this);
        }

        private void OnEnable() {

            AfterOnEnableCalled();
        }

        protected virtual void AfterOnEnableCalled() { }

        private void OnDisable() {
            Managers.Input.RemoveListener(this);
            AfterOnDisableCalled();
        }

        protected virtual void AfterOnDisableCalled() { }

        private void OnDestroy() { OnDisable(); }

        public virtual void OnUpdate() {
            for(int i = 0; i < _actors.Length; i++) {
                _actors[i].KeyCheck();
            }
        }

        public void EnableListener() {
            for(int i = 0; i < _actors.Length; i++) {
                _actors[i].ListenerEnabled();
            }
        }

        public void DisableListener() {
            for(int i = 0; i < _actors.Length; i++) {
                _actors[i].ListenerDisabled();
            }
        }
        #endregion
    }
}
