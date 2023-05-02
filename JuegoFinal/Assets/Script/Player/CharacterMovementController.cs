using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public PlayerStats playerStats;

    public bool isTeleporting = false;

    private Rigidbody2D rb2D;

    public SpecialAttack specialAttack;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void MoveCharacter(Vector2 direction)
    {
        if (isTeleporting || playerStats.vida <= 0 || specialAttack.isSpecialAttackActive) {
            rb2D.velocity = Vector2.zero;
            return;
        }
        rb2D.velocity = playerStats.velocidad * direction;
    }
}
