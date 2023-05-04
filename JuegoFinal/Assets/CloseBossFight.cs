using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBossFight : MonoBehaviour
{
    public GameObject bossWall;
    public GameObject boss;
    public Camera cam;

    public float targetSize = 8f; // Size u want to end with
    public float duration = 1f; // Duration of the transition

    private float initialSize;
    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        bossWall.SetActive(false);   
        boss.SetActive(false);
        initialSize = cam.orthographicSize;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider) {
        if (!triggered && collider.gameObject.tag == "Player") {
            triggered = true;
            bossWall.SetActive(true);
            boss.SetActive(true);
            StartCoroutine(TransitionCameraSize());
            //cam.GetComponent<Camera>().orthographicSize = 8; // Size u want to start with
        }
    }

    private IEnumerator TransitionCameraSize() {
        float elapsedTime = 0;
        while (elapsedTime < duration) {
            cam.orthographicSize = Mathf.Lerp(initialSize, targetSize, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cam.orthographicSize = targetSize; // Ensure final size is set exactly
    }
}