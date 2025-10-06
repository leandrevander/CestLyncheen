using UnityEngine;
using UnityEngine.UI;

namespace Player_Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        public int playerHealth;

        [SerializeField] private Image[] hearts;
    
    
        private void Start()
        {
            UpdateHealth();
        }
    
        public void UpdateHealth()
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < playerHealth)
                {
                    hearts[i].color = Color.red;
                }
                else
                {
                    hearts[i].color = Color.black;
                }
            }
        }
    }
}
