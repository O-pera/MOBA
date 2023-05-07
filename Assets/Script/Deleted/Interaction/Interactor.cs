using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Insomnia {
    public class Interactor : TriggerInputActor {
        [Header("Interactor Attributes")]
        [SerializeField] private Interactable _interactable = null;

        #region InputActor VirtualFunctions


        #endregion

        #region Interactor Functions
        public void SetInteractable(Interactable interactable) {
            if(interactable == null)
                return;

            if(interactable.CanInteract == false)
                return;

            _interactable = interactable;
        }

        public void StartInteract() {
            if(_interactable == null)
                return;

            if(_interactable.CanInteract == false)
                return;

            _interactable.StartInteract();
        }

        #endregion
    }
}
