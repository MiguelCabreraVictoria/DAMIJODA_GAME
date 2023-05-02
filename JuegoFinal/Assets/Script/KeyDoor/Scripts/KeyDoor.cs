﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour {

    [SerializeField] private Key.KeyType keyType;

    //private DoorAnims doorAnims;

    // private void Awake() {
    //     doorAnims = GetComponent<DoorAnims>();
    // }

    public Key.KeyType GetKeyType() {
        return keyType;
    }

    public void OpenDoor() {
        gameObject.SetActive(false);
        //doorAnims.OpenDoor();
    }

    // public void PlayOpenFailAnim() {
    //     //doorAnims.PlayOpenFailAnim();
    // }

}