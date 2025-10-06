using UnityEngine;
using UnityEngine.InputSystem;

namespace Player_Scripts
{
    public class PlayerControl : MonoBehaviour
    {
        public Rigidbody2D rb;
        public float moveSpeed;
        private Vector2 _moveDirection;
        public InputActionReference move;
        public SpriteRenderer spriteRenderer;

        private void Update()
        {
            _moveDirection = move.action.ReadValue<Vector2>();
        
            if (_moveDirection.x > 0.01f)
                spriteRenderer.flipX = true;
            else if (_moveDirection.x < -0.01f)
                spriteRenderer.flipX = false;
        }

        private void FixedUpdate()
        {
            rb.linearVelocity = new Vector2(x: _moveDirection.x, y: _moveDirection.y) * moveSpeed;
        }
    }
}

