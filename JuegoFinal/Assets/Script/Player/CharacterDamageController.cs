using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamageController : MonoBehaviour
{
    public float knockbackForce = 5f;
    public float invulnerabilityTime = 1f;
    private float lastDamageTime;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2D;
    private GameObject parentObject;
    
    public PlayerStats playerStats;

    void Start()
    {
        parentObject = transform.parent.gameObject;
        spriteRenderer = parentObject.GetComponent<SpriteRenderer>();
        rb2D = parentObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemigo") && Time.time > lastDamageTime + invulnerabilityTime)
        {
            FlashRed();
            // vida menos ataque del enemigo divivido entre la resistencia del personaje

            int cuanto = (col.gameObject.GetComponent<Enemigo>().ataque / (playerStats.resistencia + 1));
            playerStats.recibirAtaque(cuanto);
            Debug.Log("Player received damage: " + cuanto);
            Debug.Log("Player life: " + playerStats.vida);

            Knockback(col.transform);
        }
    }

    private void FlashRed()
    {
        StartCoroutine(FlashRedCoroutine());
    }

    private IEnumerator FlashRedCoroutine()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    private void Knockback(Transform enemyTransform)
    {
        // Debug.Log("Knockback!");

        Vector2 knockbackDirection = (parentObject.transform.position - enemyTransform.position).normalized;
        float knockbackDistance = knockbackForce * Time.deltaTime;

        // Debug.Log(knockbackDirection);
        rb2D.MovePosition(rb2D.position + knockbackDirection * knockbackDistance);
    }
}
