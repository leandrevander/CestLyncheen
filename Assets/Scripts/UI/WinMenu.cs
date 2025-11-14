using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class WinMenu : MonoBehaviour
{
    public GameObject winMenuUI;
    private Gamepad gamepad;
    [Header("UI")]
    public EventSystem eventSystem;
    public GameObject retryButton;

    public bool win;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        winMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            Time.timeScale = 0f;
            winMenuUI.SetActive(true);
            eventSystem.SetSelectedGameObject(retryButton);
        }
    }
}
