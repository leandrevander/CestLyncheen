using System.Collections;
using Player_Scripts;
using UnityEngine;
using UnityEngine.AI;

public class DolphinAI : MonoBehaviour
{
    public GameObject player;
    private Spawner spawner;
    public GameObject experiencepointPrefab;
    public SpriteRenderer spriteRenderer;
    public float destroyDistance = 80f;
    
    [Header("Warning")]
    public Animator animator;
    public GameObject proximityLight;
    public float proximity;
    
    [Header("Damage To Dolphin")]
    public bool IsHitten = false;
    public int HealthZombie = 5;
    private Coroutine coroutine;
    public int pvperdu;
    
    [Header("Damage To Player")]
    private PlayerHealth playerHealth;
    
    [Header("Dash Settings")]
    public bool dashRight;
    public bool dashLeft;
    public float dashSpeed = 6f;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawner = GameObject.FindWithTag("Player").GetComponent<Spawner>();
        playerHealth = player.GetComponent<PlayerHealth>();
        
        dashRight = false;
        dashLeft = false;
        ChooseDirection();
    }

    void Update()
    {
        if ((player.transform.position.x - gameObject.transform.position.x < proximity &&
             player.transform.position.x - gameObject.transform.position.x > -proximity) && (player.transform.position.y - gameObject.transform.position.y < proximity &&
                player.transform.position.y - gameObject.transform.position.y > -proximity))
        {
            //animatorPlayer.Play("Warning");
            proximityLight.SetActive(true);
        }
        else
        {
            //animatorPlayer.Play("Chase");
            proximityLight.SetActive(false);
        }
        
        if (IsHitten && coroutine == null)
        {
            coroutine = StartCoroutine(PerteDePv());
        }

        if (dashRight)
        {
            DashRight();
        }
        
        if (dashLeft)
        {
            DashLeft();
        }
        
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance > destroyDistance)
        {
            Debug.Log("shouldDestroy");
            Destroy(gameObject);
        }
        
    }

    void ChooseDirection()
    {

        if (player.transform.position.x - gameObject.transform.position.x > 0f)
        {
           spriteRenderer.flipX = false;
           dashRight = true;
           //Debug.Log("Right Chose"); 
        }
        if (player.transform.position.x - gameObject.transform.position.x < 0f)
        {
            spriteRenderer.flipX = true;
            dashLeft = true;
            //Debug.Log("Left Chose");
        }
            
    }

    void DashRight()
    {
        transform.Translate(Vector2.right * Time.deltaTime * dashSpeed);
    }

    void DashLeft()
    {
        transform.Translate(Vector2.left * Time.deltaTime * dashSpeed);
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

        if (other.gameObject.layer == LayerMask.NameToLayer("Offside"))
        {
            Destroy(gameObject);
            spawner.SpawnEnemy();
            //Debug.Log("zombie spawn à un autre endroit");
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //Debug.Log("ça marche");
            playerHealth.playerhitten = true;

        }
    }
    #endregion
}
