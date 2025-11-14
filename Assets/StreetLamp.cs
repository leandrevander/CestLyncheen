using System;
using System.Collections;
using JetBrains.Annotations;
using Player_Scripts;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;
public class StreetLamp : MonoBehaviour
{
    public EnemyHealthManagement enemyHealthManagement;

    // Start is called once before the first execution of Update after the MonoBehaviour is create
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ennemi"))
        {
            enemyHealthManagement = other.GetComponent<EnemyHealthManagement>();
            enemyHealthManagement.IsHitByGlowStick = true;
            
            Debug.Log("Lampadaire");

        }
    }
}




