using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    // Variables públicas para configurar la velocidad del personaje, el índice de la skin y las skins disponibles.
    public float speed;
    public int skinNr;
    public Skins[] skins;
    public bool isAttacking;
    public int attackDirection;
    
    // Variable pública para almacenar el índice del item
    public int itemIndex = 0;
    public bool hasShield = false;
    // Referencias a los componentes del objeto.
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb2D;
    // Clave para almacenar la skin seleccionada en PlayerPrefs.
    private string selectedSkinKey = "SelectedSkin";
    // Dirección actual de movimiento.
    private Vector2 currentDirection = Vector2.zero;
    private void Start()
    {
        // Cargar la skin seleccionada previamente y obtener referencias a los componentes necesarios.
        LoadSelectedSkin();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        // Obtener la dirección de movimiento y actualizar el Animator y la posición del personaje.
        CheckDirectionKeysReleased();
        Vector2 direction = GetMovementDirection();
        UpdateAnimatorParameters(direction);
        MoveCharacter(direction);
        if (!animator.GetBool("IsAttacking")) // Si no está atacando
        {
            if (Input.GetKeyDown(KeyCode.X)) // Detectar si la tecla X ha sido presionada o liberada.
            {
                StartCoroutine(HandleAttack());
            }
        }
    }
    IEnumerator HandleAttack()
    {
        animator.SetBool("IsAttacking", true);
        isAttacking = true;
        Debug.Log("I am attacking!");
        yield return new WaitForSeconds(0.3f); // Esperar dormir 0.05 segundos
        animator.SetBool("IsAttacking", false);
        isAttacking = false;
    }
    private void LateUpdate()
    {
        // Actualizar la skin del personaje.
        UpdateSkin();
    }
    // Función para cargar la skin seleccionada desde PlayerPrefs.
    private void LoadSelectedSkin()
    {
        if (PlayerPrefs.HasKey(selectedSkinKey))
        {
            skinNr = PlayerPrefs.GetInt(selectedSkinKey);
        }
    }
    // Función para obtener la dirección de movimiento basada en las teclas presionadas.
    private Vector2 GetMovementDirection()
    {
        Vector2 direction = currentDirection;
        if (animator.GetBool("IsAttacking")) {
            direction.x = 0;
            direction.y = 0;
            return direction.normalized;
        }
        // Verificar si alguna tecla está presionada
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (!animator.GetBool("IsMoving"))
            {
                animator.SetBool("IsMoving", true);
                // Si S o flecha abajo presionada
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    animator.SetInteger("Direction", 0);
                    direction.y = -1;
                    direction.x = 0;
                    attackDirection = 0;

                }
                // Si D o flecha derecha presionada
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    animator.SetInteger("Direction", 2);
                    direction.x = 1;
                    direction.y = 0;
                    attackDirection = 2;
                }
                // Si A o flecha izquierda presionada
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    animator.SetInteger("Direction", 3);
                    direction.x = -1;
                    direction.y = 0;
                    attackDirection = 3;
                }
                // Si W o flecha arriba presionada
                else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    animator.SetInteger("Direction", 1);
                    direction.y = 1;
                    direction.x = 0;
                    attackDirection = 1;
                }
                currentDirection = direction;
            }
        }
        else
        {
            animator.SetBool("IsMoving", false);
            currentDirection = Vector2.zero;
        }
        return direction.normalized;
    }
    private void CheckDirectionKeysReleased()
    {
        // Verificar si se han soltado las teclas de dirección y actualizar la dirección y las animaciones en consecuencia
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (currentDirection.y == 1)
            {
                currentDirection = Vector2.zero;
                animator.SetBool("IsMoving", false);
            }
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (currentDirection.x == -1)
            {
                currentDirection = Vector2.zero;
                animator.SetBool("IsMoving", false);
            }
        }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (currentDirection.y == -1)
            {
                currentDirection = Vector2.zero;
                animator.SetBool("IsMoving", false);
            }
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (currentDirection.x == 1)
            {
                currentDirection = Vector2.zero;
                animator.SetBool("IsMoving", false);
            }
        }
    }
    // Función para actualizar los parámetros del Animator según la dirección de movimiento.
    private void UpdateAnimatorParameters(Vector2 direction)
    {
        animator.SetBool("IsMoving", direction.magnitude > 0);
    }
    // Función para mover el personaje utilizando Rigidbody2D.
    private void MoveCharacter(Vector2 direction)
    {
        rb2D.velocity = speed * direction;
    }
    // Función para actualizar la skin del personaje.
    private void UpdateSkin()
    {
        if (spriteRenderer.sprite.name.Contains("Bebo"))
        {
            string spriteName = spriteRenderer.sprite.name;
            spriteName = spriteName.Replace("Bebo_", "");
            int spriteNr = int.Parse(spriteName);
            itemIndex = spriteNr; // Actualizar el índice del item actual
            spriteRenderer.sprite = skins[skinNr].sprites[spriteNr];
        }
    }
}

// Estructura que almacena los sprites de cada skin.
[System.Serializable]
public struct Skins
{
    public Sprite[] sprites;
}