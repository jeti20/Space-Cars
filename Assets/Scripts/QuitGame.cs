using UnityEngine;
using UnityEngine.InputSystem;

public class QuitGame : MonoBehaviour
{
    private void Update()
    {

        if (Keyboard.current.escapeKey.isPressed)
        {
            Application.Quit();
        }
    }
}
