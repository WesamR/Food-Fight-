using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
    } 
    

<<<<<<< Updated upstream
     void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
=======

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("FruitSpawnScene");
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {

    }

<<<<<<< Updated upstream
     void QuitGame()
=======
    public void QuitGame()
>>>>>>> Stashed changes
    {
        Application.Quit();
    }
}
