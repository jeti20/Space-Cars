using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private Movement movement;
    [SerializeField] float levelLoadDelay = 2f;


    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("ok");
                break;
            case "Finish":
                StartSuccessSequence();              
                break;
            case "Fuel":
                Debug.Log("Fuel");
                break;
            default:
                StartCrashSequence();           
                break;
        }
    }

    private void StartSuccessSequence()
    {
        movement.OnDisable();
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    private void StartCrashSequence()
    {
        movement.OnDisable();
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentScene + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
        Debug.Log("wczytaj" + currentScene);
    }

    //After crsah, reload again the same scene
    private void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

}
