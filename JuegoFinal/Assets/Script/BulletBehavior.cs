using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
{
    int ignoreLayer = LayerMask.NameToLayer("Layer 1");

    GameObject[] ignoreList = GameObject.FindGameObjectsWithTag("IgnoreBullets");
    foreach (GameObject obj in ignoreList)
    {
        Collider2D otherCollider = obj.GetComponent<Collider2D>();
        if (otherCollider != null)
        {
            // Ignorar la colisión con el Tilemap
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), otherCollider);
        }
    }

    // Ignorar la colisión con la capa del Tilemap
    Physics2D.IgnoreLayerCollision(gameObject.layer, ignoreLayer);
}



    void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "walls":
                Destroy(gameObject);
                break;
            case "Enemigo":
                other.gameObject.GetComponent<Gileus>().Damage(1);
                break;
        }
    }
}
