using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class IAZombie : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    public bool IsHitten = false;
    public int HealthZombie = 5;
    private Spawner  spawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawner = GameObject.FindWithTag("Player").GetComponent<Spawner>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
    }
    IEnumerator PerteDePv()
    {
        
        HealthZombie --;
        if (HealthZombie <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("PV perdu");
        IsHitten = false;
        yield return new WaitForSeconds(1);
    }
    // Update is called once per frame
    void Update()
    {
        if (player != null && agent.isOnNavMesh)
        {
            agent.destination = player.transform.position;
        }
        if (IsHitten)
        {
             StartCoroutine (PerteDePv());
        }
        
        

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Destroy(gameObject);
            spawner.SpawnEnemy();
            Debug.Log("zombie spawn à un autre endroit");
        }
    }
}
