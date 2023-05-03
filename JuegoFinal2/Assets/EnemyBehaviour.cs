using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Hitpoints = 50f;
    public float MaxHitpoints = 50f;
    public HealthbarBehaviour Healthbar;

    private void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);

        if (Hitpoints <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeHit(10f);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
