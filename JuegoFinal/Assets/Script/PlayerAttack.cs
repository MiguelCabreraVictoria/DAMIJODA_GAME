using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _damageAmount = 10f;

    private EnemyHealth _enemyHealth;
    private HealthBar _healthBar;

    private void Start()
    {
        _enemyHealth = FindObjectOfType<EnemyHealth>();
        _healthBar = _enemyHealth.GetComponentInChildren<HealthBar>();
    }

    private void OncollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Enemigo"))
        {
            _enemyHealth.Damage(_damageAmount);
            _healthBar.UpdateHealthBar(_enemyHealth.GetMaxHealth(), _enemyHealth.GetCurrentHealth(), _damageAmount);
        }
    }
}