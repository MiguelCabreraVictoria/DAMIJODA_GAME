using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI textDialogo; // Referencia al objeto TextMeshProUGUI
    private int indice; // Indice del arreglo de mensajes
    public float velocidad = 1.0f; // Velocidad de escritura
    public GameObject userStats;
    public GameObject userStatsSombra;

    // Agrega una referencia al AudioClip y al AudioSource
    public AudioClip sonidoBorrego;
    private AudioSource audioSource;

    public Misiones misiones;

    private void Awake()
    {
        // Inicializa el AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
    }
        
    // funcion publica void ComenzarDialogo que recibe como parametro un arreglo de mensajes (strings)
    // esta funcion se encarga de mostrar el dialogo en pantalla
    public void ComenzarDialogo(string[] mensajes) {
        // Inicializamos el indice en 0
        indice = 0;
        // Mostramos el dialogo
        StartCoroutine(MostrarDialogo(mensajes));
        userStats.SetActive(false);
        userStatsSombra.SetActive(false);
        
    }

    // funcion IEnumerator MostrarDialogo que recibe como parametro un arreglo de mensajes (strings)
    // esta funcion se encarga de mostrar el dialogo en pantalla
    IEnumerator MostrarDialogo(string[] mensajes) {
        // Mientras el indice sea menor a la longitud del arreglo de mensajes
        while (indice < mensajes.Length) {
            // Mostramos el mensaje en pantalla
            yield return StartCoroutine(EscribirMensaje(mensajes[indice]));
            // Esperamos a que el jugador presione la tecla X
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.X));
            // Incrementamos el indice
            indice++;
        }
        // Ocultamos el dialogo
        if (misiones.misionNr == 3) {
            misiones.misionNr = 4;
        }
        Debug.Log("Mision 4");

        textDialogo.text = "";
        gameObject.SetActive(false);
        userStats.SetActive(true);
        
        userStatsSombra.SetActive(true);

    }

    // funcion IEnumerator EscribirMensaje que recibe como parametro un string
    // esta funcion se encarga de mostrar el mensaje en pantalla
    IEnumerator EscribirMensaje(string mensaje) {
        // Reproduce el sonido antes de empezar a escribir el mensaje
        audioSource.PlayOneShot(sonidoBorrego);

        // Inicializamos el string mensajeActual en vacio
        string mensajeActual = "";
        // Mientras el string mensajeActual sea diferente al string mensaje
        while (mensajeActual != mensaje) {
            // Agregamos un caracter al string mensajeActual
            mensajeActual += mensaje[mensajeActual.Length];
            // Mostramos el string mensajeActual en pantalla
            textDialogo.text = mensajeActual;
            // Esperamos un tiempo
            yield return new WaitForSeconds(velocidad);
        }
    }
}