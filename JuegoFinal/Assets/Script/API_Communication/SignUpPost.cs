using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class SignUpPost : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;
    public GameObject Createbutton;
    public GameObject LogInbutton;
    private string url = "http://localhost:5000/signup";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(usernameField.text.Length > 4 && passwordField.text.Length > 4)
        {
            Createbutton.SetActive(true);
        }
        else
        {
            Createbutton.SetActive(false);
        }
    }

    public void OnCreateButtonClick()
    {
        string username = usernameField.text;
        string password = passwordField.text;

        Debug.Log("username: " + username + " password: " + password);

        StartCoroutine(Post(url, username, password));

        SceneManager.LoadScene(1);
    }

    public void OnLogInButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator Post(string url, string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error: " + www.error);
        }
        else
        {
            Debug.Log("Success ...");
        }
    }
}