using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Insomnia {
    public abstract class InteractReactor : MonoBehaviour {
        public abstract void StartInteractReaction();

        public abstract void FinishInteractReaction();
    }
}