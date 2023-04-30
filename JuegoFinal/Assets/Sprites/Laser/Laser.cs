using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importar SceneManager para cambiar de escena
using UnityEngine.Audio; // Importar Audio para reproducir el sonido del láser

public class Laser : MonoBehaviour
{
    private Animator animator;
    public AudioClip laserSound; // Añadir un AudioClip para almacenar el sonido del láser
    private AudioSource audioSource; // Añadir un AudioSource para reproducir el sonido
    private bool hasBeenActivated = false; // Añadir una variable para saber si el láser ya se había activado
    public TopDownCharacterController characterObject; // Añadir una variable para almacenar la referencia al objeto personaje

    void Start () {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // Inicializar el AudioSource
    }

    public void startLaser () {
        if (hasBeenActivated) return; // Si ya se había activado antes, entonces no hacer nada
        hasBeenActivated = true;

        // Si no se había activado antes, entonces:
        Debug.Log("Laser is activated");
        animator.SetBool("isActivated", true);
        characterObject.teleport(); // Teletransportar al personaje

        // Reproduce sonido de láser
        audioSource.PlayOneShot(laserSound);

        // Espera 2 segundos y cambia a la escena aulas1
        StartCoroutine(WaitAndChangeScene(3.5f));
    }

    IEnumerator WaitAndChangeScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        // Cambia a la escena llamada aulas1
        SceneManager.LoadScene("Aulas1");
    }
}
