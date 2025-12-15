using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] AudioSource select ;
    public           GameObject  pauseMenuUI;
    [Header("UI")]
    public EventSystem eventSystem;
    public GameObject resumeButton;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.JoystickButton7)))
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            eventSystem.SetSelectedGameObject(resumeButton);
        }

    }
    public void ResumeGame()
    {
        select.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RetryGame()
    {
        select.Play();
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    public void ReturnToMenu()
    {
        select.Play();
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
