using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        // Variables públicas para configurar la velocidad del personaje, el índice de la skin y las skins disponibles.
        public float speed;
        public int skinNr;
        public Skins[] skins;

        // Referencias a los componentes del objeto.
        private SpriteRenderer spriteRenderer;
        private Animator animator;
        private Rigidbody2D rb2D;

        // Clave para almacenar la skin seleccionada en PlayerPrefs.
        private string selectedSkinKey = "SelectedSkin";

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
            Vector2 direction = GetMovementDirection();
            UpdateAnimatorParameters(direction);
            MoveCharacter(direction);
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
            Vector2 direction = Vector2.zero;
            skinNr = skinNr % skins.Length;

            // Horizontal movement.
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                direction.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                direction.x = 1;
                animator.SetInteger("Direction", 2);
            }

            // Vertical movement.
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                direction.y = 1;
                direction.x = 0;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                direction.y = -1;
                direction.x = 0;
                animator.SetInteger("Direction", 0);
            }

            return direction.normalized;
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
}
