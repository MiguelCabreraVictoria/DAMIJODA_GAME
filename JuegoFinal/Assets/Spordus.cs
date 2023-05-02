using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spordus : MonoBehaviour
{
    public float vida = 30f;
    public bool amIonTheAttackZone = false;
    public CharacterAttackController player;
    public SpriteRenderer spriteRenderer;
    public float damageFlashDuration = 0.2f; // Duración del destello en segundos
    public GameObject fireParticlesPrefab; // Prefab de partículas de fuego
    public AudioClip hitSound; // Sonido al golpear
    public AudioClip deathSound; // Sonido al morir
    private AudioSource audioSource;
    private bool isDying = false; // Agregar esta variable
    public float fleeSpeed = 10.0f;
    public float fleeDuration = 0.1f;
    public GameObject keyPrefab; // Referencia al prefab de la llave

    // Agregar variables para seguimiento
    public float chaseSpeed = 2.0f;
    public float chaseRange = 5.0f;

    public Gpt gpt;
    public TextMeshProUGUI mensaje; // Referencia al objeto TextMeshProUGUI
    public GameObject burbuja; // Referencia al objeto burbuja
    public string prompt = "Valefar es un personaje de nuestro videojuego rpg de fantasía, es un diablito rojo con fuego en las manos dime una frase de máximo 6 palabras que podría decirle a nuestro personaje cuando esta siendo atacado que suene graciosa, divertida, amenzantes o todas ellas.";
    public bool habla = true;

    public PlayerStats playerStats;

    private void SaySomething()
    {
        //StartCoroutine(openAICompletionExample.RequestCompletion(prompt));
        StartCoroutine(gpt.RequestCompletion(prompt, (responseText) => {
            //Debug.Log("Valefar dice: " + responseText);
            mensaje.text = responseText;
            burbuja.SetActive(true);
            StartCoroutine(HideBubble());
        }));
    }

    IEnumerator HideBubble()
    {
        yield return new WaitForSeconds(3.0f);
        burbuja.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        burbuja.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0 && !isDying) // Modificar esta condición
        {
            isDying = true;
            StartCoroutine(Die());
            Instantiate(keyPrefab, transform.position, Quaternion.identity); // Instanciar llave
        }
        else if (amIonTheAttackZone && player != null && player.isAttacking)
        {
            vida -= playerStats.fuerza;
            Debug.Log("AUCH! Vida restante: " + vida);
            player.isAttacking = false;
            StartCoroutine(FlashDamage());
            audioSource.PlayOneShot(hitSound); // Reproducir sonido al golpear
            if (habla) {
                SaySomething();
            }
        }
        else
        {
            FollowPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AttackZone"))
        {
            amIonTheAttackZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AttackZone"))
        {
            amIonTheAttackZone = false;
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.2f); // Esperar dormir 0.05 segundos
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(damageFlashDuration);
        spriteRenderer.color = Color.white;
        
        // Instanciar partículas de fuego y asignar su posición al personaje
        GameObject fireParticles = Instantiate(fireParticlesPrefab, transform.position, Quaternion.identity);
        // Hacer que las partículas se destruyan automáticamente después de que el sistema de partículas termine
        Destroy(fireParticles, fireParticles.GetComponent<ParticleSystem>().main.duration);
        // Reproducir sonido al morir
        AudioSource.PlayClipAtPoint(deathSound, transform.position); // Cambiar a PlayClipAtPoint
        // Desactivar el personaje
        gameObject.SetActive(false);
    }

    IEnumerator FlashDamage()
    {
        StartCoroutine(FleeFromPlayer());
        yield return new WaitForSeconds(0.2f); // Esperar dormir 0.05 segundos
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(damageFlashDuration);
        spriteRenderer.color = Color.white;
    }

    // Función para que Valefar siga al jugador
    void FollowPlayer()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
            if (distanceToPlayer <= chaseRange)
            {
                // Guardar la posición anterior
                Vector2 previousPosition = transform.position;

                // Mover a Valefar hacia el jugador
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);

                // Calcular la dirección en la que se movió Valefar
                Vector2 direction = (Vector2)transform.position - previousPosition;

                // Voltear el sprite en función de la dirección
                if (direction.x > 0) // Se mueve a la derecha
                {
                    spriteRenderer.flipX = true;
                }
                else if (direction.x < 0) // Se mueve a la izquierda
                {
                    spriteRenderer.flipX = false;
                }
            }
        }
    }
    
    IEnumerator FleeFromPlayer()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < fleeDuration)
        {
            Vector2 direction = (transform.position - player.transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, transform.position + (Vector3)direction, fleeSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

}