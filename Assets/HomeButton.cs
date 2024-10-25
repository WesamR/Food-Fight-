using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{

    void Update()
    {
        // Check if the Tab key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Perform the action, like loading a new scene
            Debug.Log("Tab key pressed!");

            // Load a new scene, or perform any other action
            SceneManager.LoadScene(0); // Replace with your scene name
        }
    }
    //private void OnMouseDown()
    //{
    //    // This function is called when the object is clicked
    //    Debug.Log("Button clicked!");

    //    // Load a new scene, or perform some other action
    //    SceneManager.LoadScene(0); // Replace with your scene name
    //}

}
