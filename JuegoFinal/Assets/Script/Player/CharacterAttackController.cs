using UnityEngine;
using System.Collections;

public class CharacterAttackController : MonoBehaviour
{
    private CharacterAnimationController animationController;
    public bool isAttacking;

    private void Start()
    {
        animationController = GetComponent<CharacterAnimationController>();
    }

    public IEnumerator HandleAttack()
    {
        isAttacking = true;
        animationController.SetIsAttacking(true);
        Debug.Log("I am attacking!");
        yield return new WaitForSeconds(0.3f);
        animationController.SetIsAttacking(false);
        isAttacking = false;
    }
}
