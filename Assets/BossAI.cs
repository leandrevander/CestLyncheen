using System.Collections;
using JetBrains.Annotations;
using Player_Scripts;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public GameObject experiencepointPrefab;
    public GameObject player;
    public NavMeshAgent agent;
    
    private SnailSpawner spawner;
    
    private PlayerHealth playerHealth;
    public SpriteRenderer spriteRenderer;
    public float proximity;
    public GameObject proximityLight;
    public Bulb ampouleScript;
   
    
    [SerializeField] private Animator animatorPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawner = GameObject.FindWithTag("Player").GetComponent<SnailSpawner>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        playerHealth = player.GetComponent<PlayerHealth>();

    }

   

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if ((player.transform.position.x - gameObject.transform.position.x < proximity &&
                 player.transform.position.x - gameObject.transform.position.x > -proximity) && (player.transform.position.y - gameObject.transform.position.y < proximity &&
                                                                                                 player.transform.position.y - gameObject.transform.position.y > -proximity))
            {
                animatorPlayer.Play("Warning");
                proximityLight.SetActive(true);
            }
            else
            {
                animatorPlayer.Play("Chase");
                proximityLight.SetActive(false);
            }


            if (player != null && agent.isOnNavMesh)
            {
                agent.destination = player.transform.position;
            }


            if (player.transform.position.x - gameObject.transform.position.x > 0f)
                spriteRenderer.flipX = false;
            else if (player.transform.position.x - gameObject.transform.position.x < 0f)
                spriteRenderer.flipX = true;

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Offside"))
        {
            Destroy(gameObject);
            spawner.SpawnEnemy();
            Debug.Log("zombie spawn à un autre endroit");
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("ça marche");
            playerHealth.playerhittenByBoss = true;

        }
    }
}    
