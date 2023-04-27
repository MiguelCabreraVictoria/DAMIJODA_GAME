using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public string gemType;
    public GameObject infoGemaAmarilla;
    public Sprite gemAmarilla;


    public

    void Start() {
        infoGemaAmarilla.SetActive(false);
        if (gemType == "yellow") {
            GetComponent<SpriteRenderer>().sprite = gemAmarilla;
        }
    }
    
    void OnTriggerEnter2D (Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            if (gemType == "yellow") {
                // aumentar la vida del jugador
                collider.gameObject.GetComponent<PlayerStats>().startSpeedEffect(10);

                // mostrar texto de que aumentó la vida
                infoGemaAmarilla.SetActive(true);
            }	

            Destroy(gameObject);
        }
    }
}
