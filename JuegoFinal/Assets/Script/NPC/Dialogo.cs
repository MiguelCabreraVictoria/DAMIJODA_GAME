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
        
    // funcion publica void ComenzarDialogo que recibe como parametro un arreglo de mensajes (strings)
    // esta funcion se encarga de mostrar el dialogo en pantalla
    public void ComenzarDialogo(string[] mensajes) {
        Debug.Log("ComenzarDialogo");
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
        Debug.Log("Mostrar Dialogo: " + mensajes.Length);
        // Mientras el indice sea menor a la longitud del arreglo de mensajes
        while (indice < mensajes.Length) {
            Debug.Log("Mostrando Dialogo: " + indice);
            // Mostramos el mensaje en pantalla
            yield return StartCoroutine(EscribirMensaje(mensajes[indice]));
            // Esperamos a que el jugador presione la tecla X
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.X));
            // Incrementamos el indice
            indice++;
        }
        // Ocultamos el dialogo
        textDialogo.text = "";
        gameObject.SetActive(false);
        userStats.SetActive(true);
        userStatsSombra.SetActive(true);
        
    }

    // funcion IEnumerator EscribirMensaje que recibe como parametro un string
    // esta funcion se encarga de mostrar el mensaje en pantalla
    IEnumerator EscribirMensaje(string mensaje) {
        Debug.Log("Escribir Mensaje: " + mensaje);
        // Inicializamos el string mensajeActual en vacio
        string mensajeActual = "";
        // Mientras el string mensajeActual sea diferente al string mensaje
        while (mensajeActual != mensaje) {
            Debug.Log("Escribiendo Mensaje: " + mensajeActual);
            // Agregamos un caracter al string mensajeActual
            mensajeActual += mensaje[mensajeActual.Length];
            // Mostramos el string mensajeActual en pantalla
            textDialogo.text = mensajeActual;
            // Esperamos un tiempo
            yield return new WaitForSeconds(velocidad);
        }
    }
}