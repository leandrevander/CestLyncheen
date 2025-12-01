using System;
using Player_Scripts;
using UnityEngine;

public class HealthObject : MonoBehaviour
{
    [SerializeField] AudioSource healSound;
    public GameObject player;
    public PlayerHealth playerHealth;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerHealth.playerHealth < 4)
            {
                healSound.Play();
                playerHealth.GainHealth();
                Destroy(gameObject);  
            }
            
        }
    }
}
