using System.Collections;
using JetBrains.Annotations;
using Player_Scripts;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealthManagement : MonoBehaviour
{
    public        bool           IsHitten     = false;
    public        int            HealthZombie = 5;
    public        int            pvperdu;
    public        Coroutine      coroutine;
    public        GameObject     experiencepointPrefab;
    public        bool           freezeEnnemi = false;
    public        freezeEnnemi   scriptFreeze;
    public        Coroutine      freezeCoroutine;
    public        WeaponsManager weaponsManager;
    private       GameObject     player;
    public        NavMeshAgent   ennemi_NavMeshAgent;
    public  float          speed = 2.5f;
    

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
        if (freezeEnnemi == true && weaponsManager.haveCamera == true && freezeCoroutine == null )
        {
            freezeCoroutine = StartCoroutine(FreezeDuration());
        }
         
    }
    
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
    
    public IEnumerator FreezeDuration()

    {
        Debug.Log("Couroutine Freeze appelé");
        ennemi_NavMeshAgent.isStopped = true;
        Debug.Log("Ennemi gelé ! Enfin je crois...");
        yield return new WaitForSeconds(2f);
        ennemi_NavMeshAgent.isStopped = false;
        ennemi_NavMeshAgent.speed     = 2.5f;
        
        Debug.Log("Ennemi dégelé ! Normalement...");
        yield return new WaitForSeconds(1);
        freezeEnnemi = false;
        yield return new WaitForSeconds(1);
        freezeCoroutine = null;
    }

}
