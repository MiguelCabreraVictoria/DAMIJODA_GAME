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
    private GameObject parentObject;

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
            vidas -= 1;
            Knockback(col.transform);
            //Debug.Log("¡Auch! El diablito me pegó.");
            
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

    private void Knockback(Transform enemyTransform)
    {
        Debug.Log("Knockback!");

        Vector2 knockbackDirection = (parentObject.transform.position - enemyTransform.position).normalized;
        float knockbackDistance = knockbackForce * Time.deltaTime;

        Debug.Log(knockbackDirection);
        rb2D.MovePosition(rb2D.position + knockbackDirection * knockbackDistance);
    }
}
