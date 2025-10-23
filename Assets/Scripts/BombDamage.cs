using System;
using Player_Scripts;
using UnityEngine;

public class BombDamage : MonoBehaviour
{
    [SerializeField] private int bombDamage;
    [SerializeField] private PlayerHealth _playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
        }
    }

    void Damage()
    {
        _playerHealth.playerHealth = _playerHealth.playerHealth - bombDamage;
        _playerHealth.UpdateHealth();
        gameObject.SetActive(false);
    }
}
