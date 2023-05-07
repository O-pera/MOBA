using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Insomnia {
    public class InputManager : MonoBehaviour{

        [SerializeField] private ushort _curPriority = 0;
        [SerializeField] private List<InputListener> _listeners = new List<InputListener>();
        
        public void AddListener(InputListener listener) {
            if(listener == null)
                return;

            _listeners.Add(listener);
            CalculateMaxPriority(listener);
        }

        public void RemoveListener(InputListener listener) {
            if(listener == null)
                return;

            if(_listeners.Contains(listener) == false)
                return;

            _listeners.Remove(listener);

            CalculateMaxPriority();
        }

        private void Update() {
            for(int i = 0; i < _listeners.Count;i++) {
                if(_listeners[i].Priority != _listeners[i].Priority)
                    continue;

                _listeners[i].OnUpdate();
            }
        }

        private void CalculateMaxPriority(InputListener listener = null) {
            if(listener == null) {
                for(int i = 0; i < _listeners.Count; i++) {
                    _curPriority = (ushort)Mathf.Max(_curPriority, _listeners[i].Priority);
                }
            }
            else {
                _curPriority = (ushort)Mathf.Max(_curPriority, listener.Priority);
            }

            for(int i = 0; i < _listeners.Count ; i++) {
                if(_listeners[i].Priority == _curPriority)
                    _listeners[i].EnableListener();
                else
                    _listeners[i].DisableListener();
            }
        }
    }
}