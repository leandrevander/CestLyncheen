using Player_Scripts;
using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int enemyDamage;
    [SerializeField] private PlayerHealth _playerHealth;
    public GameObject player;
    private Coroutine coroutine;

    

    void Start()
    {
        player = GameObject.FindWithTag("Player"); 
    }

   // private void OnTriggerStay2D(Collider2D collision)
   // {
     //   _playerHealth = player.GetComponent<PlayerHealth>();
    //    if (collision.CompareTag("Player") && _playerHealth.peutPrendreDesDegats  )
     //   {
     //       coroutine =StartCoroutine(Damage());
     //   }
   // }

   //public IEnumerator Damage()
    //{
       // _playerHealth.playerHealth = _playerHealth.playerHealth - enemyDamage;
       // _playerHealth.UpdateHealth();
       // _playerHealth.peutPrendreDesDegats = false;
       // yield return new WaitForSeconds(1);
       // _playerHealth.peutPrendreDesDegats = true;
       // coroutine = null;
   // }
}