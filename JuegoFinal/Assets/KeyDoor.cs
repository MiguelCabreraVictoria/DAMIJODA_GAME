using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour {

    [SerializeField] private Key.KeyType keyType;
    public AudioSource doorOpenSound;

    
    public GameObject door;


    //private DoorAnims doorAnims;

    // private void Awake() {
    //     doorAnims = GetComponent<DoorAnims>();
    // }

    public Key.KeyType GetKeyType() {
        return keyType;
    }

    public void OpenDoor() {
        doorOpenSound.Play();
        // desactivar el collider
        door.SetActive(false);
        // desactivar el sprite renderer
        //doorAnims.OpenDoor();
    }

    // public void PlayOpenFailAnim() {
    //     //doorAnims.PlayOpenFailAnim();
    // }

}
