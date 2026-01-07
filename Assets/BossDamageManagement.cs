using Player_Scripts;
using UnityEngine;

public class BossDamageManagement : MonoBehaviour
{
    public PlayerHealth playerHealth;
    
    void Start()
    {
        playerHealth = GameObject.Find ("Playerv3").GetComponent<PlayerHealth> ();

    }

    void Update()
    {

    }
}
