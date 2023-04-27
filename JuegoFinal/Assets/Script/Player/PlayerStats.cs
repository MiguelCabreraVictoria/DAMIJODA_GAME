using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    public int velocidad = 3;
    public int resistencia = 3;
    public int vida = 3;
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
    
    // Update is called once per frame
    void Update()
    {
        velocidadText.text = "Velocidad: " + velocidad.ToString();
        
        manaText.text = "Mana: " + mana.ToString() + "%";

        fuerzaText.text = "Fuerza: " + fuerza.ToString();

        velocidadTextSombra.text = "Velocidad: " + velocidad.ToString();

        manaTextSombra.text = "Mana: " + mana.ToString() + "%";

        fuerzaTextSombra.text = "Fuerza: " + fuerza.ToString();

        if (vida < 3)
        {
            heart3.GetComponent<Image>().sprite = heartEmpty;
        }
        if (vida < 2)
        {
            heart2.GetComponent<Image>().sprite = heartEmpty;
        }
        if (vida < 1)
        {
            heart1.GetComponent<Image>().sprite = heartEmpty;
        }

        if (resistencia < 3)
        {
            shield3.GetComponent<Image>().sprite = shieldEmpty;
        }
        if (resistencia < 2)
        {
            shield2.GetComponent<Image>().sprite = shieldEmpty;
        }
        if (resistencia < 1)
        {
            shield1.GetComponent<Image>().sprite = shieldEmpty;
        }
    }
}
