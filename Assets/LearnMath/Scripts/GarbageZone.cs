using TMPro;
using UnityEngine;

namespace LearnMath {
    public class GarbageZone : MonoBehaviour {
        public TMP_Text numberText;
        public int number;

        private void Start() {
            SyncView();
        }
        
        public void Init(int num) {
            number = num;
            SyncView();
        }

        private void SyncView() {
            numberText.text = $"{number}";
        }
    }
}