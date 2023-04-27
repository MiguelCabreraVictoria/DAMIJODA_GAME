using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public int heartNum;
    public CharacterDamageController characterDamage;
    public CharacterBulletDamageController characterBulletDamage;
    public Sprite heartFull;
    public Sprite heartEmpty;
    private Image heartImage;

    // Start is called before the first frame update
    void Start()
    {
        heartImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((characterDamage.vidas < heartNum) || (characterBulletDamage.vidas < heartNum))
        {
            // Cambia la imagen a corazón gris
            heartImage.sprite = heartEmpty;
        }
        else
        {
            // Cambia la imagen a corazón lleno
            heartImage.sprite = heartFull;
        }
    }
}
