using System;
using System.Collections;
using Player_Scripts;
using UnityEngine;
using UnityEngine.AI;

public class SeagullAI : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    public Animator animator;
    public GameObject proximityLight;
    private Spawner spawner;
    public GameObject experiencepointPrefab;
    public SpriteRenderer spriteRenderer;
    
    [Header("Damage To Seagull")]
    public bool IsHitten = false;
    public int HealthZombie = 5;
    private Coroutine coroutine;
    public int pvperdu;
    
    [Header("Damage To Player")]
    private PlayerHealth playerHealth;
    
    [Header("Waiting State Settings")]
    public float waitDistance;
    public float waitSpeed= 1.9f;
    public float glideAmplitude = 1f;
    public float glideSpeed = 2f;
    private Vector2 target;
    
    [Header("Attack Timer")]
    public float attackTimer = 30;
    public float attackTimerReset = 30;
    public bool timerIsRunning = false;
    public bool attackTimerIsOver = false;

    [Header("Attack State")] 
    public GameObject warningArrow;
    private bool arrowInstantiated;
    public bool warningOver;
    private Vector2 freezePosition;
    public GameObject dashTarget;
    public float dashSpeed = 22f;
    public float dashAcceleration = 22f;
    public float agentSpeedReset = 3.5f;
    public float agentAccelerationReset = 8;
    public float endDashDistance = 10f;
    
    
    enum SeagullState {Chasing, Waiting, Attacking}
    private SeagullState state;
    
    private bool stateComplete;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        spawner = GameObject.FindWithTag("Player").GetComponent<Spawner>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        playerHealth = player.GetComponent<PlayerHealth>();
        
    }

    void Update()
    {
        
        if (stateComplete)
        {
            SelectState();
        }
        
        UpdateState();
        
        Debug.Log(state);
        
        if (IsHitten && coroutine == null)
        {
            coroutine = StartCoroutine(PerteDePv());
        }
        
        if (player.transform.position.x - gameObject.transform.position.x > 0f)
            spriteRenderer.flipX = false;
        else if (player.transform.position.x - gameObject.transform.position.x < 0f)
            spriteRenderer.flipX = true;
        
    }

    void SelectState()
    {
        stateComplete = false;

        if (attackTimerIsOver)
        {
            state = SeagullState.Attacking;
        }
        else
        {
            if ((player.transform.position.x - gameObject.transform.position.x < waitDistance &&
                         player.transform.position.x - gameObject.transform.position.x > -waitDistance) &&
                        (player.transform.position.y - gameObject.transform.position.y < waitDistance &&
                         player.transform.position.y - gameObject.transform.position.y > -waitDistance))
            {
                state = SeagullState.Waiting;
            }
            else
            {
                state = SeagullState.Chasing;
            }
        }

        
        
    }

    void UpdateState()
    {
        switch (state)
        {
            case SeagullState.Chasing:
                UpdateChasing();
                break;
            case SeagullState.Waiting:
                UpdateWaiting();
                break;
            case SeagullState.Attacking:
                UpdateAttacking();
                break;
        }
    }


    void UpdateChasing()
    {
        if (player != null && agent.isOnNavMesh)
        {
            agent.destination = player.transform.position;
        }
        
        if ((player.transform.position.x - gameObject.transform.position.x < waitDistance &&
             player.transform.position.x - gameObject.transform.position.x > -waitDistance) && (player.transform.position.y - gameObject.transform.position.y < waitDistance &&
                player.transform.position.y - gameObject.transform.position.y > -waitDistance))
        {
            stateComplete = true;
        }
    }
    
    
    void UpdateWaiting()
    {
        Vector2 waitPostion = transform.position;
        target = (Vector2)player.transform.position + waitPostion * waitDistance;
        
        Vector2 directionToPlayer = (transform.position - player.transform.position).normalized;
        target = (Vector2)player.transform.position + directionToPlayer * waitDistance;
        
        transform.position = Vector2.Lerp(transform.position, target, waitSpeed * Time.deltaTime);
        
        float bob = Mathf.Sin(Time.time * glideSpeed) * glideAmplitude;
        transform.position = Vector2.MoveTowards(transform.position, target, bob * Time.deltaTime);
        
        timerIsRunning = true;
        
        if (timerIsRunning)
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
                freezePosition = transform.position;
                
                stateComplete = true;
            }
        }
    }
    

    void UpdateAttacking()
    {
        animator.Play("Warning");
        proximityLight.SetActive(true);

        if (warningOver == false)
        {
            transform.position = freezePosition;
        }

        if (arrowInstantiated == false)
        {
           float angle = Mathf.Atan2(player.transform.position.y - gameObject.transform.position.y, player.transform.position.x - gameObject.transform.position.x) * Mathf.Rad2Deg;
           Quaternion rotation = Quaternion.Euler(0,0,angle);
           Instantiate(warningArrow, player.transform.position, rotation, transform);
           
           arrowInstantiated = true; 
        }

        dashTarget = transform.GetChild(1).gameObject; 
        //Debug.Log("cible est " + dashTarget);
        
        if (warningOver)
        {
            agent.speed = dashSpeed;
            agent.acceleration = dashAcceleration;
            agent.autoBraking = false;
            
            if (player != null && agent.isOnNavMesh)
            {
                agent.destination = dashTarget.transform.position;
            }
            
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance > endDashDistance)
            {
                endAttack();
            }
            
        }
        
    }

    void endAttack()
    {
        animator.Play("Flying");
        proximityLight.SetActive(false);
        arrowInstantiated = false;
        warningOver = false;
        attackTimerIsOver =  false;
        attackTimer = attackTimerReset;
        agent.speed = agentSpeedReset;
        agent.acceleration = agentAccelerationReset;
        agent.autoBraking = true;
        Destroy(transform.GetChild(1).gameObject);
        
        stateComplete = true;
    }
    
    
    
    

    #region Léandre

    IEnumerator PerteDePv()
    {

        HealthZombie = HealthZombie - pvperdu;
        if (HealthZombie <= 0)
        {
            Destroy(gameObject);
            Instantiate(experiencepointPrefab, transform.position, transform.rotation);
        }

        //Debug.Log("PV perdu");
        IsHitten = false;
        yield return new WaitForSeconds(1);
        coroutine = null;
    }
    
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
    
    #endregion
    
}
