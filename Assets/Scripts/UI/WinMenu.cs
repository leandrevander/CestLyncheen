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
    MetaDataSystem    metaDataSystem;
    PlayerData      playerData;


    public bool win;
    bool        giveMetaDataBonus;
    bool alreadySetSelectedButton;
    public bool isLevel1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        winMenuUI.SetActive(false);
        metaDataSystem = FindObjectOfType<MetaDataSystem>();
        playerData     = FindObjectOfType<PlayerData>();


    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            Time.timeScale = 0f;
            winMenuUI.SetActive(true);
            if (alreadySetSelectedButton == false)
            {
                eventSystem.SetSelectedGameObject(retryButton);
                alreadySetSelectedButton = true;

            }
            if (giveMetaDataBonus == false)
            {
                playerData.metaData += 500;
                metaDataSystem.SetMetaData(playerData.metaData);
                giveMetaDataBonus = true;
            }

            if (isLevel1)
            {
                playerData.unlockedLevel2Def = 1;
                metaDataSystem.SetMetaData(playerData.unlockedLevel2Def);
                isLevel1 = false;
                PlayerPrefs.Save();
            }
            

        }
        if (win && (Input.GetKeyDown(KeyCode.JoystickButton1)))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            }
    }
}
