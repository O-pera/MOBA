using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Insomnia {
    public class Managers : Singleton<Managers> {
        private static InputManager _input;
        public static InputManager Input { get => _input; }

        private static DialogManager _dialog;
        public static DialogManager Dialog { get => _dialog; }

        protected override void Awake() {
            base.Awake();
            RegisterManager();
        }

        private void RegisterManager() {
            _input = GetComponentInChildren<InputManager>();
        }
    }
}
