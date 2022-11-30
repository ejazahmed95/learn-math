using RangerRPG.Core;
using UnityEngine;
using UnityEngine.Events;

namespace LearnMath {
    public class PlayerPickup: MonoBehaviour {
        public UnityEvent onItemPicked;
        public AudioClip clip;

        private bool _picked = false;

        public void PickedItem() {
            if (_picked) return;
            AudioManager.Instance.Play(clip);
            _picked = true;
            onItemPicked.Invoke();
        }
        
        public void Init() {
            _picked = false;
            onItemPicked = new UnityEvent();
        }
    }
}