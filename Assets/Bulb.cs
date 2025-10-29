using System;
using System.Collections;
using JetBrains.Annotations;
using Player_Scripts;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;
public class Bulb : MonoBehaviour
{
    public GameObject ampoule;
    
    public int              PVperdu      = 1;
    public int              HealthZombie = 5;
    public GameObject       player;
    public bool             IsHittenByBull = false;
    public GameObject       recupAmpoule;
    public NavMeshAgent     agent;
    public Coroutine        coroutine;
    public GameObject       PrefabEnnemi;
    public EnemyHealthManagement         enemyHealthManagement;
    public int              levelAmpoule = 1;
    public CircleCollider2D bulbl1;
    public CircleCollider2D bulbl2;
    public CircleCollider2D bulbl3;
    public GameObject       bulb;
    public Light2D bulbLight;
    public float rangeIncrease = 1.5f;
    public float minRange = 0f;
    public float maxRangeOuter = 3.8f;
    public float maxRangeInner = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyHealthManagement = GetComponent<EnemyHealthManagement>();
    }
    public void OnTrigger2D(Collider2D other)
    {
        if (other.CompareTag("Ennemi"))
        {
            PrefabEnnemi = other.gameObject;
            IsHittenByBull = true;
            
        }
    }
    
    public void  BulbLevel2()
    {
        bulbLight.pointLightOuterRadius = 5;
        bulbLight.pointLightInnerRadius = 4;
        
        

    }
    public void  BulbLevel4()
    {
        bulbLight.pointLightOuterRadius = 6;
        bulbLight.pointLightInnerRadius = 5;

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
