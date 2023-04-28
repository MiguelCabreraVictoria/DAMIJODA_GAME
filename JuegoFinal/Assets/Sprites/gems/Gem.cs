using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gem : MonoBehaviour
{
    public string gemType;
    public GameObject infoGema;
    public GameObject icon;
    public TextMeshProUGUI text;

    void Start() {
        infoGema.SetActive(false);
    }
    
    void OnTriggerEnter2D (Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            
            if (gemType == "yellow") {
                // aumentar la vida del jugador
                collider.gameObject.GetComponent<PlayerStats>().startFlashPlayer(new Color32(255, 255, 0, 255), 10.0f);
                collider.gameObject.GetComponent<PlayerStats>().startFlashUI(new Color32(255, 255, 0, 255),10.0f, text, icon);
                collider.gameObject.GetComponent<PlayerStats>().startSpeedEffect(8,10);
            }

            if (gemType == "blue") {
                // aumentar la resistencia del jugador
                // flashPlayer color blue for 2 seconds
                collider.gameObject.GetComponent<PlayerStats>().startFlashPlayer(new Color32(0, 0, 255, 255), 2.0f);
                collider.gameObject.GetComponent<PlayerStats>().startFlashUI(new Color32(0, 0, 255, 255),2.0f, text, icon);
                collider.gameObject.GetComponent<PlayerStats>().subirMana(60);
            }

            if (gemType == "red") {
                // start flash player color pink for 2 seconds
                //collider.gameObject.GetComponent<PlayerStats>().startFlashPlayer(new Color32(255, 0, 255, 255), 2.0f);
                collider.gameObject.GetComponent<PlayerStats>().subirVida(100);
                collider.gameObject.GetComponent<PlayerStats>().startFlashHearts();
            }

            if (gemType == "orange") {
                // aumentar la fuerza del jugador
                // flashear player color orange for 2 seconds
                collider.gameObject.GetComponent<PlayerStats>().startFlashPlayer(new Color32(255, 165, 0, 255), 10.0f);
                // flashear ui color orange for 2 seconds
                collider.gameObject.GetComponent<PlayerStats>().startFlashUI(new Color32(255, 165, 0, 255),10.0f, text, icon);
                collider.gameObject.GetComponent<PlayerStats>().startStrengthEffect(100,10);
            }

            // reproducir un sonido
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            infoGema.SetActive(true);
            // instead of destroying the gem, we disable it
            //Destroy(gameObject);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;

        }
    }
}
