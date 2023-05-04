using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gileus : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 50f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= 5f;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
        }
    }
}

