using UnityEngine;
using UnityEngine.InputSystem;

namespace Player_Scripts
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] AudioSource moveSound;
        public Rigidbody2D rb;
        public float moveSpeed;
        private Vector2 _moveDirection;
        public InputActionReference move;
        public SpriteRenderer spriteRenderer;
        
        public InputActionReference look;
        
        public LightRotation playerLight;
        
        public Vector2 _lookDirection;

        public Transform cameraGO;
        
        
        [SerializeField] private Animator animatorPlayer;
        
        private void OnEnable()
        {
            
            move.action.Enable();
            look.action.Enable();
        }
        
        private void OnDisable()
        {
            move.action.Disable();
            look.action.Disable();
        }
        
        private void Update()
        {
            
            _moveDirection = move.action.ReadValue<Vector2>();
            animatorPlayer.SetFloat("Velocity", _moveDirection.magnitude);
            
            _lookDirection = look.action.ReadValue<Vector2>();
            playerLight.UpdateLook(_lookDirection);

            if (_moveDirection.x > 0.01f)
            {
                
                spriteRenderer.flipX   = false;
                cameraGO.localRotation = Quaternion.Euler(0.0f, 0.0f, -90f);
            }
               
                
        
            else if (_moveDirection.x < -0.01f)
            {
                spriteRenderer.flipX   = true;
                cameraGO.localRotation = Quaternion.Euler(0.0f, 0.0f, 90f);
            }

           
                
        }

        private void FixedUpdate()
        {
            rb.linearVelocity = new Vector2(x: _moveDirection.x, y: _moveDirection.y) * moveSpeed;
        }
    }
    
}

