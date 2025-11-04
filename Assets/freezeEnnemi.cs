using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class freezeEnnemi : MonoBehaviour
{
    public WeaponsManager weaponsManager;
    public GameObject     PrefabEnnemi;
    public NavMeshAgent   ennemi_NavMeshAgent;
    public EnemyHealthManagement enemyHealthManagement;
    
    public static float speed = 2.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        ennemi_NavMeshAgent = GetComponent<NavMeshAgent>();
        ennemi_NavMeshAgent.speed = speed;
        
    }
    
    public IEnumerator FreezeDuration()

    {
        Debug.Log("Couroutine Freeze appelé");
        speed                     = 0f;
        ennemi_NavMeshAgent.speed = speed;
        Debug.Log("Ennemi gelé ! Enfin je crois...");
        yield return new WaitForSeconds(50f);
        speed                     = 2.5f;
        ennemi_NavMeshAgent.speed = speed;
        Debug.Log("Ennemi dégelé ! Normalement...");
        yield return new WaitForSeconds(1);
        enemyHealthManagement.freezeEnnemi = false;
        yield return new WaitForSeconds(1);
        enemyHealthManagement.freezeCoroutine = null;
    }
}