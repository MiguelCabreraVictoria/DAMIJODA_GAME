using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkZone : MonoBehaviour
{
    private bool IsOnTalkZone = false;
    private bool IsTalking = false;
    public GameObject InfoBox;
    public GameObject DialogBox;
    
    public Dialogo dialogo;
    public CharacterAttackController characterAttackController;

    public GameObject userStats;
    public GameObject userStatsSombra;

    void Start() {
        InfoBox.SetActive(false);
        DialogBox.SetActive(false);
    }

    void Update()
    {
        if (IsOnTalkZone && Input.GetKeyDown(KeyCode.X)) {
            Debug.Log("Player pressed X");
            // show the dialog box
            DialogBox.SetActive(true);
            InfoBox.SetActive(false);
            // start the dialog
            if (!IsTalking) {
                IsTalking = true;
                dialogo.ComenzarDialogo(new string[] {"Bienvenido heroe, presiona X para continuar...", "yo soy Borret el dios borrego, beeee", "Cuando estes listo para comenzar la aventura...", "sube las escaleras y mantente 5 segundos sobre el altar."});
            }
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.name == "Player") {
            Debug.Log("Player entered the trigger zone");
            IsOnTalkZone = true;
            InfoBox.SetActive(true);
            characterAttackController.isOnTalkZone = true;
        }
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.name == "Player") {
            Debug.Log("Player exited the trigger zone");
            IsOnTalkZone = false;
            // hide the dialog box
            InfoBox.SetActive(false);
            DialogBox.SetActive(false);
            characterAttackController.isOnTalkZone = false;
            dialogo.StopAllCoroutines();
            dialogo.textDialogo.text = "";
            IsTalking = false;
            userStats.SetActive(true);
            userStatsSombra.SetActive(true);
        }

    }
}
