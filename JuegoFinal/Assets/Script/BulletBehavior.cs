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
                other.gameObject.GetComponent<Gileus>().Damage(10f);
                Destroy(gameObject);
                break;
        }
    }
}
