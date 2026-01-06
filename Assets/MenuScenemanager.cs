using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuScenemanager : MonoBehaviour
{
    public GameObject  play;
    public GameObject  level1;
    public GameObject  unlockBulbButtonGO;
    public GameObject  unlockMenuButtonGO;
    public GameObject  musicVolumeSliderGO;
    public AudioSource select;
    

    public GameObject mainMenuPage;
    public GameObject upgradePage;
    public GameObject playPage;
    public GameObject optionsPage;
    


    public EventSystem    eventSystem;
    public PlayerData     playerData;
    public MetaDataSystem metaDataSystem;
    
    public TextMeshProUGUI unlockedBulbDefText;
    public TextMeshProUGUI unlockedCameraDefText;
    public TextMeshProUGUI unlockedGlowstickDefText;


    
    [Header("Items 's Price")]
    public int bulbPrice;
    public int glowstickPrice;
    public int cameraPrice;
    
    public TextMeshProUGUI bulbPriceText;
    public TextMeshProUGUI cameraPriceText;
    public TextMeshProUGUI glowstickPriceText;
    public TextMeshProUGUI playerMoneyText;
    
    
    [Header("Items 's Buttons")]
    public Button unlockBulbButton;
    public Button unlockCameraButton;
    public Button unlockGlowstickButton;
    
    [Header("Level 2")]
    public Button level2Button;
    public GameObject level2Text;




    public Color gray;
    public Color white;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenuPage.SetActive(true);
        playPage.SetActive(false);
        upgradePage.SetActive(false);
        eventSystem.SetSelectedGameObject(play);
    }
    public void StartLevel1()
    {
        select.Play();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }
    
    public void StartLevel2()
    {
        select.Play();

        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    }
    
    public void StartLEANDRE3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LEANDRE3");
    }
    public void QuitGame()
    {
        select.Play();

        Application.Quit();
    }

    public void PressedPlayButton()
    {
        select.Play();

        mainMenuPage.SetActive(false);
        playPage.SetActive(true);
        upgradePage.SetActive(false);
        eventSystem.SetSelectedGameObject(level1);
        CheckUnlockLevel2();
    }

    public void PressedOptionsButton()
    {
        select.Play();

        mainMenuPage.SetActive(false);
        optionsPage.SetActive(true);
        eventSystem.SetSelectedGameObject(musicVolumeSliderGO);
    }

    public void PressedReturnButton()
    {
        select.Play();

        mainMenuPage.SetActive(true);
        playPage.SetActive(false);
        optionsPage.SetActive(false);
        upgradePage.SetActive(false);
        eventSystem.SetSelectedGameObject(play);
    }
    
    public void PressedReturnButtonFromUpgradeMenu()
    {
        select.Play();

        mainMenuPage.SetActive(true);
        playPage.SetActive(false);
        upgradePage.SetActive(false);
        eventSystem.SetSelectedGameObject(unlockMenuButtonGO);
    }

    public void PressedUnlockMenuButton()
    {
        select.Play();

        mainMenuPage.SetActive(false);
        playPage.SetActive(false);
        upgradePage.SetActive(true);
        eventSystem.SetSelectedGameObject(unlockBulbButtonGO);
        RefreshUnlockButtons();
        RefreshPriceTexts();


    }

    public void CheckUnlockLevel2()
    {
        if (playerData.unlockedLevel2Def == 0)
        {
            var level2ButtonColor = level2Button.colors;
            level2ButtonColor.normalColor = gray;
            level2Button.colors       = level2ButtonColor;
            level2Button.interactable = false;
            level2Text.SetActive(true);
            
        }
        else
        {
            var level2ButtonColor = level2Button.colors;
            level2ButtonColor.normalColor = white;
            level2Button.colors           = level2ButtonColor;
            level2Button.interactable     = true;
            level2Text.SetActive(false);

        }
    }
    public void PressedUnlockBulbButton()
    {
        if (playerData.unlockedBulbDef == 1)
        {
            unlockedBulbDefText.text     = "Already Unlocked";
            unlockedBulbDefText.fontSize = 4;
            var unlockedBulbDefColor = unlockBulbButton.colors;
            unlockedBulbDefColor.normalColor = gray;
            unlockBulbButton.colors          = unlockedBulbDefColor;
        }
        if (playerData.metaData >= bulbPrice &&  playerData.unlockedBulbDef == 0)
        {
            select.Play();

            playerData.unlockedBulbDef =  1;
            playerData.metaData        -= bulbPrice;
            metaDataSystem.SetMetaData(playerData.metaData);
            metaDataSystem.SetUnlockedBulb(playerData.unlockedBulbDef);
            unlockedBulbDefText.text     = "Unlocked";
            unlockedBulbDefText.fontSize = 8;
            var unlockedBulbDefColor = unlockBulbButton.colors;
            unlockedBulbDefColor.normalColor = gray;
            unlockBulbButton.colors          = unlockedBulbDefColor;
            RefreshPriceTexts();
            PlayerPrefs.Save();


        }
        
        if (playerData.metaData < bulbPrice && playerData.unlockedBulbDef == 0)
        {
            unlockedBulbDefText.fontSize = 3.5f;
            unlockedBulbDefText.text     = "Not enough money";
            var unlockedBulbDefColor = unlockBulbButton.colors;
            unlockedBulbDefColor.normalColor = gray;
            unlockBulbButton.colors          = unlockedBulbDefColor;
        }
    }

    public void PressedUnlockCameraButton()
    {
        if (playerData.unlockedCameraDef == 1)
        {
            unlockedCameraDefText.text     = "Already Unlocked";
            unlockedCameraDefText.fontSize = 4;
            var unlockedCameraDefColor = unlockCameraButton.colors;
            unlockedCameraDefColor.normalColor = gray;
            unlockCameraButton.colors          = unlockedCameraDefColor;
        }
        if (playerData.metaData >= cameraPrice &&  playerData.unlockedCameraDef == 0)
        {
            select.Play();

            playerData.unlockedCameraDef =  1;
            playerData.metaData          -= cameraPrice;
            metaDataSystem.SetMetaData(playerData.metaData);
            metaDataSystem.SetUnlockedCamera(playerData.unlockedCameraDef);
            unlockedCameraDefText.text     = "Unlocked";
            unlockedCameraDefText.fontSize = 8;
            var unlockedCameraDefColor = unlockCameraButton.colors;
            unlockedCameraDefColor.normalColor = gray;
            unlockCameraButton.colors          = unlockedCameraDefColor;
            RefreshPriceTexts();
            PlayerPrefs.Save();

        }
        
        if (playerData.metaData < cameraPrice && playerData.unlockedCameraDef == 0)
        {
            unlockedCameraDefText.fontSize = 3.5f;
            unlockedCameraDefText.text     = "Not enough money";
            var unlockedCameraDefColor = unlockCameraButton.colors;
            unlockedCameraDefColor.normalColor = gray;
            unlockCameraButton.colors          = unlockedCameraDefColor;
        }
    }

    public void PressedUnlockGlowstickButton()
    {
        if (playerData.unlockedGlowstickDef == 1)
        {
            unlockedGlowstickDefText.text     = "Already Unlocked";
            unlockedGlowstickDefText.fontSize = 4;
            var unlockedGlowstickDefColor = unlockGlowstickButton.colors;
            unlockedGlowstickDefColor.normalColor = gray;
            unlockGlowstickButton.colors          = unlockedGlowstickDefColor;
        }

        if (playerData.metaData >= glowstickPrice && playerData.unlockedGlowstickDef == 0)
        {
            select.Play();

            playerData.unlockedGlowstickDef =  1;
            playerData.metaData             -= glowstickPrice;
            metaDataSystem.SetMetaData(playerData.metaData);
            metaDataSystem.SetUnlockedGlowstick(playerData.unlockedGlowstickDef);
            unlockedGlowstickDefText.text     = "Unlocked";
            unlockedGlowstickDefText.fontSize = 8;
            var unlockedGlowstickDefColor = unlockGlowstickButton.colors;
            unlockedGlowstickDefColor.normalColor = gray;
            unlockGlowstickButton.colors          = unlockedGlowstickDefColor;
            RefreshPriceTexts();
            PlayerPrefs.Save();

        }

        if (playerData.metaData < glowstickPrice && playerData.unlockedGlowstickDef == 0)
        {
            unlockedGlowstickDefText.fontSize = 3.5f;
            unlockedGlowstickDefText.text     = "Not enough money";
            var unlockedGlowstickDefColor = unlockGlowstickButton.colors;
            unlockedGlowstickDefColor.normalColor = gray;
            unlockGlowstickButton.colors          = unlockedGlowstickDefColor;
        }
    }

    void RefreshUnlockButtons()
    {
        if (playerData.unlockedGlowstickDef == 1)
        {
            unlockedGlowstickDefText.fontSize = 20;
            unlockedGlowstickDefText.text     = "Unlocked";
            unlockedGlowstickDefText.fontSize = 8;
            var unlockedGlowstickDefColor = unlockGlowstickButton.colors;
            unlockedGlowstickDefColor.normalColor = gray;
            unlockGlowstickButton.colors          = unlockedGlowstickDefColor;  
        }
        else
        {
            unlockedGlowstickDefText.fontSize = 8;
            unlockedGlowstickDefText.text     = "Unlock";
            var unlockedGlowstickDefColor = unlockGlowstickButton.colors;
            unlockedGlowstickDefColor.normalColor = white;
            unlockGlowstickButton.colors          = unlockedGlowstickDefColor;  
        }

        if (playerData.unlockedCameraDef == 1)
        {
            unlockedCameraDefText.fontSize = 8;
            unlockedCameraDefText.text     = "Unlocked";
            var unlockedCameraDefColor = unlockCameraButton.colors;
            unlockedCameraDefColor.normalColor = gray;
            unlockCameraButton.colors          = unlockedCameraDefColor;
        }
        else
        {
            unlockedCameraDefText.text     = "Unlock";
            unlockedCameraDefText.fontSize = 8;
            var unlockedCameraDefColor = unlockCameraButton.colors;
            unlockedCameraDefColor.normalColor = white;
            unlockCameraButton.colors          = unlockedCameraDefColor;
        }

        if (playerData.unlockedBulbDef == 1)
        {
            unlockedBulbDefText.fontSize = 8;
            unlockedBulbDefText.text       = "Unlocked";
            var unlockedBulbDefColor = unlockBulbButton.colors;
            unlockedBulbDefColor.normalColor = gray;
            unlockBulbButton.colors          = unlockedBulbDefColor; 
        }
        else
        {
            unlockedBulbDefText.fontSize = 8;
            unlockedBulbDefText.text     = "Unlock";
            var unlockedBulbDefColor = unlockBulbButton.colors;
            unlockedBulbDefColor.normalColor = white;
            unlockBulbButton.colors          = unlockedBulbDefColor; 
        }
    }

    void RefreshPriceTexts()
    {
        bulbPriceText.text = ""+bulbPrice;
        cameraPriceText.text = ""+cameraPrice;
        glowstickPriceText.text = ""+glowstickPrice;
        playerMoneyText.text = "Player's orbs : " + playerData.metaData;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
