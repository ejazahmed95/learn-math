using System;
using RangerRPG.Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LearnMath {
    public class NumbersManager : ObjectPool<NumberPickup> {
        public int numbersCount = 20;
        public int totalNumberCount = 0;
        public Vector2 spawnXRange = new Vector2(-5, 5);
        public Vector2 spawnYRange = new Vector2(-5, 5);

        public void Awake() {
            DI.Register(this);
        }

        private void Start() {
            int i = 0;
            while (totalNumberCount < numbersCount && i++ < numbersCount + 5) {
                SpawnNewNumber();
            }
        }
        
        public void SpawnNewNumber() {
            int randomNumber = Random.Range(1, 15);
            float xPos = Random.Range(spawnXRange.x, spawnXRange.y);
            float yPos = Random.Range(spawnYRange.x, spawnYRange.y);
            var newObj = GetNewObject();
            newObj.Init(randomNumber);
            newObj.transform.localPosition = new Vector3(xPos, yPos, 0);
        }

        public override NumberPickup GetNewObject() {
            totalNumberCount++;
            return base.GetNewObject();
        }

        public override void RemoveObject(NumberPickup obj) {
            totalNumberCount--;
            SpawnNewNumber();
            base.RemoveObject(obj);
        }

        private void OnDestroy() {
            DI.DeRegister(this);
        }
    }
}