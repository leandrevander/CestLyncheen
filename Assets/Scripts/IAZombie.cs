using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class IAZombie : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    public bool IsHitten = false;
    public int HealthZombie = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
    }
    IEnumerator PerteDePv()
    {
        yield return new WaitForSeconds(1);
        HealthZombie -= 1;
        Debug.Log("PV perdu");
    }
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            agent.destination = player.transform.position;
        }
        if (IsHitten == true)
        {
             StartCoroutine (PerteDePv());
        }
        if (HealthZombie <= 0)
        {
            Destroy(gameObject);
        }

    }
}
