    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;
    using UnityEngine.Networking;

    public class LoginPost : MonoBehaviour
    {
        public InputField usernameField;
        public InputField passwordField;
        public GameObject buttonSubmit;
        public GameObject buttonSignUp;
        private string url = "http://localhost:5000/login";

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (usernameField.text.Length > 4 && passwordField.text.Length > 4)
            {
                buttonSubmit.SetActive(true);
            }
            else
            {
                buttonSubmit.SetActive(false);
            }
        }

        public void OnButtonSubmitClick()
        {
            string username = usernameField.text;
            string password = passwordField.text;

            Debug.Log("username: " + username + " username: " + password);

            StartCoroutine(Post(url, username, password));
            
        }

        public void OnButtonSignUpClick()
        {
            SceneManager.LoadScene(0);
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
        string responseText = www.downloadHandler.text;
        if (responseText.Contains("Authentication fallo"))
        {
            Debug.Log("Error: " + responseText);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
    }