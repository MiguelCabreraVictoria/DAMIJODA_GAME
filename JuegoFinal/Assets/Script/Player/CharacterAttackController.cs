using UnityEngine;
using System.Collections;

public class CharacterAttackController : MonoBehaviour
{
    private CharacterAnimationController animationController;
    public bool isAttacking;
    public bool isOnTalkZone = false;
    public PlayerStats playerStats;

    private void Start()
    {
        animationController = GetComponent<CharacterAnimationController>();
    }

    public IEnumerator HandleAttack()
    {
        if (isOnTalkZone) yield break;
        if (playerStats.vida <= 0) yield break;
        if (isAttacking) yield break;

        isAttacking = true;
        animationController.SetIsAttacking(true);
        //Debug.Log("I am attacking!");
        yield return new WaitForSeconds(0.3f);
        animationController.SetIsAttacking(false);
        isAttacking = false;
    }
}
