using UnityEngine;
using UnityEngine.InputSystem;

public class WinMenu : MonoBehaviour
{
    public GameObject winMenuUI;
    private Gamepad gamepad;

    public bool win;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        gamepad = Gamepad.current;
        winMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            Time.timeScale = 0f;
            winMenuUI.SetActive(true);
            if (gamepad.buttonSouth.wasPressedThisFrame)
            {
                Time.timeScale = 1f;
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
