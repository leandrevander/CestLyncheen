using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class LoseMenu : MonoBehaviour
{
    public  GameObject loseMenuUI;
    GameObject         player;
    [Header("UI")]
    public EventSystem eventSystem;
    public GameObject retryButton;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        loseMenuUI.SetActive(false);
        player         = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Time.timeScale = 0f;
            loseMenuUI.SetActive(true);
            eventSystem.SetSelectedGameObject(retryButton);
        }
    }
}
