using System;
using TMPro;
using UnityEngine;

namespace LearnMath {
    public class NumberPickup: PlayerPickup {
        public NumberData numberData;
        public SpriteRenderer backgroundSprite;
        public TMP_Text numberText;

        private void Start() {
            SyncView();
        }

        public void Init(int number) {
            numberData.number = number;
            SyncView();
        } 
        
        private void SyncView() {
            numberText.text = $"{numberData.number}";
        }
    }
}