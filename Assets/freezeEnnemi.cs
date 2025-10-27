using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class freezeEnnemi : MonoBehaviour
{
    public WeaponsManager weaponsManager;
    public GameObject     PrefabEnnemi;
    public NavMeshAgent   ennemi_NavMeshAgent;

    public static float speed = 2.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        ennemi_NavMeshAgent = GetComponent<NavMeshAgent>();
        ennemi_NavMeshAgent.speed = speed;
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        while (weaponsManager.nombreAppareillePhoto >= 1)
        {
            if (other.gameObject.CompareTag("Ennemi"))
            {

                Debug.Log("Courroutune Flash lanc�");
                StartCoroutine(FreezeDuration());
                Debug.Log("Courroutune Freeze lanc�");

            }
        }
    }
    public IEnumerator FreezeDuration()

    {
        Debug.Log("Couroutine Freeze appel�");
        ennemi_NavMeshAgent       = GetComponent<NavMeshAgent>();
        ennemi_NavMeshAgent.speed = speed;
        speed                     = 0f;
        Debug.Log("Ennemi gel� ! Enfin je crois...");
        yield return new WaitForSeconds(weaponsManager.freezeDuration);
        speed = 2.5f;
        Debug.Log("Ennemi d�gel� ! Normalement...");
    }
}