using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
    } 
    

     void PlayGame()
    {
        SceneManager.LoadSceneAsync("MapFunction");
    }

    // Update is called once per frame
    void Update()
    {

    }

     void QuitGame()
    {
        Application.Quit();
    }
}
