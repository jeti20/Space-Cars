using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CollisionHandler : MonoBehaviour
{
    private Movement movement;
    [SerializeField] float levelLoadDelay = 2f;

    [Header("Audio")]
    AudioSource audioSource;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    bool isControllable = true;
    bool isCollideble = true;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RespondToDebugKeys();
    }

    //Pressing "L" skip player to next level
    private void RespondToDebugKeys()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNextLevel();
        }
        //Pressing "C" skip, player turn of collision so OnCollisionEnter can be performed (player cannot win/lose)
        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            isCollideble = !isCollideble;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if player cannot controll then break the method and do not execute the rest in this method. Also or if player turned off collision then do not detect obejcts by tags
        if (!isControllable || !isCollideble) { return; }

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

    void StartSuccessSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        movement.OnDisable();
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        movement.OnDisable();
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void LoadNextLevel()
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
    void ReloadLevel()
    {      
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

}
