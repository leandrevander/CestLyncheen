using System.Collections;
using JetBrains.Annotations;
using Player_Scripts;
using UnityEngine;
using UnityEngine.AI;


public class EnemyHealthManagement : MonoBehaviour
{
    public  bool           isHittenByFlashlight     = false;
    public bool IsHittenByBull = false;
    public bool IsHitByGlowStick = false;
    public bool freezeEnnemi = false;
    public  int            HealthZombie = 5;
    public  int            pvperdu;
    public bool IsHittenByLighthouse = false;
  
    public  Coroutine      coroutine;
    public  GameObject     experiencepointPrefab;
    public  freezeEnnemi   scriptFreeze;
    public  Coroutine      freezeCoroutine;
    public  WeaponsManager weaponsManager;
    private GameObject     player;
    public  NavMeshAgent   ennemi_NavMeshAgent;
    public  float          speed            = 2.5f;
    public  Coroutine      glowStickCoroutine;
    public  Coroutine      bulbCoroutine;
    public  float          FrezzeDuration   = 2f;
    public  Coroutine      lighthouseCoroutine;
    public  float          speedSeagull = 3.5f;

    public GameObject freezeEffect;
    public GameObject damageEffect;
    
    void Start()
    {
        player         = GameObject.FindGameObjectWithTag("Player");
        weaponsManager = player.GetComponent<WeaponsManager>();

        ennemi_NavMeshAgent       = GetComponent<NavMeshAgent>();
        if (ennemi_NavMeshAgent != null)
        {
            ennemi_NavMeshAgent.speed = speed;

        }
    }
    
    void Update()
    {
        if (ennemi_NavMeshAgent != null)
        {
            ennemi_NavMeshAgent.speed = speed;
        }
        
        if (isHittenByFlashlight == true && coroutine == null)
        {
            coroutine = StartCoroutine(PerteDePv());
        }

        if (freezeEnnemi == true && weaponsManager.haveCamera == true && freezeCoroutine == null)
        {
            freezeCoroutine = StartCoroutine(FreezeDuration());
        }


        if (IsHitByGlowStick == true && glowStickCoroutine == null)
        {

            glowStickCoroutine = StartCoroutine(HitByGlowStick());
        }

        if (IsHittenByBull && bulbCoroutine == null)
        {
            bulbCoroutine = StartCoroutine(HitByBulb());
        }
        
        if (IsHittenByLighthouse && lighthouseCoroutine == null)
        {
            lighthouseCoroutine = StartCoroutine(HitByLighthouse());
        }


        return;

        IEnumerator PerteDePv()
        {
            HealthZombie = HealthZombie - weaponsManager.hitByFlashlight;
            if (HealthZombie <= 0)
            {
                Destroy(gameObject);
                Instantiate(experiencepointPrefab, transform.position, transform.rotation);
            }
            
            damageEffect.SetActive(true);
            yield return new WaitForSeconds(1);
            damageEffect.SetActive(false);
            coroutine = null;
            isHittenByFlashlight  = false;
            
        }

        IEnumerator FreezeDuration()
        {
            freezeEffect.SetActive(true);
            if (ennemi_NavMeshAgent != null)
            {
                Debug.Log("Couroutine Freeze appelé");
                ennemi_NavMeshAgent.isStopped = true;
                Debug.Log("Ennemi gelé ! Enfin je crois...");
                yield return new WaitForSeconds(FrezzeDuration);
                ennemi_NavMeshAgent.isStopped = false;
                ennemi_NavMeshAgent.speed     = 2.5f;

                Debug.Log("Ennemi dégelé ! Normalement...");
                yield return new WaitForSeconds(1);
                freezeEnnemi = false;
                freezeEffect.SetActive(false);
                yield return new WaitForSeconds(1);
                freezeCoroutine = null;
            }
            else
            {
                Debug.Log("Couroutine Freeze appelé");
                speedSeagull = 0;
                Debug.Log("Ennemi gelé ! Enfin je crois...");
                yield return new WaitForSeconds(FrezzeDuration);
                speedSeagull     = 3.5f;

                Debug.Log("Ennemi dégelé ! Normalement...");
                yield return new WaitForSeconds(1);
                freezeEnnemi = false;
                freezeEffect.SetActive(false);
                yield return new WaitForSeconds(1);
                freezeCoroutine = null;
            }
        }

        IEnumerator HitByGlowStick()

        {
            if (IsHitByGlowStick == true)
            {
                HealthZombie = HealthZombie - weaponsManager.hitpoint;
                if (HealthZombie <= 0)

                {
                    Destroy(gameObject);
                }

                Debug.Log("PV Lampadaire");
                IsHitByGlowStick = false;
                damageEffect.SetActive(true);
                yield return new WaitForSeconds(1);
                damageEffect.SetActive(false);
                glowStickCoroutine = null;

            }
        }

        IEnumerator HitByBulb()

        {
            if (IsHittenByBull == true)
            {

                HealthZombie = HealthZombie - weaponsManager.hitByBulb;
                if (HealthZombie <= 0)
                {
                    Destroy(gameObject);
                }

                Debug.Log("PV perdu");
                IsHittenByBull = false;
                damageEffect.SetActive(true);
                yield return new WaitForSeconds(1);
                damageEffect.SetActive(false);
                bulbCoroutine = null;
            }
        }

        IEnumerator HitByLighthouse()
        {
            if (IsHittenByLighthouse == true)
            {
     
               HealthZombie = HealthZombie - weaponsManager.hitByLighthouse;
                if (HealthZombie <= 0)
                {
                    Destroy(gameObject);
                }
   
                IsHittenByLighthouse = false;
                damageEffect.SetActive(true);
                yield return new WaitForSeconds(1);
                damageEffect.SetActive(false);
                lighthouseCoroutine = null;
            }
        }

    }
}

