using System;
using Player_Scripts;
using UnityEngine;

public class HealthObject : MonoBehaviour
{
    [SerializeField] private AudioClip    recup;
    public                   GameObject   player;
    public                   PlayerHealth playerHealth;

    public AudioSource health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerHealth.playerHealth < 4)
            {
                playerHealth.GainHealth();
                Destroy(gameObject);  
            }
            
        }
    }
}
