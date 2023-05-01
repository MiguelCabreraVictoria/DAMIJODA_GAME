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
    public GameObject button;
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
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }

    public void OnButtonClick()
    {
        string username = usernameField.text;
        string password = passwordField.text;

        Debug.Log("username: " + username + " username: " + password);

        StartCoroutine(Post(url, username, password));
    }

    IEnumerator Post(string url, string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log("Error: " + www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}