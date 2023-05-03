using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * 50f;
    }

    void Update()
    {
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "walls":
                Destroy(gameObject);
                break;
            case "Enemigo":
                other.GetComponent<Valefar>().vida -= 10;
                other.GetComponent<Valefar>().StartFlashDamage();
                //other.GetComponent<Valefar>().FleeFromPlayer();
                Destroy(gameObject);
                break;
        }
    }
}
