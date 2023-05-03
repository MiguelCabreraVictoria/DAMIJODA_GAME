using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipX : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        // if player x is greater than this x, flip
        if (player.transform.position.x > transform.position.x)
        {
            // get sprite renderer of this game object and do the function flip x
            GetComponent<SpriteRenderer>().flipX = true;

        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }
        
    }
}
