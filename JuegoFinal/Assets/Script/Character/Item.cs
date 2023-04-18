using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Arreglo de items (arreglo de sprites)
    public Sprite[] itemSprites;

    // Variable pública para almacenar la referencia al objeto personaje
    public TopDownCharacterController characterObject;

    // Referencia al componente SpriteRenderer
    private SpriteRenderer spriteRenderer;

    // Color original del sprite
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializa la referencia al componente SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Si el objeto personaje no está asignado en el inspector, intenta encontrarlo automáticamente
        if (characterObject == null)
        {
            characterObject = FindObjectOfType<TopDownCharacterController>();
        }

        // Verifica si se encontró un objeto personaje y, en caso contrario, muestra un mensaje de error
        if (characterObject == null)
        {
            Debug.LogError("Item: No se encontró un objeto personaje. Asegúrate de asignar un objeto personaje en el inspector.");
        }

        // Almacena el color original del sprite
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        // Si hay un objeto personaje y el personaje tiene escudo, obtén el índice del item y actualiza el sprite mostrado
        if (characterObject != null && characterObject.hasShield)
        {
            int itemIndex = characterObject.itemIndex;

            // Verifica si el índice del item está dentro del rango válido
            if (itemIndex >= 0 && itemIndex < itemSprites.Length)
            {
                // Muestra el sprite del item y establece su color a su color original
                spriteRenderer.sprite = itemSprites[itemIndex];
                spriteRenderer.color = originalColor;
            }
            else
            {
                Debug.LogError("Item: Índice del item fuera de rango. Asegúrate de que el índice del item esté dentro del rango válido.");
            }
        }
        else
        {
            // Si el personaje no tiene escudo, oculta el sprite del item estableciendo su transparencia a cero
            Color transparentColor = originalColor;
            transparentColor.a = 0f;
            spriteRenderer.color = transparentColor;
        }
    }
}
