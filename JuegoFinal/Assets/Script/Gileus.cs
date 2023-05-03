using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gileus : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 5f;

    private float currentHealth;

    private void start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }   
}
