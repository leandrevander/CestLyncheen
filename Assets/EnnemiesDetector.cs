using System;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiesDetector : MonoBehaviour
{
    [SerializeField] AudioSource      detection;
    public           List<GameObject> enemies = new List<GameObject>();

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ennemi"))
        {
            enemies.Add(other.gameObject);
        }
    }

    void Update()
    {
        
        if (enemies.Count <= 10)
        {
            detection.pitch = 1;
        }
        if (enemies.Count <= 15 && (enemies.Count > 10))
        {
            detection.pitch = 1.5f;
        }
        if (enemies.Count <= 20 && enemies.Count > 15)
        {
            detection.pitch = 2;
        }
        if (enemies.Count >= 25 && enemies.Count > 20)
        {
            detection.pitch = 2.5f;
        }
        if (enemies.Count >= 30 && enemies.Count > 25)
        {
            detection.pitch = 3f;
        }
    }
}


// Update is called once per frame
 
