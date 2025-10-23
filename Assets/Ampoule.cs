using System.Collections;
using JetBrains.Annotations;
using Player_Scripts;
using UnityEngine;
using UnityEngine.AI;

public class Ampoule : MonoBehaviour
{
    public GameObject ampoule;
    
    public int PVperdu = 1;
    public int HealthZombie = 5;
    public GameObject player;
    public bool IsHittenByBull = false;
    public GameObject recupAmpoule;
    public NavMeshAgent agent;
    public Coroutine coroutine;
    public GameObject PrefabEnnemi;
    public IAZombie iaZombie;
    public int levelAmpoule = 1;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IAZombie iaZombie = GetComponent<IAZombie>();
    }
    public void OnTrigger2D(Collider2D other)
    {
        if (other.CompareTag("Ennemi"))
        {
            PrefabEnnemi = other.gameObject;
            IsHittenByBull = true;
        }
    }
    
    IEnumerator PerteDePv()
        
    {
        if (IsHittenByBull == true)
        {

            coroutine = StartCoroutine(PerteDePv());
            if (HealthZombie <= 0)
            {
                Destroy(PrefabEnnemi);
            }
            Debug.Log("PV perdu");
            IsHittenByBull = false;
            yield return new WaitForSeconds(1);
            coroutine = null;
        }
    }
    public void RayonAmpoule()
    {
        StartCoroutine(PerteDePv());
    }// Update is called once per frame
    void Update()
    
        {

            
            if (player != null && agent.isOnNavMesh)
            {
                agent.destination = player.transform.position;
            }

            if (IsHittenByBull && coroutine == null)
            {
                coroutine = StartCoroutine(PerteDePv());
            }

           


        }
    
}
