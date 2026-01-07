using System;
using System.Collections;
using Player_Scripts;
using UnityEngine;
using UnityEngine.AI;

public class SeagullAIV2 : MonoBehaviour
{
    public  GameObject            player;
    public  Animator              animator;
    public  GameObject            proximityLight;
    private SeagullSpawner        spawner;
    public  GameObject            experiencepointPrefab;
    public  SpriteRenderer        spriteRenderer;
    public  float                 speed      = 3.5f;
    public  float                 speedReset = 3.5f;
    public  Rigidbody2D           rb;
    public  EnemyHealthManagement enemyHealthManagement;
    
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
    private bool       arrowInstantiated;
    public  bool       warningOver;
    private Vector2    freezePosition;
    public  GameObject dashTarget;
    public  float      dashSpeed              = 1f;
    public  float      dashSpeedReset              = 1f;
    public  float      endDashDistance        = 10f;
    
    
    enum SeagullState {Chasing, Waiting, Attacking}
    [SerializeField]private SeagullState state;
    
    private bool stateComplete;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawner = GameObject.FindWithTag("Player").GetComponent<SeagullSpawner>();
        playerHealth = player.GetComponent<PlayerHealth>();
        
    }

    void Update()
    {
        speed     = enemyHealthManagement.speedSeagull;
        waitSpeed = enemyHealthManagement.waitSpeedSeagull;
        
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

        if (player != null)
        {
            if (player.transform.position.x - gameObject.transform.position.x > 0f)
                spriteRenderer.flipX = false;
            else if (player.transform.position.x - gameObject.transform.position.x < 0f)
                spriteRenderer.flipX = true;
        }
        

        if (enemyHealthManagement.freezeEnnemi == true)
        {

            rb.bodyType = RigidbodyType2D.Static;
            
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

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
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

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

        dashTarget = transform.GetChild(3).gameObject; 
        //Debug.Log("cible est " + dashTarget);
        
        if (warningOver && player != null)
        {
            rb.linearVelocity = Vector2.zero; 
            Vector2 dashVecteur = (dashTarget.transform.position - transform.position).normalized;
            rb.AddForce(dashVecteur * dashSpeed, ForceMode2D.Impulse);
            
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance > endDashDistance)
            {
                endAttack();
            }
            
        }
        
    }

    void endAttack()
    {
        rb.linearVelocity = Vector2.zero;
        animator.Play("Flying");
        proximityLight.SetActive(false);
        arrowInstantiated = false;
        warningOver = false;
        attackTimerIsOver =  false;
        attackTimer = attackTimerReset;
        speed = speedReset;
        Destroy(transform.GetChild(3).gameObject);
        
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
