using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamageController : MonoBehaviour
{
    public int vidas = 3;
    public float knockbackForce = 5f;
    public float invulnerabilityTime = 1f;
    private float lastDamageTime;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2D;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemigo") && Time.time > lastDamageTime + invulnerabilityTime)
        {
            FlashRed();
            vidas -= 1;
            Knockback(col);
            Debug.Log("¡Auch! El diablito me pegó.");
            
            if (vidas <= 0)
            {
                Debug.Log("¡El personaje ha muerto!");
                // Aquí puedes agregar código para manejar la muerte del personaje, como mostrar una pantalla de Game Over
            }
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

    private void Knockback(Collision2D col)
    {
        Debug.Log("Knockback!");
        Debug.Log(col.gameObject.tag);

        Vector2 knockbackDirection = (transform.position - col.transform.position).normalized;
        float knockbackDistance = knockbackForce * Time.deltaTime;

        Debug.Log(knockbackDirection);
        rb2D.MovePosition(rb2D.position + knockbackDirection * knockbackDistance);
    }
}
