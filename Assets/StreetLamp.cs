using System;
using System.Collections;
using JetBrains.Annotations;
using Player_Scripts;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;
public class StreetLamp : MonoBehaviour
{
    public GameObject player;
    public bool IsHittenByGlowStick = false;
    public GameObject recupGlowStick;
    public Coroutine coroutine;
    public EnemyHealthManagement enemyHealthManagement;
    public int levelGlowStick = 1;
    public Light2D bulbLight;
    public NavMeshAgent agent;
    public int hitpoint = 1;
    public WeaponsManager weaponsManager;
    public Coroutine GlowStickCoroutine;
    public GameObject prefabGlowStick;
    public GameObject prefabEnnemi;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyHealthManagement = GetComponent<EnemyHealthManagement>();
    }
    public void OnTrigger2D(Collider2D other)
    {
        if (other.CompareTag("Ennemi"))
        {
            IsHittenByGlowStick = true;
            Debug.Log("Lampadaire");

        }
    }
   
    IEnumerator HitByGlowStick()

    {
        if (IsHittenByGlowStick == true)
        {
            enemyHealthManagement.HealthZombie = enemyHealthManagement.HealthZombie - hitpoint;
            if (enemyHealthManagement.HealthZombie <= 0)
            {
                Destroy(prefabEnnemi);
            }
            Debug.Log("PV perdu");
            IsHittenByGlowStick = false;
            yield return new WaitForSeconds(1);
            coroutine = null;



        }
    }
    public void Update()

    {
        if (IsHittenByGlowStick == true)
        {

            coroutine = StartCoroutine(HitByGlowStick());
        }

        if (player != null && agent.isOnNavMesh)
        {
            agent.destination = player.transform.position;
        }

       




    }


}
