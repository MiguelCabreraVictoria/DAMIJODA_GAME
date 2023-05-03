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
        newEnemies.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemigo");     
        Debug.Log("Enemigos: " + enemies.Length);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (enemies.Length == 0) {
            gameObject.SetActive(false);
            newEnemies.SetActive(true);
        }
    }
        
}
