using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    private bool hasDied = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetIsMoving(bool isMoving)
    {
        animator.SetBool("IsMoving", isMoving);
    }

    public bool GetIsMoving()
    {
        return animator.GetBool("IsMoving");
    }

    public void SetAttackDirection(int direction)
    {
        animator.SetInteger("Direction", direction);
    }

    public void UpdateAnimatorParameters(Vector2 direction)
    {
        animator.SetBool("IsMoving", direction.magnitude > 0);
    }

    public bool GetIsAttacking()
    {
        return animator.GetBool("IsAttacking");
    }

    public void SetIsAttacking(bool isAttacking)
    {
        animator.SetBool("IsAttacking", isAttacking);
    }

    public void teleportAnimation() {
        animator.Play("Teleport");
    }

    public void die() {
        if (hasDied) return;
        animator.Play("Die");
        hasDied = true;
    }   
}
