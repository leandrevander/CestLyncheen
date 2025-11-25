using UnityEngine;
using UnityEngine.Rendering.Universal;


public class DetectorLight : MonoBehaviour
{
    private Transform             cibleZombie;
    public  GameObject            player;
    private float                 zombieDistance;
    private float                 distance;
    private EnemyHealthManagement enemyHealth;
    private ShadowBubble shadowBubble;
    public  LayerMask             raycastMask;
    private WeaponsManager        weaponsManager;
    public  Light2D               flashlightLight;
    public  PolygonCollider2D     flashlightCollider;
    
    [SerializeField] private Vector2[] flashlightCollider2DArray;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics2D.queriesHitTriggers = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ennemi"))
        {


            cibleZombie = other.transform;
            Vector2 direction = (cibleZombie.position - player.transform.position).normalized;
            distance = Vector2.Distance(player.transform.position, cibleZombie.position);

            RaycastHit2D hit = Physics2D.Raycast(player.transform.position, direction, distance, raycastMask);

            Debug.DrawRay(player.transform.position, direction * distance, Color.red);

            if (hit.collider != null && hit.collider == other)
            {

                enemyHealth = cibleZombie.GetComponent<EnemyHealthManagement>();

                Debug.Log("LE RAYCAST TOUCHE LE ZOMBIE DIEU MERCI");
                enemyHealth.isHittenByFlashlight = true;


            }
            else
            {
                enemyHealth                      = cibleZombie.GetComponent<EnemyHealthManagement>();
                enemyHealth.isHittenByFlashlight = false;

            }



        }

        else if (other.CompareTag("ShadowBubble"))
        {


            cibleZombie = other.transform;
            Vector2 direction = (cibleZombie.position - player.transform.position).normalized;
            distance = Vector2.Distance(player.transform.position, cibleZombie.position);

            RaycastHit2D hit = Physics2D.Raycast(player.transform.position, direction, distance, raycastMask);

            Debug.DrawRay(player.transform.position, direction * distance, Color.red);

            if (hit.collider != null && hit.collider == other)
            {

                shadowBubble = cibleZombie.GetComponent<ShadowBubble>();

                Debug.Log("LE RAYCAST TOUCHE LA BUBBLE DIEU MERCI");
                shadowBubble.isHittenByFlashlight = true;


            }
            else
            {
                shadowBubble                      = cibleZombie.GetComponent<ShadowBubble>();
                shadowBubble.isHittenByFlashlight = false;

            }
        }
    }


    // Flashlight level 4 upgrade : Range
    public void FlashlightLevel3()
    {
        
        flashlightLight.pointLightOuterRadius = 13;
        flashlightLight.falloffIntensity      = 0.3f;

        flashlightCollider.SetPath(0, flashlightCollider2DArray);
    }





}

   

