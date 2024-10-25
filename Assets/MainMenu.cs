using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
    } 

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Update()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
