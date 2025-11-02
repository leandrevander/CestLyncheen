using System;
using System.Collections;
using JetBrains.Annotations;
using Player_Scripts;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;
public class StreetLamp : MonoBehaviour
{
    public int PVperdu = 1;
    public GameObject player;
    public bool IsHittenByStreetLamp = false;
    public GameObject recupStreetLamp;
    public Coroutine coroutine;
    public EnemyHealthManagement enemyHealthManagement;
    public int levelStreetLamp = 1;
    public Light2D bulbLight;
    public NavMeshAgent agent;
    public int hitpoint = 1;
    public WeaponsManager weaponsManager;
    public Coroutine streetLampCoroutine;
    public GameObject prefabStreetLamp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyHealthManagement = GetComponent<EnemyHealthManagement>();
    }
    public void OnTrigger2D(Collider2D other)
    {
        if (other.CompareTag("Ennemi"))
        {
            IsHittenByStreetLamp = true;

        }
    }
   public IEnumerator StreetLampSpwan()
    {
        Debug.Log("Street Lamp Spawned");

        yield return new WaitForSeconds(10);
        weaponsManager.numberOfStreetLamps -= 1;
        Destroy(prefabStreetLamp);

    }
    IEnumerator HitByStreetLamp()

    {
        if (IsHittenByStreetLamp == true)
        {
            enemyHealthManagement.HealthZombie = enemyHealthManagement.HealthZombie - hitpoint;
            if (enemyHealthManagement.HealthZombie <= 0)
            {
                Destroy(gameObject);
            }
            Debug.Log("PV perdu");
            IsHittenByStreetLamp = false;
            yield return new WaitForSeconds(1);
            
            coroutine = null;



        }
    }
    public void Update()

    {
        if (IsHittenByStreetLamp == true)
        {

            coroutine = StartCoroutine(HitByStreetLamp());
        }

        if (player != null && agent.isOnNavMesh)
        {
            agent.destination = player.transform.position;
        }

       




    }


}
