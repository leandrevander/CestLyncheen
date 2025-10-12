using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Player_Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        public int playerHealth;
        public bool peutPrendreDesDegats = true;
        

        [SerializeField] private Image[] hearts;
    
    
        private void Start()
        {
            UpdateHealth();
        }
        

        public IEnumerator Damage()
        {
            peutPrendreDesDegats = false;
            playerHealth--;
            print(playerHealth);
            UpdateHealth();
            yield return new WaitForSeconds(1);
            peutPrendreDesDegats = true;
        }
         

        
        
    
        public void UpdateHealth()
        {
            if (playerHealth <= 0)
            {
               Destroy(gameObject); 
            }
            
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
