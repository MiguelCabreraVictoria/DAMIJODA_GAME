using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] int _damageAmount = 20;

    private void OnCollisionEnter2D(Collision2D other)
    {
        print("Enemy hit " + other.gameObject.name + "!");
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerBehaviour>().TakeDamage(_damageAmount);
        }
    }
}

