using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Insomnia {
    public class InteractableNPC : Interactable {
        [Header("Interact UIs' Attributes")]
        [SerializeField] private SpriteRenderer _interactableIndicator = null;

        protected override void OnTriggerEnterAction() {
            _interactableIndicator.gameObject.SetActive(true);
        }

        protected override void OnTriggerExitAction() {
            _interactableIndicator.gameObject.SetActive(false);
        }

        public override void StartInteract() {
            base.StartInteract();
            _interactableIndicator.gameObject.SetActive(false);
            Debug.Log($"{typeof(This).Name}: StartInteract Called");
            CanInteract = false;
        }

        public override void FinishInteract() {
            base.FinishInteract();

            Debug.Log($"{typeof(This).Name}: FinishInteract Called");
            CanInteract = true;
        }

        private void Update() {
            if(CanInteract == false)
                return;

            _interactableIndicator.transform.LookAt(Camera.main.transform);
        }
    }
}
