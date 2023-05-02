using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Misiones : MonoBehaviour
{
    public int misionNr = 1;
    public int gemasRecolectadas = 0;
    public TextMeshProUGUI misionText;
    public TextMeshProUGUI misionSombraText;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (misionNr == 2)
        {
            Debug.Log("Mision 2");
            misionText.text = "Mision 2: encuentra las " + gemasRecolectadas.ToString() + "/5 gemas";
            misionSombraText.text = "Mision 2: encuentra las " + gemasRecolectadas.ToString() + "/5 gemas";
        }
        if (gemasRecolectadas == 5 && misionNr == 2)
        {
            Debug.Log("Mision 2 completada");
            misionNr = 3;
            misionText.text = "Mision 3: ve con Teus";
            misionSombraText.text = "Mision 3: ve con Teus";
        }
    }
}
