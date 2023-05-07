using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Insomnia {
    [RequireComponent(typeof(InteractReactor))]
    public abstract class Interactable : MonoBehaviour {
        private Interactor _interactor = null;
        public Interactor Interactor { get => _interactor; }

        private InteractReactor _reactor = null;
        public InteractReactor Reactor { get => _reactor; }

        [Header("Interactable Attributes")]
        [SerializeField] private Collider _interactAreaTrigger = null;
        [SerializeField] private string _playerTag = "Player";
        [SerializeField] private bool _canInteract = false;

        public bool CanInteract { get => _canInteract; protected set => _canInteract = value; }

        private void Awake() {
            _interactAreaTrigger = GetComponent<Collider>();
            _reactor = GetComponent<InteractReactor>();
        }

        private void OnTriggerEnter(Collider other) {
            if(_canInteract == false)
                return;

            if(other.CompareTag(_playerTag) == false)
                return;

            _interactor = other.gameObject.GetComponent<Interactor>();
            if(_interactor == null)
                return;

            _interactor.SetInteractable(this);
            OnTriggerEnterAction();
        }

        private void OnTriggerExit(Collider other) {
            if(_interactor == null)
                return;

            if(_interactor.CompareTag(_playerTag) == false)
                return;

            OnTriggerExitAction();
        }

        protected abstract void OnTriggerEnterAction();
        protected abstract void OnTriggerExitAction();

        /// <summary>
        /// ��ȣ�ۿ� ���� �� ȣ��Ǵ� �Լ�. base.OnInteractStart()ȣ�� �ʼ�
        /// </summary>
        public virtual void StartInteract() {
            _interactAreaTrigger.enabled = false;
            _reactor.StartInteractReaction();
        }

        /// <summary>
        /// ��ȣ�ۿ� ���� �� ȣ��Ǵ� �Լ�. base.OnInteractFinish()ȣ�� �ʼ�
        /// </summary>
        public virtual void FinishInteract() {
            _interactAreaTrigger.enabled = true;
            _reactor.FinishInteractReaction();
        }
    }
}
