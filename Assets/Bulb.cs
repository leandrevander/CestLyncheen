using System;
using System.Collections;
using JetBrains.Annotations;
using Player_Scripts;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;
public class Bulb : MonoBehaviour
{
    public GameObject ampoule;
    public EnemyHealthManagement         enemyHealthManagement;
    public int              levelAmpoule = 1;
    public CircleCollider2D bulbl1;
    public CircleCollider2D bulbl2;
    public CircleCollider2D bulbl3;
    public GameObject       bulb;
    public Light2D bulbLight;
    public float rangeIncrease = 1.5f;
    public float minRange = 0f;
    public float maxRangeOuter = 3.8f;
    public float maxRangeInner = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ennemi"))
        {
            enemyHealthManagement                = other.GetComponent<EnemyHealthManagement>();
            enemyHealthManagement.IsHittenByBull = true;

        }
    }

    public void  BulbLevel2()
    {
        bulbLight.pointLightOuterRadius = 5;
        bulbLight.pointLightInnerRadius = 4;



    }
    public void  BulbLevel4()
    {
        bulbLight.pointLightOuterRadius = 6;
        bulbLight.pointLightInnerRadius = 5;

    }


    }
    

