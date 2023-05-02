using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyShadow : MonoBehaviour
{
    public float amp;
    public float freq;
    public float xSize;
    public float ySize;
    //Vector3 initPos;

    // Start is called before the first frame update
    private void Start()
    {
        //initPos = transform.scale;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.localScale = new Vector3(Mathf.Sin(Time.time*freq) * amp - xSize, Mathf.Sin(Time.time * freq) * amp - ySize, 0);
    }   

    // When the player collides with the key shadow, the key shadow is destroyed
    private void OnTriggerEnter2D(Collider2D collider){
        Key key = collider.GetComponent<Key>();
        if(key != null){
            Destroy(key.gameObject);
            Destroy(gameObject);
        }
    }

}
