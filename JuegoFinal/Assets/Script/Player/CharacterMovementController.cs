using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void MoveCharacter(Vector2 direction)
    {
        rb2D.velocity = speed * direction;
    }
}
