using System;
using System.Collections;
using Player_Scripts;
using UnityEngine;
using UnityEngine.AI;

public class SharkAI : MonoBehaviour
{
    public  GameObject            player;
    public  NavMeshAgent          agent;
    public  Animator              animator;
    public  GameObject            proximityLight;
    private SharkSpawner          spawner;
    public  GameObject            experiencepointPrefab;
    public  EnemyHealthManagement enemyHealthManagement;
    
    
    
    [Header("Damage To Player")]
    private PlayerHealth playerHealth;
    
    [Header("Waiting State Settings")]
    public float waitDistance;
    public float angle;
    public float waitSpeed = 0.7f;
    
    [Header("Attack Timer")]
    public float attackTimer = 30;
    public float attackTimerReset = 30;
    public bool timerIsRunning = false;
    public bool attackTimerIsOver = false;

    [Header("Attacking")] 
    public float attackSpeed = 8;
    public float agentSpeedReset = 2;
            
    enum SharkState {Chasing, Waiting, Attacking}
    private SharkState state;
    
    private bool stateComplete;
        
    void Start()
    {
        player               = GameObject.FindWithTag("Player");
        agent                = GetComponent<NavMeshAgent>();
        spawner              = GameObject.FindWithTag("Player").GetComponent<SharkSpawner>();
        agent.updateRotation = false;
        agent.updateUpAxis   = false;
        playerHealth         = player.GetComponent<PlayerHealth>();
        
    }

    void Update()
    {
        attackSpeed = enemyHealthManagement.attackSpeedShark;
        waitSpeed   = enemyHealthManagement.waitSpeedShark;

        if (stateComplete)
        {
            SelectState();
        }
        
        UpdateState();
        
        //Debug.Log(state);
        
        
        
    }

    void SelectState()
    {
        stateComplete = false;

        if (attackTimerIsOver)
        {
            state = SharkState.Attacking;
        }
        else 
        {
            if ((player.transform.position.x - gameObject.transform.position.x < waitDistance &&
                 player.transform.position.x - gameObject.transform.position.x > -waitDistance) &&
                (player.transform.position.y - gameObject.transform.position.y < waitDistance &&
                 player.transform.position.y - gameObject.transform.position.y > -waitDistance))
            {
                state = SharkState.Waiting;
            }
            else 
            {
                state = SharkState.Chasing;
            }
        }
    }

    void UpdateState()
    {
        switch (state)
        {
            case SharkState.Chasing:
                UpdateChasing();
                break;
            case SharkState.Waiting:
                UpdateWaiting();
                break;
            case SharkState.Attacking:
                UpdateAttacking();
                break;
        }
    }

    void UpdateChasing()
    {

        if (player != null && agent.isOnNavMesh)
        {
            agent.destination = player.transform.position;


            if ((player.transform.position.x - gameObject.transform.position.x < waitDistance &&
                 player.transform.position.x - gameObject.transform.position.x > -waitDistance) && (player.transform.position.y - gameObject.transform.position.y < waitDistance &&
                                                                                                    player.transform.position.y - gameObject.transform.position.y > -waitDistance))
            {
                if (agent.isStopped == false)
                {
                    stateComplete = true;
                }
            }
        }
    }

    void UpdateWaiting()
    {
        
        angle += Time.deltaTime * waitSpeed;
        
        float x = Mathf.Cos(angle) * waitDistance;
        float y = Mathf.Sin(angle) * waitDistance;

        if (agent.isStopped == false)
        {
            transform.position = player.transform.position + new Vector3(x, y, 0);
 
        }
        
        timerIsRunning = true;
        
        if ((timerIsRunning) && (agent.isStopped == false))
        {
            if (attackTimer > 0)
            {
                attackTimer -=  Time.deltaTime;
            }
            else
            {
                timerIsRunning = false;
                attackTimer = 0;
                attackTimerIsOver = true;
                stateComplete = true;
            }
        }
        
    }

    void UpdateAttacking()
    {
        
        animator.SetBool("WarningAnim", true);
        proximityLight.SetActive(true);
            
        agent.speed = attackSpeed;
        
        if (player != null && agent.isOnNavMesh)
        {
            agent.destination = player.transform.position;
        }
        
    }

    void EndAttacking()
    {
        animator.SetBool("WarningAnim", false);
        animator.Play("Chase");
        attackTimerIsOver = false;
        attackTimer = attackTimerReset;
        agent.speed = agentSpeedReset;
        proximityLight.SetActive(false);
        
        stateComplete = true;
    }
    
    //Scripts Léandre

    
    
    private void OnTriggerStay2D(Collider2D other)
    {
       if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
           {
               //Debug.Log("ça marche");
               playerHealth.playerhitten = true;
           } 
       
        if (other.gameObject.layer == LayerMask.NameToLayer("Offside"))
           {
               Destroy(gameObject);
               spawner.SpawnEnemy();
               //Debug.Log("zombie spawn à un autre endroit");
           }
       
    }
    
}
