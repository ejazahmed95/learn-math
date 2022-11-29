using UnityEngine;
using UnityEngine.InputSystem;

namespace LearnMath {
    public class PlayerMovement : MonoBehaviour {
        [SerializeField] private Rigidbody2D body;
        [SerializeField] private float moveSpeed = 1;

        private Vector2 _moveDir = new Vector2();
	
        private void Awake() {
            body = GetComponent<Rigidbody2D>();
        }
	
        public void OnMove(InputAction.CallbackContext ctx) {
            _moveDir = ctx.ReadValue<Vector2>();
        }

        private void FixedUpdate() {
            body.velocity = _moveDir * moveSpeed;
        }
    }
}