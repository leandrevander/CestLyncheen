using UnityEngine;
using UnityEngine.AI;

public class DolphinAI : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
    }
    
}
