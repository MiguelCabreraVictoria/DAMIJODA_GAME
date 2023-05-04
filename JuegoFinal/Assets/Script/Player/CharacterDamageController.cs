using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CharacterDamageController : MonoBehaviour
{
    public float knockbackForce = 5f;
    public float invulnerabilityTime = 1f;
    private float lastDamageTime;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2D;
    private GameObject parentObject;
    
    public PlayerStats playerStats;

    public AudioClip beboAuch;
    public AudioClip davidAuch;
    public AudioClip natAuch;
    public AudioClip danAuch;
    public AudioClip miguelAuch;
    
    private AudioSource audioSource;

    public SpecialAttack specialAttack;

    void Start()
    {
        parentObject = transform.parent.gameObject;
        spriteRenderer = parentObject.GetComponent<SpriteRenderer>();
        rb2D = parentObject.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (playerStats.vida <= 0) return;

        if (playerStats.isInvisible) return;

        if (specialAttack.isSpecialAttackActive) return;

        if (col.gameObject.CompareTag("Enemigo") && Time.time > lastDamageTime + invulnerabilityTime)
        {
            FlashRed();
            // vida menos ataque del enemigo divivido entre la resistencia del personaje

            int cuanto = (col.gameObject.GetComponent<Enemigo>().ataque / (playerStats.resistencia + 1));
            playerStats.recibirAtaque(cuanto);
            Debug.Log("Player received damage: " + cuanto);
            Debug.Log("Player life: " + playerStats.vida);

            repoducirSonido();

            Knockback(col.transform);
        }
    }

    private void repoducirSonido() {
        // nombres[0] = "Bebo";
        // nombres[1] = "Daniel";
        // nombres[2] = "David";
        // nombres[3] = "Joaquin";
        // nombres[4] = "Miguel";
        // nombres[5] = "Nat";
        int n = PlayerPrefs.GetInt("SelectedSkin");
        if (n == 0)
        {
            // reproduce auch de bebo
            audioSource.PlayOneShot(beboAuch);
        }
        else if (n == 2)
        {
            // reproduce auch de david
            audioSource.PlayOneShot(davidAuch);
        }
        else if (n == 5)
        {
            // reproduce auch de nat
            audioSource.PlayOneShot(natAuch);
        }
        else if (n == 1)
        {
            // reproduce auch de dan
            audioSource.PlayOneShot(danAuch);
        }
        else if (n == 4)
        {
            // reproduce auch de miguel
            audioSource.PlayOneShot(miguelAuch);
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
