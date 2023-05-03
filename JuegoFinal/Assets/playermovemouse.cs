using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovemouse : MonoBehaviour
{
    public Camera sceneCamera;
    public float moveSpeed;
    public Weapon weapon;
    private Vector2 moveDirection;
    private Vector2 mousePosition;

    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            //weapon.Fire();
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move()
    {
        // Rotate weapon to aim at mouse position
        Vector2 aimDirection = mousePosition - (Vector2)weapon.transform.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        weapon.transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.forward);
    }
}


