using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    GameObject[] enemies;
    public GameObject newEnemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemigo");     
        Debug.Log("Enemigos: " + enemies.Length);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Colision");
        if (enemies.Length == 0) {
            newEnemies.SetActive(true);
            gameObject.SetActive(false);
        }
    }
        
}
