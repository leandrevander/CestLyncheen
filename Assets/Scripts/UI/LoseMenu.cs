using UnityEngine;
using UnityEngine.InputSystem;


public class LoseMenu : MonoBehaviour
{
    public  GameObject loseMenuUI;
    private Gamepad    gamepad;
    GameObject         player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        gamepad = Gamepad.current;
        loseMenuUI.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Time.timeScale = 0f;
            loseMenuUI.SetActive(true);
            if (gamepad.buttonSouth.wasPressedThisFrame)
            {
                Time.timeScale = 1f;
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
