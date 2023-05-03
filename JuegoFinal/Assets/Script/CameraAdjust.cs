using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjust : MonoBehaviour {
     
     // Use this for initialization
     void Start () {
         GetComponent<Camera>().orthographicSize = 5; // Size u want to start with
     }
     
     // Update is called once per frame
     void Update () 
     {
         if(Input.GetKey(KeyCode.Q)) // Change From Q to anyother key you want
         {
             GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize + 1*Time.deltaTime;
             if(GetComponent<Camera>().orthographicSize > 8)
             {
                 GetComponent<Camera>().orthographicSize = 8; // Max size
             }
         }
 
 
         if(Input.GetKey(KeyCode.E)) // Also you can change E to anything
         {
             GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize - 1*Time.deltaTime;
             if(GetComponent<Camera>().orthographicSize < 6)
             {
                 GetComponent<Camera>().orthographicSize = 6; // Min size 
             }
        }
    }
}
