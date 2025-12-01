using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class experiencepoint : MonoBehaviour
{
    [SerializeField] AudioSource experiencepointSound;
    public Slider BarreXp;
    public int ExpReward = 3;

    public delegate void EnnemiDefeated(int exp);
    public static event EnnemiDefeated OnEnnemiDefeated;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            experiencepointSound.Play();
            OnEnnemiDefeated(ExpReward);
            Destroy(gameObject);
        }



    }

    
}
