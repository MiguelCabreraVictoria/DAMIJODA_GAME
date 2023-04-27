using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class Gpt : MonoBehaviour
{
    [System.Serializable]
    public class CompletionRequestBody
    {
        public string model;
        public string prompt;
        public int max_tokens;
        public float temperature;
        public float top_p;
        public int n;
        public bool stream;
        public string stop;
    }

    private const string API_URL = "https://api.openai.com/v1/completions";
    private const string API_KEY = "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";

    public IEnumerator RequestCompletion(string prompt, Action<string> callback)
    {
        using (UnityWebRequest request = new UnityWebRequest(API_URL, "POST"))
        {
            // Establece los encabezados de la solicitud
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + API_KEY);

            // Configura los parámetros del cuerpo de la solicitud
            CompletionRequestBody requestBody = new CompletionRequestBody
            {
                model = "text-davinci-003",
                prompt = prompt,
                max_tokens = 40,
                temperature = 0.7f,
                top_p = 1,
                n = 1,
                stream = false,
                //stop = "\n"
            };

            string requestBodyJson = JsonUtility.ToJson(requestBody);
            byte[] requestBodyBytes = Encoding.UTF8.GetBytes(requestBodyJson);
            request.uploadHandler = new UploadHandlerRaw(requestBodyBytes);
            request.downloadHandler = new DownloadHandlerBuffer();

            // Envía la solicitud
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error en la solicitud: " + request.error);
            }
            else
            {
                var jsonResponse = JSON.Parse(request.downloadHandler.text);
                //Debug.Log("Respuesta completa: " + jsonResponse.ToString()); // Agrega esta línea para imprimir la respuesta completa
                string responseText = jsonResponse["choices"][0]["text"];

                // Quita los caracteres de nueva línea de la respuesta
                responseText = responseText.Replace("\n", "");
                responseText = responseText.Replace("\"", "");
                

                callback(responseText);
                Debug.Log("Respuesta: " + responseText);
            }
        }
    }
}
