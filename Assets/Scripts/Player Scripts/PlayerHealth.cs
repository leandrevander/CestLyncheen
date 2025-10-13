using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Player_Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        public int playerHealth;
        public bool invincible ;
        public bool playerhitten;
        private Coroutine coroutine;
        

        [SerializeField] private Image[] hearts;
    
    
        private void Start()
        {
            UpdateHealth();
            invincible = false;
            playerhitten = false;
        }

        void Update()
        {
            if (playerhitten && coroutine == null && invincible == false)
            {
                coroutine = StartCoroutine(Damage());
                Debug.Log("les conditions sont reunis");
            }
        }
        

        public IEnumerator Damage()
        {
                invincible = true;
                playerHealth--;
                print(playerHealth);
                UpdateHealth();
                yield return new WaitForSeconds(1);
                invincible = false;
                playerhitten = false;
                coroutine = null;
                StopCoroutine(Damage());
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
