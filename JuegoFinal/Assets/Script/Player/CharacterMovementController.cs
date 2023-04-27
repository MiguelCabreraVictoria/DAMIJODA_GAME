using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public float speed;

    public bool isTeleporting = false;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void MoveCharacter(Vector2 direction)
    {
        if (isTeleporting) {
            rb2D.velocity = Vector2.zero;
            return;
        }
        rb2D.velocity = speed * direction;
    }

    public void Flip()
    {
        transform.Rotate(0f, 180f, 0f);

        // Cambiar la escala en el eje X para voltear el personaje horizontalmente
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
