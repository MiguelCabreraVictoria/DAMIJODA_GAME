using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public TopDownCharacterController player;
    public Sprite openChestSprite;
    public AudioClip openChestSound;
    private bool isColliding = false;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player != null)
            {
                isColliding = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player != null)
            {
                isColliding = false;
            }
        }
    }
    void Update()
    {
        // Obtener la posición Y del cofre y del personaje
        float chestY = transform.position.y;
        float playerY = player.transform.position.y-1.1f;
        // Comparar la posición Y del personaje con la del cofre
        if (playerY > chestY)
        {
            // Si el personaje está arriba del cofre, establecer el orden en la capa en 5
            spriteRenderer.sortingOrder = 5;
        }
        else
        {
            // Si el personaje está abajo del cofre, establecer el orden en la capa en 2
            spriteRenderer.sortingOrder = 2;
        }
        if (isColliding && player != null && player.isAttacking)
        {
            // Cambiar el sprite del cofre
            spriteRenderer.sprite = openChestSprite;
            // Reproducir el sonido del cofre
            audioSource.PlayOneShot(openChestSound);
            // Establecer la variable hasShield del personaje en true
            player.hasShield = true;
        }
    }
}
