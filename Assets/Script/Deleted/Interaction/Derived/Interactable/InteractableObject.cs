using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Insomnia {
    public class InteractableObject : Interactable {
        protected override void OnTriggerEnterAction() {
            throw new System.NotImplementedException();
        }

        protected override void OnTriggerExitAction() {
            throw new System.NotImplementedException();
        }

        public override void StartInteract() {
            base.StartInteract();

        }

        public override void FinishInteract() {
            base.FinishInteract();

        }
    }
}