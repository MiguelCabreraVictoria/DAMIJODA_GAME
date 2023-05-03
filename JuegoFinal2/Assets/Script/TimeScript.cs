using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeScript : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI timeTextSombra;
    
    public void startCountdown(int time)
    {
        StartCoroutine(countdown(time));
    }

    IEnumerator countdown(int time)
    {
 
        while (time > 0)
        {
            if (time < 10)
            {
                timeText.text = "0:0" + time.ToString();
                timeTextSombra.text = "0:0" + time.ToString();
            }
            else
            {
                timeText.text = "0:" + time.ToString();
                timeTextSombra.text = "0:" + time.ToString();
            }
            yield return new WaitForSeconds(1);
            time--;
        }
        timeText.text = "0:00";
        timeTextSombra.text = "0:00";
        gameObject.SetActive(false);
    }
}
