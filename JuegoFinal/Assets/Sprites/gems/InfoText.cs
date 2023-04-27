using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoText : MonoBehaviour
{
    public bool showInfo = false;

    // cuando se haga el set active al objeto, entonces esperar 3 segundos y esconderlo
    void OnEnable() {
        // esperar 3 segundos y esconderlo
        StartCoroutine(HideInfo());
    }

    IEnumerator HideInfo() {
        Debug.Log("Esperando 3 segundos");
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
        showInfo = false;
    }
}
