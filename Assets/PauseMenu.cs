using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] AudioSource select ;
    public           GameObject  pauseMenuUI;
    [Header("UI")]
    public EventSystem eventSystem;
    public GameObject      resumeButton;
    public GameObject      optionMenu;
    public GameObject      musicVolume;
    PlayerData             playerData;
    public TextMeshProUGUI metaDataText;
    bool                   isPaused;
    GameObject             player;
    public WinMenu         winMenu;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        player     = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.JoystickButton7) && (player != null) && (winMenu.win == false)))
        {
            if (isPaused == false)
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                eventSystem.SetSelectedGameObject(resumeButton);
                metaDataText.text ="" +playerData.metaData;
                isPaused = true;
            }
            else
            {
                ResumeGame();
            }
        }

    }
    public void ResumeGame()
    {
        select.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused       = false;

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
    public void OptionMenu()
    {
        pauseMenuUI.SetActive(false);
        optionMenu.SetActive(true);
        //eventSystem.SetSelectedGameObject(musicVolume);

    }
    public void BackButton()
    {
        optionMenu.SetActive(false);
        pauseMenuUI.SetActive(true);
       
    }
}
