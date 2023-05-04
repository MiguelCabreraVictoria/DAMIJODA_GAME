using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Importa el namespace de SceneManagement
using TMPro;
using UnityEngine.Audio;

public class CharacterMenu : MonoBehaviour
{
    int n = 0;
    public Image image;
    public Sprite[] sprites;
    public TextMeshProUGUI skinNumberText; // Referencia al objeto TextMeshProUGUI

    private Animator animator;

    private string selectedSkinKey = "SelectedSkin"; // Define una clave única para la selección de la skin

    string[] nombres = new string[6]; // Crea un arreglo de nombres de 5 elementos

    public AudioClip beboSound;
    public AudioClip davidSound;
    public AudioClip natSound;
    public AudioClip danSound;
    public AudioClip miguelSound;

    
    private AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    
        // Asigna valores a cada elemento del arreglo
        nombres[0] = "Bebo";
        nombres[1] = "Daniel";
        nombres[2] = "David";
        nombres[3] = "Joaquin";
        nombres[4] = "Miguel";
        nombres[5] = "Nat";

        if (PlayerPrefs.HasKey(selectedSkinKey))
        {
            // Si existe la clave de la selección de la skin, carga la selección guardada
            n = PlayerPrefs.GetInt(selectedSkinKey);
            animator.SetInteger("Character", n);
            image.sprite = sprites[n];
        }
        
        UpdateSkinNumberText(); // Actualiza el valor del texto
    }

    public void Next()
    {
        n++;
        if (n > 5)
        {
            n = 0;
        }
        Debug.Log(n);
        image.sprite = sprites[n];
        PlayerPrefs.SetInt(selectedSkinKey, n); // Guarda la selección de la skin utilizando PlayerPrefs
        repoducirSonido(n);
        UpdateSkinNumberText(); // Actualiza el valor del texto
    }

    public void Prev()
    {
        n--;
        if (n < 0)
        {
            n = 5;
        }
        Debug.Log(n);
        image.sprite = sprites[n];
        PlayerPrefs.SetInt(selectedSkinKey, n); // Guarda la selección de la skin utilizando PlayerPrefs
        repoducirSonido(n);
        UpdateSkinNumberText(); // Actualiza el valor del texto
    }

    private void repoducirSonido(int n) {
        if (n == 0)
        {
            // reproduce sonido de bebo
            audioSource.PlayOneShot(beboSound);
        }
        else if (n == 2)
        {
            // reproduce sonido de david
            audioSource.PlayOneShot(davidSound);
        }
        else if (n == 5)
        {
            // reproduce sonido de nat
            audioSource.PlayOneShot(natSound);
        }
        else if (n == 1)
        {
            // reproduce sonido de dan
            audioSource.PlayOneShot(danSound);
        }
        else if (n == 4)
        {
            // reproduce sonido de miguel
            audioSource.PlayOneShot(miguelSound);
        }

    }

    private void UpdateSkinNumberText()
    {
        // Actualiza el valor del texto en el objeto TextMeshProUGUI
        animator.SetInteger("Character", n);
        skinNumberText.text = nombres[n];
    }

    public void Play()
    {
        // Carga la escena "MainGarden"
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGarden");
    }
}