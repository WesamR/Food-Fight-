using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public MenueSound pam5;
    void Start()
    {
        pam5 = GetComponent<MenueSound>();
        pam5.Mainnue();
    } 

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
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
