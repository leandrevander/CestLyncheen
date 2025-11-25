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
        private Coroutine coroutine2;
        public GameObject playerDamageOverlay;
        public SpriteRenderer playerSpriteRenderer;
        

        [SerializeField] private Animator[] hearts;
    
    
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
                Debug.Log("les conditions sont reunies");
            }
        }
        

        public IEnumerator Damage()
        {
            
                if (coroutine2 == null)
                {
                    coroutine2 = StartCoroutine(InvincibleFeedback());
                }
                
                playerDamageOverlay.SetActive(true);
                invincible = true;
                playerHealth--;
                print(playerHealth);
                UpdateHealth();
                yield return new WaitForSeconds(1);
                playerDamageOverlay.SetActive(false);
                invincible = false;
                playerhitten = false;
                coroutine = null;
                StopCoroutine(Damage());
        }

        public IEnumerator InvincibleFeedback()
        {
            playerSpriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            playerSpriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
            playerSpriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            playerSpriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
            playerSpriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            playerSpriteRenderer.enabled = true;
            coroutine2 = null;
            StopCoroutine(InvincibleFeedback());
        }


        public void GainHealth()
        {
            playerHealth++;
            UpdateHealth();
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
                    hearts[i].Play("Hitpoint Full");
                }
                else
                {
                    hearts[i].Play("Hitpoint Empty");
                }
            }
        }
    }
}
