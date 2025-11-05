using UnityEngine;
using UnityEngine.AI;


public class CameraDectector : MonoBehaviour
{
    private Transform             cibleZombie;
    public  GameObject            cibleEnnemi;
    public  GameObject            player;
    private float                 zombieDistance;
    private float                 distance;
    public  EnemyHealthManagement ennemyFrezze;
    public  LayerMask             raycastMask;
    public  NavMeshAgent          ennemi_NavMeshAgent;
    EnemyHealthManagement         enemyHealth;
    






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics2D.queriesHitTriggers = true;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ennemi"))
        {
            //cibleEnnemi = other.gameObject;


            cibleZombie = other.transform;
            Vector2 direction = (cibleZombie.position - player.transform.position).normalized;
            distance = Vector2.Distance(player.transform.position, cibleZombie.position);

            RaycastHit2D hit = Physics2D.Raycast(player.transform.position, direction, distance, raycastMask);

            Debug.DrawRay(player.transform.position, direction * distance, Color.green);

            if (hit.collider != null && hit.collider == other)
            { 
                enemyHealth = other.GetComponent<EnemyHealthManagement>(); 

<<<<<<< HEAD
                
                enemyHealth.freezeEnnemi = true;
=======
                ennemyFrezze = cibleZombie.GetComponent<EnemyHealthManagement>();
                ennemyFrezze.freezeEnnemi = true;
>>>>>>> origin/Thomas.T
                Debug.Log("Ennemi detecté");
               

            }
            else
            {
<<<<<<< HEAD
                enemyHealth.freezeEnnemi = false;
=======
                ennemyFrezze              = cibleZombie.GetComponent<EnemyHealthManagement>();
                ennemyFrezze.freezeEnnemi = false;
>>>>>>> origin/Thomas.T

            }


        }
    }

}



