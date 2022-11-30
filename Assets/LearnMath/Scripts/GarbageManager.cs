using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LearnMath {
    public class GarbageManager : MonoBehaviour {
        public List<GarbageZone> _garbageZones = new();

        public int maxNumberValue = 50;
        
        private void Start() {
            foreach (var garbageZone in _garbageZones) {
                var randomNumber = Random.Range(2, maxNumberValue/2);
                garbageZone.Init(randomNumber);
            }
        }

        public bool RemoveGarbageUsingNumber(int number) {
            foreach (var garbageZone in _garbageZones) {
                if (garbageZone.number == number) {
                    var randomNumber = Random.Range(2, maxNumberValue+1);
                    garbageZone.Init(randomNumber);
                    return true;
                }
            }
            return false;
        }

    }
}