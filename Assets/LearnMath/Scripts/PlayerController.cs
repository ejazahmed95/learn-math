using System;
using System.Collections.Generic;
using RangerRPG.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LearnMath {
    public class PlayerController : MonoBehaviour {

        public List<GameObject> enteredObjects = new();
        public Transform socket;
        public NumberPickup currentPickup;
        public GameObject pickupParent;
        private NumbersManager _numbersManager;

        public AudioClip pickSound;
        public AudioClip dropSound;
        public AudioClip killSound;

        private AudioManager _audioManager;

        private void Start() {
            _numbersManager = DI.Get<NumbersManager>();
            _audioManager = AudioManager.Instance;
        }
        
        private void OnTriggerEnter2D(Collider2D other) {
            if (enteredObjects.Contains(other.gameObject) == false) {
                enteredObjects.Add(other.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            enteredObjects.Remove(other.gameObject);
        }
        
        public void OnInteract(InputAction.CallbackContext ctx) {
            if(ctx.phase != InputActionPhase.Performed) return;
            if (currentPickup != null) {
                Bucket bucket = GetNearbyBucket();
                if (bucket != null) {
                    // Drop In Bucket
                    Log.Info($"Dropping in Bucket!");
                    bucket.AddNumberToBucket(currentPickup.numberData.number);
                    currentPickup.transform.parent = pickupParent.transform;
                    _numbersManager.RemoveObject(currentPickup);
                    currentPickup = null;
                    _audioManager.Play(dropSound);
                }
                else {
                    // Drop Current Pickup
                    Log.Info($"Dropping current pickup!");
                    currentPickup.transform.parent = pickupParent.transform;
                    currentPickup = null;
                    _audioManager.Play(dropSound);
                }
            } else {
                NumberPickup pickup = GetNearbyPickup();
                if (pickup == null) return;
                Log.Info($"Picking up something!");
                currentPickup = pickup;
                currentPickup.transform.parent = socket;
                currentPickup.transform.localPosition = Vector3.zero;
                _audioManager.Play(pickSound);
            }
        }

        public void OnKill(InputAction.CallbackContext ctx) {
            if(ctx.phase != InputActionPhase.Performed) return;
            if (currentPickup != null) {
                currentPickup.transform.parent = pickupParent.transform;
                _numbersManager.RemoveObject(currentPickup);
                currentPickup = null;
                _audioManager.Play(killSound);
            } else {
                Bucket bucket = GetNearbyBucket();
                if (bucket == null) return;
                Log.Info($"Picking up something!");
                bucket.Reset();
                _audioManager.Play(killSound);
            }
        }
        
        private Bucket GetNearbyBucket() {
            foreach (var enteredObject in enteredObjects) {
                if (enteredObject.CompareTag("Bucket")) {
                    return enteredObject.GetComponent<Bucket>();
                }
            }
            return null;
        }
        
        private NumberPickup GetNearbyPickup() {
            foreach (var enteredObject in enteredObjects) {
                if (enteredObject.CompareTag("Pickup")) {
                    return enteredObject.GetComponent<NumberPickup>();
                }
            }
            return null;
        }
        
    }
}