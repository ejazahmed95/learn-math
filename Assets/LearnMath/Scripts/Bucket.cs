using System;
using TMPro;
using UnityEngine;

namespace LearnMath {
    public class Bucket : MonoBehaviour {
        public Operation operation;
        public int currentNumber;
        public int baseNumber;

        public TMP_Text operationText;
        public TMP_Text numberText;

        private void Start() {
            SyncView();
        }
        
        public bool AddNumberToBucket(int number) {
            switch (operation) {
                case Operation.Add:
                    currentNumber += number;
                    break;
                case Operation.Subtract:
                    currentNumber -= number;
                    break;
                case Operation.Multiply:
                    currentNumber *= number;
                    break;
                case Operation.Divide:
                    if (currentNumber % number != 0) return false;
                    currentNumber /= number;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            GameManager.Instance.UpdatedNumber(this, currentNumber);
            SyncView();
            return true;
        }

        public void Reset() {
            currentNumber = baseNumber;
            GameManager.Instance.UpdatedNumber(this, currentNumber);
            SyncView();
        }
        
        private void SyncView() {
            var symbol = operation switch {
                Operation.Add => "+",
                Operation.Subtract => "-",
                Operation.Multiply => "x",
                Operation.Divide => "/",
                _ => "."
            };
            operationText.text = symbol;
            numberText.text = $"{currentNumber}";
        }

    }
}