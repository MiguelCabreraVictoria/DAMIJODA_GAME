using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//when something get into the alta, make the runes glow
namespace Cainos.PixelArtTopDown_Basic
{

    public class PropsAltarWKey : MonoBehaviour
    {
        [SerializeField] private GameObject needKeyText;
        public List<SpriteRenderer> runes;
        public float lerpSpeed;

        private Color curColor;
        private Color targetColor;

        public Laser laser;

        private keyTele key;

        private void Start()
        {
            needKeyText.gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if(collision.gameObject.name.Equals("Player") && key.hasKey == true)
            {
            targetColor = new Color(1, 1, 1, 1);
            }
            if(collision.gameObject.name.Equals("Player") && key.hasKey == false)
            {
                needKeyText.gameObject.SetActive(true);
                Debug.Log("puto");
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            targetColor = new Color(1, 1, 1, 0);
            needKeyText.gameObject.SetActive(false);
        }

        private void Update()
        {
            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

            foreach (var r in runes)
            {
                r.color = curColor;
            }

            if (curColor == new Color(1, 1, 1, 1)) {
                Debug.Log("Altar is activated");
                laser.startLaser();
            }
        }
    }
}