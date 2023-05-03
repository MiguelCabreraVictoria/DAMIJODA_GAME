using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class GetMatch : MonoBehaviour
{
    public GameObject labelPrefab;
    public Transform labelContainer;
    private List<Partida> partidas;

    void Start()
    {
        StartCoroutine(GetPartidas());
    }

    IEnumerator GetPartidas()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost:5000/profile/api/matches");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string json = www.downloadHandler.text;
            partidas = JsonUtility.FromJson<List<Partida>>(json);
            CreateLabels();
        }
    }

    void CreateLabels()
    {
        for (int i = 0; i < partidas.Count; i++)
        {
            GameObject label = Instantiate(labelPrefab, labelContainer);
            Text labelText = label.GetComponentInChildren<Text>();
            labelText.text = partidas[i].match_name;
        }
    }

    public void LoadPartida(int id)
    {
        SceneManager.LoadScene(id);
    }
}

[System.Serializable]
public class Partida
{
    public int match_id;
    public int user_id;
    public int level_id;
    public string match_name;
}
