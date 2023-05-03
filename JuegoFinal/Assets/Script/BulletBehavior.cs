using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    private Valefar valefar;

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
                break;
            case "Enemigo":
                other.gameObject.GetComponent<Gileus>().Damage(1f);
                // valefar.vida -=1;
                // Destroy(gameObject);
                break;
        }
    }
}
