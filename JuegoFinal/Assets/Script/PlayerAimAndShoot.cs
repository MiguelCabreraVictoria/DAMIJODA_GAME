using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimAndShoot : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;

    private GameObject bulletInst;

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;

    private void Update()
    {
        HandleGunRotation();
        HandleGunShooting();
    }

    private void HandleGunRotation()
    {
        //rotate the gun towards the mouse position
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;
        gun.transform.right = direction;

        //flip the gun when it reaches a 90 degree theshold
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Vector3 localScale = new Vector3(0.25f, 0.25f, 0.25f);
        if(angle >90 || angle < -90)
        {
            localScale.y = -0.25f;
        }
        else
        {
            localScale.y = 0.25f;
        }

        gun.transform.localScale = localScale;
    }


    private void HandleGunShooting()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            //Spawn bullet
            bulletInst = Instantiate(bullet, bulletSpawnPoint.position, gun.transform.rotation);
        }
    }
}
