using UnityEngine;

public class MenuScenemanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void StartGame()
        {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FirstProto");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
