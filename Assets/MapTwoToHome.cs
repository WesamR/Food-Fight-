using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTwoToHome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
