using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
<<<<<<< Updated upstream
    {
        
    }

    public void PlayGame()
=======
>>>>>>> Stashed changes
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

    // Update is called once per frame
    void Update()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
