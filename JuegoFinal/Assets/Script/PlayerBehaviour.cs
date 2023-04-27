using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] int _damageAmount = 20;

    private void OnCollisionEnter2D(Collision2D other)
    {
        print("Enemy hit " + other.gameObject.name + "!");
        if (other.gameObject.CompareTag("Enemigo"))
        {
            other.gameObject.GetComponent<EnemyBehaviour>().TakeDamage(_damageAmount);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        // Code to handle player taking damage goes here
    }

    // You can add more player behaviors in this script
}


