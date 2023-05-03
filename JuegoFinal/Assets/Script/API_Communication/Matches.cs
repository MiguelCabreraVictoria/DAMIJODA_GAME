using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

[System.Serializable]
public class Match{
    public int level_id;
    public string match_name;
}

[System.Serializable]
public class MatchList{    
    public List<Match> matches;
}

public class Matches : MonoBehaviour
{
    public InputField matchField;
    public GameObject StartButton;
    public Text matchListText;
    private string url = "http://localhost:5000/profile/api/matches";

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if(matchField.text.Length > 4)
        {
            StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
        }
    }

    public void OnStartButtonClick()
    {
        string match_name = matchField.text;
        Debug.Log("Created match: " + match_name);

        StartCoroutine(Post(url, match_name));
        SceneManager.LoadScene(4);
    }

    IEnumerator Post(string url, string match_name)
    {
        WWWForm form = new WWWForm();
        form.AddField("match_name", match_name);

        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error...");
        }
        else
        {
            Debug.Log("Success...");
        }
    }
}
