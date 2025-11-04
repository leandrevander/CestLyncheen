using UnityEngine;
using UnityEngine.AI;


public class CameraDectector : MonoBehaviour
{
    private Transform cibleZombie;
    public GameObject player;
    private float zombieDistance;
    private float distance;
    public EnemyHealthManagement ennemyFrezze;
    public LayerMask raycastMask;
    public NavMeshAgent ennemi_NavMeshAgent;
    






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


            cibleZombie = other.transform;
            Vector2 direction = (cibleZombie.position - player.transform.position).normalized;
            distance = Vector2.Distance(player.transform.position, cibleZombie.position);

            RaycastHit2D hit = Physics2D.Raycast(player.transform.position, direction, distance, raycastMask);

            Debug.DrawRay(player.transform.position, direction * distance, Color.green);

            if (hit.collider != null && hit.collider == other)
            {

                ennemi_NavMeshAgent = cibleZombie.GetComponent<NavMeshAgent>();
                ennemyFrezze.freezeEnnemi = true;
                Debug.Log("Ennemi detecté");
               

            }
            else
            {
                ennemi_NavMeshAgent = cibleZombie.GetComponent<NavMeshAgent>();
                ennemyFrezze.freezeEnnemi = false;

            }


        }
    }

}



