using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor2 : MonoBehaviour {

    [SerializeField] private Key.KeyType keyType;
    public AudioSource doorOpenSound;


    //private DoorAnims doorAnims;

    // private void Awake() {
    //     doorAnims = GetComponent<DoorAnims>();
    // }

    public Key.KeyType GetKeyType() {
        return keyType;
    }

    public void OpenDoor() {
        doorOpenSound.Play();
        gameObject.SetActive(false);
        //doorAnims.OpenDoor();
    }

    // public void PlayOpenFailAnim() {
    //     //doorAnims.PlayOpenFailAnim();
    // }

}