using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThrough : MonoBehaviour
{
    private SpriteMask spriteMask;
    public float alphaValue = 0.5f; // set the desired alpha value here
    //For seethrough
    private bool colliding;

    //For growing the seeThrough
    public float timer = 0.0f;
    public float growTime = 6f;
    public float maxSize = 2f;
    public bool isGrowing = false;


    private void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        // Get a reference to the Sprite Mask component on the object
    }

    private void Update() {
        if (colliding == true)
            {
                GetComponent<Renderer>().enabled = true;
                //GetComponent<SpriteRenderer>().enabled = true;

                //seeThrough.transform.localScale = Vector2.Lerp(new Vector2(maxSize, maxSize), Vector2.zero, timer / growTime);
                
                //StartCoroutine(Grow());
            }
            else
            {
                GetComponent<Renderer>().enabled = false;
                //GetComponent<SpriteRenderer>().enabled = false;
                //seeThrough.transform.localScale = Vector2.Lerp(Vector2.zero, new Vector2(maxSize, maxSize), timer / growTime);
            }    
    }

    // Funcion para activar/desactivar la mascara para ver through walls
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.CompareTag("TileMapSeeThrough"))
            {
                colliding = true;
                //alphaLevel += 0.5f;
                GetComponent<Renderer>().enabled = true;
                
                }
        }
        
        private void OnTriggerExit2D(Collider2D collision) {
            if (collision.gameObject.CompareTag("TileMapSeeThrough"))
            {
            colliding = false;
            //alphaLevel -= 0.5f;
            GetComponent<Renderer>().enabled = false;
            }
        }
        
        // Subroutine para hacer crecer el objeto seethrough, con Vector 2 startScale y Vector2 MaxScale
        IEnumerator Grow()
        {
            if (isGrowing == false)
            {
                isGrowing = true;
                while (timer < growTime)
                {
                    timer += Time.deltaTime;
                    gameObject.transform.localScale = Vector2.Lerp(Vector2.zero, new Vector2(maxSize, maxSize), timer / growTime);
                    yield return null;
                }
                timer = 0.0f;
                isGrowing = false;
            }
        }
}


