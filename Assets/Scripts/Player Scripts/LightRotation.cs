using UnityEngine;

namespace Player_Scripts
{
    public class LightRotation : MonoBehaviour
    {
        public Vector2 _lookDirection;
        
        public void UpdateLook(Vector2 lookDirection)
        {
            if (lookDirection.sqrMagnitude < 0.01f) return;

            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            transform.localEulerAngles = new Vector3(0, 0, angle - 90f);
        }
    
    }
}
