using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int velocidad = 3;
    public int resistencia = 0;
    public int vida = 100;
    public int fuerza = 5;
    public int mana = 0;

    public TextMeshProUGUI velocidadText;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI fuerzaText;

    public TextMeshProUGUI velocidadTextSombra;
    public TextMeshProUGUI manaTextSombra;
    public TextMeshProUGUI fuerzaTextSombra;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    
    public GameObject shield1;
    public GameObject shield2;
    public GameObject shield3;

    public Sprite heartEmpty;
    public Sprite shieldEmpty;

    public Sprite heartFull;
    public Sprite shieldFull;

    public GameObject manaImage;
    public GameObject speedImage;
    
    public Sprite manaImageBlue;
    public Sprite manaImageWhite;

    public GameObject timeObject;
    public bool isInvisible = false;

    void Start() {
        timeObject.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        velocidadText.text = "Velocidad: " + velocidad.ToString();
        
        manaText.text = "Mana: " + mana.ToString() + "%";

        fuerzaText.text = "Fuerza: " + fuerza.ToString();

        velocidadTextSombra.text = "Velocidad: " + velocidad.ToString();

        manaTextSombra.text = "Mana: " + mana.ToString() + "%";

        fuerzaTextSombra.text = "Fuerza: " + fuerza.ToString();

        if (vida < 67)
        {
            heart3.GetComponent<Image>().sprite = heartEmpty;
        } else {
            heart3.GetComponent<Image>().sprite = heartFull;
        }
        if (vida < 37)
        {
            heart2.GetComponent<Image>().sprite = heartEmpty;
        } else {
            heart2.GetComponent<Image>().sprite = heartFull;
        }
        if (vida < 1)
        {
            heart1.GetComponent<Image>().sprite = heartEmpty;
        } else {
            heart1.GetComponent<Image>().sprite = heartFull;
        }

        if (resistencia < 3)
        {
            shield3.GetComponent<Image>().sprite = shieldEmpty;
        } else {
            shield3.GetComponent<Image>().sprite = shieldFull;
        }
        if (resistencia < 2)
        {
            shield2.GetComponent<Image>().sprite = shieldEmpty;
        } else {
            shield2.GetComponent<Image>().sprite = shieldFull;
        }
        if (resistencia < 1)
        {
            shield1.GetComponent<Image>().sprite = shieldEmpty;
        } else {
            shield1.GetComponent<Image>().sprite = shieldFull;
        }

        if (mana == 100) {
            // lo pondremos azul el color del manaText
            manaText.color = new Color32(0, 255, 255, 255);
            manaImage.GetComponent<Image>().sprite = manaImageBlue;
        }
    }

    public void subirMana(int cuanto)
    {
        mana += cuanto;
        if (mana > 100)
        {
            mana = 100;
        }
    }

    public void subirVida(int cuanto)
    {
        vida += cuanto;
        if (vida > 100)
        {
            vida = 100;
        }
    }

    public void startSpeedEffect(int cuanto, int segundos)
    {
        StartCoroutine(speedEffect(cuanto, segundos));
    }


    public void startStrengthEffect(int cuanto, int segundos)
    {
        StartCoroutine(strengthEffect(cuanto, segundos));
    }

    public void startInvisibilityEffect(int segundos)
    {
        StartCoroutine(invisibilityEffect(segundos));
    }

    IEnumerator invisibilityEffect(int segundos)
    {
        isInvisible = true;
        
        timeObject.SetActive(true);
        timeObject.GetComponent<TimeScript>().startCountdown(segundos);

        yield return new WaitForSeconds(segundos);
        isInvisible = false;
    }
    
    IEnumerator speedEffect(int cuanto, int segundos)
    {
        velocidad += cuanto;
        
        timeObject.SetActive(true);
        timeObject.GetComponent<TimeScript>().startCountdown(segundos);

        yield return new WaitForSeconds(segundos);
        velocidad -= cuanto;
    }

    IEnumerator strengthEffect(int cuanto, int segundos)
    {
        int prevFuerza = fuerza;
        fuerza = cuanto;
        
        timeObject.SetActive(true);
        timeObject.GetComponent<TimeScript>().startCountdown(segundos);

        yield return new WaitForSeconds(segundos);
        fuerza = prevFuerza;
    }

    public void startFlashUI(Color32 color, float segundos, TextMeshProUGUI text, GameObject icon)
    {
        StartCoroutine(flashUI(color, segundos, text, icon));
    }

    IEnumerator flashUI(Color32 color, float segundos, TextMeshProUGUI text, GameObject icon)
    {
        // cambiar velocidad text a color
        text.color = color;
        // cambiar speedImage a color
        icon.GetComponent<Image>().color = color;
        yield return new WaitForSeconds(segundos-2);

        // flash 10 times
        for (int i = 0; i < 10; i++) {
            text.color = color; // cambiar velocidad text a color
            icon.GetComponent<Image>().color = color; // cambiar speedImage a color
            yield return new WaitForSeconds(0.1f);
            text.color = new Color32(255, 255, 255, 255); // cambiar velocidad text a blanco
            icon.GetComponent<Image>().color = new Color32(255, 255, 255, 255); // cambiar speedImage a blanco
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator flashHearts() {
        // flash 10 times
        for (int i = 0; i < 10; i++) {
            // flash color red
            heart1.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            heart2.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            heart3.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        
            yield return new WaitForSeconds(0.1f);
            // flash color white
            heart1.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            heart2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            heart3.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void startFlashHearts() {
        StartCoroutine(flashHearts());
    }

    // esta función es para hacer flash al player 
    public void startFlashPlayer(Color32 color, float segundos)
    {
        StartCoroutine(flashPlayer(color, segundos));
    }

    IEnumerator flashPlayer(Color32 color, float segundos)
    {
        // store the previous color of the player
        Color32 prevColor = gameObject.GetComponent<SpriteRenderer>().color;
        // este game object su sprite renderer ponerlo color
        gameObject.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(segundos-2);

        // flash 10 times
        for (int i = 0; i < 10; i++) {
            gameObject.GetComponent<SpriteRenderer>().color = color; // este game object su sprite renderer ponerlo color
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255); // este game object su sprite renderer ponerlo blanco
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void recibirAtaque(int cuanto)
    {
        vida -= cuanto;
    }
}