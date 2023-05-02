using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject buttonNewGame;
    public GameObject buttonLoadGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGameButton(){
        SceneManager.LoadScene(3);
    }

    public void LoadGameButton(){
        SceneManager.LoadScene(5);
    }
}
