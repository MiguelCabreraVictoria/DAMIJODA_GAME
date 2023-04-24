using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]Healthbar _healthbar;
    [SerializeField] int _startingHealth = 100;
    [SerializeField] int _maxHealth = 100;
    private int _currentHealth;

    
    void Start()
    {
        _currentHealth = _startingHealth;
        _healthbar.SetMaxHealth(_maxHealth);
        _healthbar.SetHealth(_currentHealth);
    }

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         PlayerTakeDmg(20);
    //         Debug.Log(GameManager.gameManager._playerHealth.Health);
    //     }
    //     if (Input.GetKeyDown(KeyCode.Z))
    //     {
    //         PlayerHeal(10);
    //         Debug.Log(GameManager.gameManager._playerHealth.Health);
    //     }
    // }

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
             // Code to handle player death goes here
            Debug.Log("Player has died");
            gameObject.SetActive(false);
    }

//     private void PlayerTakeDmg(int dmg)
//     {
//         GameManager.gameManager._playerHealth.DmgUnit(dmg);
//         _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);
//     }

//     private void PlayerHeal(int healing)
//     {
//         GameManager.gameManager._playerHealth.HealUnit(healing);
//         _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);
//     }
}
