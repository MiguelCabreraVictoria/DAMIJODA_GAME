using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor2 : MonoBehaviour {

    [SerializeField] private Key.KeyType keyType;


    //private DoorAnims doorAnims;

    // private void Awake() {
    //     doorAnims = GetComponent<DoorAnims>();
    // }

    public Key.KeyType GetKeyType() {
        return keyType;
    }

    public void OpenDoor() {
        // desactivar el collider
        gameObject.SetActive(false);
        // desactivar el sprite renderer
        //doorAnims.OpenDoor();
    }

    // public void PlayOpenFailAnim() {
    //     //doorAnims.PlayOpenFailAnim();
    // }

}
