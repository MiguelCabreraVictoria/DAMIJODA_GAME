using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 50f;

    private float _currentHealth;

    private HealthBar _healthBar;


    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar = GetComponentInChildren<HealthBar>();
    }

    public void Damage(float damageAmount)
    {
        //Damage the enemy
        _currentHealth -= damageAmount;

        //Update the health bar
        _healthBar.UpdateHealthBar(_maxHealth, _currentHealth, damageAmount);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public float GetMaxHealth()
    {
    return _maxHealth;
    }
    
    public float GetCurrentHealth()
    {
    return _currentHealth;
    }
}
