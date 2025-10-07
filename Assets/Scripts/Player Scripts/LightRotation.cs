using UnityEngine;
using UnityEngine.InputSystem;

namespace Player_Scripts
{
    public class LightRotation : MonoBehaviour
    {
        public InputActionReference look;
        public Vector2 _lookDirection;
    
  
        public void SetLookDirection(InputAction.CallbackContext ctx)
        {
            float angle = Mathf.Atan2(_lookDirection.x,_lookDirection.y) * Mathf.Rad2Deg;
            _lookDirection = ctx.ReadValue<Vector2>();
            transform.localEulerAngles = new Vector3(0, 0,-angle);
        }
    
    }
}
