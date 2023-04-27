using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int velocidad = 3;
    public int resistencia = 3;
    public int vida = 100;
    public int fuerza = 5;
    public int mana = 100;

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
    public Sprite manaImageBlue;
    public Sprite manaImageWhite;
    
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
        } else {
            // lo pondremos blanco el color del manaText
            manaText.color = new Color32(255, 255, 255, 255);
            manaImage.GetComponent<Image>().sprite = manaImageWhite;
        }
    }

    public void SubirMana(int cuanto)
    {
        mana += cuanto;
        if (mana > 100)
        {
            mana = 100;
        }
    }

    public void recibirAtaque(int cuanto)
    {
        vida -= cuanto;
        if (vida <= 0)
        {
            Debug.Log("¡El personaje ha muerto!");
            // Aquí puedes agregar código para manejar la muerte del personaje, como mostrar una pantalla de Game Over
        }
    }
}
