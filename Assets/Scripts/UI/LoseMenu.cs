using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class LoseMenu : MonoBehaviour
{
    public  GameObject loseMenuUI;
    GameObject         player;
    [Header("UI")]
    public EventSystem eventSystem;
    public GameObject    retryButton;
    public TimerMetaData timerMetaData;
    MetaDataSystem       metaDataSystem;
    PlayerData          playerData;
    public TextMeshProUGUI   metaRessourceText;
    bool giveMetaDataBonus;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        loseMenuUI.SetActive(false);
        player         = GameObject.FindGameObjectWithTag("Player");
        metaDataSystem = FindObjectOfType<MetaDataSystem>();
        playerData     = FindObjectOfType<PlayerData>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Time.timeScale = 0f;
            loseMenuUI.SetActive(true);
            eventSystem.SetSelectedGameObject(retryButton);
            if (giveMetaDataBonus == false)
            {
                playerData.metaData += timerMetaData.metaRessourceBonus;

                metaDataSystem.SetMetaData(playerData.metaData);
                metaRessourceText.text = "+" + timerMetaData.metaRessourceBonus;
                giveMetaDataBonus      = true;
                PlayerPrefs.Save();
            }
            
        }
        if (player == null && (Input.GetKeyDown(KeyCode.JoystickButton1)))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
}
