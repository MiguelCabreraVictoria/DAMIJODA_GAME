using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private float moveSpeed;
    private bool moveRight;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
        moveRight = true;        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >3f) {
            moveRight = false;
        } else if (transform.position.x < -3f) {
            moveRight = true;
        }

        if(moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        } else {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }
}
