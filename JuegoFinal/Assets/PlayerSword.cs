using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSword : MonoBehaviour
{
    private Vector2 pointerInput;
    public Vector2 PointerInput => pointerInput;

    private WeaponParent weaponParent;

    [SerializeField] 
    private InputActionReference attack, pointerPosition;

    private void Awake()
    {
        weaponParent = GetComponentInChildren<WeaponParent>();
    }

    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
    }

    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {
        weaponParent.Attack();
    }

    // Update is called once per frame
    private void Update()
    {
        pointerInput = GetPointerInput();

        if (attack.action.inProgress)
        {
            Debug.Log("Attack!");
        }
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        return mousePos;
    }
}
