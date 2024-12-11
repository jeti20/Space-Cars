using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    public AudioClip backGroundMusic;
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        musicSource.clip = backGroundMusic;
        musicSource.Play();
    }

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
