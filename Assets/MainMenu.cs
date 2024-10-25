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
        SceneManager.LoadSceneAsync("FruitSpawnScene");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
