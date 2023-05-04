using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Arreglo de items (arreglo de sprites)
    public Skins[] itemSkins;

    // Variable pública para almacenar la referencia al objeto personaje
    public TopDownCharacterController characterObject;

    // Variable pública para almacenar la referencia al objeto personaje
    public CharacterSkinController characterAnimation;

    public CharacterMovementController characterMovement;
    
    // Referencia al componente SpriteRenderer
    private SpriteRenderer spriteRenderer;

    // Color original del sprite
    private Color originalColor;

    public PlayerStats playerStats;

    public SpecialAttack specialAttack;

    public int skinIndex = 0;


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

        if (playerStats == null)
        {
            playerStats = FindObjectOfType<PlayerStats>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (characterObject.hasShield) {
            if (skinIndex == 0) {
                playerStats.resistencia = 1;
            } else if (skinIndex == 1) {
                playerStats.resistencia = 2;
            } else if (skinIndex == 2) {
                playerStats.resistencia = 3;
            }
        }
        if (playerStats.vida <= 0)
        {
            Destroy(gameObject);
        }

        // que el alfa del sprite rendered del player sea igual al alfa del sprite renderer del item
        // spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, characterAnimation.spriteRenderer.color.a);

        // Si hay un objeto personaje y el personaje tiene escudo, obtén el índice del item y actualiza el sprite mostrado
        if (characterObject != null && characterObject.hasShield)
        {
            int itemIndex = characterAnimation.itemIndex;
        
            if (specialAttack.isSpecialAttackActive) {
                itemIndex = 79;
            }

            if (characterMovement.isTeleporting) {
                itemIndex = 79;
            }

            // Obtiene el sprite del item usando la función GetItemSprite
            Sprite itemSprite = GetItemSprite(skinIndex, itemIndex);

            if (itemSprite != null)
            {
                // Muestra el sprite del item y establece su color a su color original
                spriteRenderer.sprite = itemSprite;
                spriteRenderer.color = originalColor;
            }
            else
            {
                Debug.LogError("Item: Error al obtener el sprite del item. Verifique los índices del skin y del item.");
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

    private Sprite GetItemSprite(int skinIndex, int itemIndex)
    {
        if (skinIndex >= 0 && skinIndex < itemSkins.Length)
        {
            Skins skin = itemSkins[skinIndex];
            if (itemIndex >= 0 && itemIndex < skin.sprites.Length)
            {
                return skin.sprites[itemIndex];
            }
            else
            {
                Debug.LogError("Item: Índice del item fuera de rango. Asegúrate de que el índice del item esté dentro del rango válido.");
                return null;
            }
        }
        else
        {
            Debug.LogError("Item: Índice del skin fuera de rango. Asegúrate de que el índice del skin esté dentro del rango válido.");
            return null;
        }
    }
}
