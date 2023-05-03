using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool onInteractionZone = false;
    public bool isOpen = false;
    
    public GameObject pressXtext;
    public Sprite openChestSprite;

    public Misiones misiones;

    public int tipoDeEscudo = 0;
    public Item escudo;

    void Start() {
        pressXtext.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.X) && onInteractionZone && !isOpen) {
            pressXtext.SetActive(false);
            // cambiar el sprite del cofre
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = openChestSprite;
            // reproducir sonido
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            // desactivar el texto
            pressXtext.SetActive(false);

            // cambiar el texto de la mision
            misiones.misionNr = 2;

            // get component TopDownCharacterController del player
            GameObject player = GameObject.Find("Player");
            TopDownCharacterController playerController = player.GetComponent<TopDownCharacterController>();
            // cambiar la variable has shield de player a true
            playerController.hasShield = true;
            // get component playerstats del player
            //PlayerStats playerStats = player.GetComponent<PlayerStats>();
            // aumentar la resistencia del player
            //playerStats.resistencia = 1;
            isOpen = true;
            escudo.skinIndex = tipoDeEscudo;
            
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "AttackZone" && !isOpen)
        {
            onInteractionZone = true;
            pressXtext.SetActive(true);    
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "AttackZone")
        {
            onInteractionZone = false;
            pressXtext.SetActive(false);
        }
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Chest : MonoBehaviour
// {
//     public CharacterAttackController playerAttack;
//     public TopDownCharacterController player;
    
//     public Sprite openChestSprite;
//     public AudioClip openChestSound;
//     private bool isColliding = false;
//     private bool isOpened = false; // Variable para verificar si el cofre ya está abierto
//     private SpriteRenderer spriteRenderer;
//     private AudioSource audioSource;

//     void Start()
//     {
//         spriteRenderer = GetComponent<SpriteRenderer>();
//         audioSource = GetComponent<AudioSource>();
//     }

//     void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.gameObject.CompareTag("AttackZone"))
//         {
//             if (player != null)
//             {
//                 isColliding = true;
//             }
//         }
//     }
    
//     void OnTriggerExit2D(Collider2D collision)
//     {
//         if (collision.gameObject.CompareTag("AttackZone"))
//         {
//             if (player != null)
//             {
//                 isColliding = false;
//             }
//         }
//     }
    
//     void Update()
//     {
//         // Obtener la posición Y del cofre y del personaje
//         float chestY = transform.position.y;
//         float playerY = player.transform.position.y-1.1f;
//         // Comparar la posición Y del personaje con la del cofre
//         if (playerY > chestY)
//         {
//             // Si el personaje está arriba del cofre, establecer el orden en la capa en 5
//             spriteRenderer.sortingOrder = 5;
//         }
//         else
//         {
//             // Si el personaje está abajo del cofre, establecer el orden en la capa en 2
//             spriteRenderer.sortingOrder = 2;
//         }
//         if (!isOpened && isColliding && player != null && playerAttack.isAttacking)
//         {
//             // Cambiar el sprite del cofre
//             spriteRenderer.sprite = openChestSprite;
//             // Reproducir el sonido del cofre
//             audioSource.PlayOneShot(openChestSound);
//             // Establecer la variable hasShield del personaje en true
//             player.hasShield = true;
//             isOpened = true; // Marcar el cofre como abierto
//         }
//     }
// }
