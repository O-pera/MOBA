using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Insomnia {
    public class ReactWithDialog : InteractReactor {
        [SerializeField] private DialogManager _dialog = null;

        private void Start() {
            _dialog = Managers.Dialog;
        }

        public override void FinishInteractReaction() {

        }

        public override void StartInteractReaction() {

        }
    }
}
