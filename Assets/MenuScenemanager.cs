using UnityEngine;
using UnityEngine.EventSystems;

public class MenuScenemanager : MonoBehaviour
{
    public GameObject play;
    public GameObject option;
    public GameObject quit;
    public GameObject level1;
    public GameObject level2;
    public GameObject returnButton;
    public EventSystem  eventSystem;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void StartLevel1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }
    
    public void StartLevel2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void PressedPlayButton()
    {
        play.SetActive(false);
        option.SetActive(false);
        quit.SetActive(false);
        level1.SetActive(true);
        level2.SetActive(true);
        returnButton.SetActive(true);
        eventSystem.SetSelectedGameObject(level1);
    }

    public void PressedReturnButton()
    {
        play.SetActive(true);
        option.SetActive(true);
        quit.SetActive(true);
        level1.SetActive(false);
        level2.SetActive(false);
        returnButton.SetActive(false);
        eventSystem.SetSelectedGameObject(play);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
