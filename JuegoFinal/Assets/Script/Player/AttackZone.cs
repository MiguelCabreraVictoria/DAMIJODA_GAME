using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public CharacterAttackController playerAttack;
    public TopDownCharacterController player;
    
    public Color normalColor; // color normal del sprite
    public Color attackingColor; // color cuando el jugador está atacando

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // obtener el componente SpriteRenderer del objeto
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 offset = Vector3.zero;

        // verificar la dirección del personaje y actualizar la posición del offset en consecuencia
        switch (player.attackDirection)
        {
            case 0: // abajo
                offset = new Vector3(0, -0.3f, 0);
                break;
            case 1: // arriba
                offset = new Vector3(0, 1.5f, 0);
                break;
            case 2: // derecha
                offset = new Vector3(0.5f, 1.0f, 0);
                break;
            case 3: // izquierda
                offset = new Vector3(-0.5f, 1.0f, 0);
                break;
            default:
                break;
        }

        // actualizar la posición del objeto AttackZone
        transform.position = transform.parent.position + offset;

        // actualizar el color del sprite dependiendo de si el jugador está atacando o no
        if (playerAttack.isAttacking)
        {
            spriteRenderer.color = attackingColor;
        }
        else
        {
            spriteRenderer.color = normalColor;
        }
    }
}
