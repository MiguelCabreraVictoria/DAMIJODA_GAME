using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;
        public int skinNr; // Numero de la skin actualmente seleccionada
        public Skins[] skins; // Arreglo de Skins disponibles

        SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer del personaje
        private Animator animator;

        private string selectedSkinKey = "SelectedSkin"; // Define una clave única para la selección de la skin

        private void Start()
        {
             if (PlayerPrefs.HasKey(selectedSkinKey))
                {
                // Si existe la clave de la selección de la skin, carga la selección guardada
                skinNr = PlayerPrefs.GetInt(selectedSkinKey);
            }
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();  // Obtener el SpriteRenderer del personaje
        }

        private void Update()
        {
            skinNr = skinNr % skins.Length; // Restricción para que el número de skin no exceda el número total de skins disponibles

            Vector2 dir = Vector2.zero;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                dir.y = 1;
                dir.x = 0; // Direccion exclusiva

                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                dir.y = -1;
                dir.x = 0; // Direccion exclusiva

                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }

        private void LateUpdate()
        {
            SkinChoice(); // Cambiar la skin del personaje en el frame actual
        }

        private void SkinChoice()
        {
            if (spriteRenderer.sprite.name.Contains("Bebo")) { // Si la skin actual es una de las skins de Bebo
                string spriteName = spriteRenderer.sprite.name; // Obtener el nombre de la skin actual
                spriteName = spriteName.Replace("Bebo_",""); // Eliminar la parte del nombre que indica que es una skin de Bebo
                int spriteNr = int.Parse(spriteName); // Obtener el número de la skin actual

                spriteRenderer.sprite = skins[skinNr].sprites[spriteNr];  // Cambia el sprite actual del personaje por el correspondiente a la skin seleccionada y al número de sprite actual
            }
        }
    }

    // Estructura que almacena los sprites de cada skin
    [System.Serializable]
    public struct Skins{
        public Sprite[] sprites; // Arreglo de sprites correspondiente a cada skin
    }
}
