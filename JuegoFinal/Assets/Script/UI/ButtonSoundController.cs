using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundController : MonoBehaviour
{
    public Button button;
    public AudioSource audioSource;

    void Start()
    {
        button.onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        audioSource.Play();
    }
}
