using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Healthbar _healthbar;
    [SerializeField] int _startingHealth = 50;
    [SerializeField] int _maxHealth = 50;
    private int _currentHealth;

    void Start()
    {
        _currentHealth = _startingHealth;
        _healthbar.SetMaxHealth(_maxHealth);
        _healthbar.SetHealth(_currentHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        _healthbar.SetHealth(_currentHealth);
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Code to handle enemy death goes here
        Debug.Log("Enemy has died");
        gameObject.SetActive(false);
    }

    // You can add more enemy behaviors in this script
}

