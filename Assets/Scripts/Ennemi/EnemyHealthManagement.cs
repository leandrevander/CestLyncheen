using System.Collections;
using JetBrains.Annotations;
using Player_Scripts;
using UnityEngine;
using UnityEngine.AI;


public class EnemyHealthManagement : MonoBehaviour
{
    public  bool           IsHitten     = false;
    public bool IsHittenByBull = false;
    public bool IsHitByGlowStick = false;
    public bool freezeEnnemi = false;
    public  int            HealthZombie = 5;
    public  int            pvperdu;
  
    public  Coroutine      coroutine;
    public  GameObject     experiencepointPrefab;
    public  freezeEnnemi   scriptFreeze;
    public  Coroutine      freezeCoroutine;
    public  WeaponsManager weaponsManager;
    private GameObject     player;
    public  NavMeshAgent   ennemi_NavMeshAgent;
    public  float          speed            = 2.5f;
    public  Coroutine      glowStickCoroutine;
    public Coroutine      bulbCoroutine;
    public  float          FrezzeDuration   = 2f;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player         = GameObject.FindGameObjectWithTag("Player");
        weaponsManager = player.GetComponent<WeaponsManager>();

        ennemi_NavMeshAgent       = GetComponent<NavMeshAgent>();
        ennemi_NavMeshAgent.speed = speed;
    }


    // Update is called once per frame
    void Update()
    {
        ennemi_NavMeshAgent.speed = speed;
        if (IsHitten && coroutine == null)
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


        return;

        IEnumerator PerteDePv()
        {


            HealthZombie = HealthZombie - pvperdu;
            if (HealthZombie <= 0)
            {
                Destroy(gameObject);
                Instantiate(experiencepointPrefab, transform.position, transform.rotation);
            }


            Debug.Log("PV perdu");
            IsHitten = false;
            yield return new WaitForSeconds(1);
            coroutine = null;
        }

        IEnumerator FreezeDuration()


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
            yield return new WaitForSeconds(1);
            freezeCoroutine = null;
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
                yield return new WaitForSeconds(1);
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
                yield return new WaitForSeconds(1);
                bulbCoroutine = null;
            }
        }

    }
}

