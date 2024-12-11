using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class Menu : MonoBehaviour
{
    // Called when we click the "Play" button.
    public void OnPlayButton ()
    {
        SceneManager.LoadScene(1);
    }

    // Called when we click the "Quit" button.
    public void OnQuitButton ()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        // If the Escape key is pressed, load scene with index 0 (Menu)
        if (Keyboard.current.escapeKey.isPressed && SceneManager.GetActiveScene().buildIndex != 0)
        {
            Debug.Log("XD");
            SceneManager.LoadScene(0);
        }
    }
}