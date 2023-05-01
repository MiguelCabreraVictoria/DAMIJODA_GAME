using UnityEngine;
using System.Collections;

public class CharacterAttackController : MonoBehaviour
{
    private CharacterAnimationController animationController;
    public bool isAttacking;
    public bool isOnTalkZone = false;

    

    private void Start()
    {
        animationController = GetComponent<CharacterAnimationController>();
    }

    public IEnumerator HandleAttack()
    {
        if (isOnTalkZone) yield break;
        isAttacking = true;
        animationController.SetIsAttacking(true);
        //Debug.Log("I am attacking!");
        yield return new WaitForSeconds(0.3f);
        animationController.SetIsAttacking(false);
        isAttacking = false;
    }

    
}
