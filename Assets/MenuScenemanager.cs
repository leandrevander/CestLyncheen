using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuScenemanager : MonoBehaviour
{
    public GameObject play;
    public GameObject level1;
    public GameObject unlockBulbButtonGO;
    public GameObject unlockMenuButtonGO;
    

    public GameObject mainMenuPage;
    public GameObject upgradePage;
    public GameObject playPage;
    


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
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }
    
    public void StartLevel2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    }
    
    public void StartLEANDRE3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LEANDRE3");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void PressedPlayButton()
    {
        mainMenuPage.SetActive(false);
        playPage.SetActive(true);
        upgradePage.SetActive(false);
        eventSystem.SetSelectedGameObject(level1);
    }

    public void PressedReturnButton()
    {
        mainMenuPage.SetActive(true);
        playPage.SetActive(false);
        upgradePage.SetActive(false);
        eventSystem.SetSelectedGameObject(play);
    }
    
    public void PressedReturnButtonFromUpgradeMenu()
    {
        mainMenuPage.SetActive(true);
        playPage.SetActive(false);
        upgradePage.SetActive(false);
        eventSystem.SetSelectedGameObject(unlockMenuButtonGO);
    }

    public void PressedUnlockMenuButton()
    {
        mainMenuPage.SetActive(false);
        playPage.SetActive(false);
        upgradePage.SetActive(true);
        eventSystem.SetSelectedGameObject(unlockBulbButtonGO);
        RefreshUnlockButtons();
        RefreshPriceTexts();


    }
    
    
    public void PressedUnlockBulbButton()
    {
        if (playerData.unlockedBulbDef == 1)
        {
            unlockedBulbDefText.text     = "Already Unlocked";
            unlockedBulbDefText.fontSize = 20;
            var unlockedBulbDefColor = unlockBulbButton.colors;
            unlockedBulbDefColor.normalColor = gray;
            unlockBulbButton.colors          = unlockedBulbDefColor;
        }
        if (playerData.metaData >= bulbPrice &&  playerData.unlockedBulbDef == 0)
        {
            playerData.unlockedBulbDef =  1;
            playerData.metaData        -= bulbPrice;
            metaDataSystem.SetMetaData(playerData.metaData);
            metaDataSystem.SetUnlockedBulb(playerData.unlockedBulbDef);
            unlockedBulbDefText.text   =  "Unlocked";
            var unlockedBulbDefColor = unlockBulbButton.colors;
            unlockedBulbDefColor.normalColor = gray;
            unlockBulbButton.colors          = unlockedBulbDefColor;
            RefreshPriceTexts();

        }
        
        if (playerData.metaData < bulbPrice && playerData.unlockedBulbDef == 0)
        {
            unlockedBulbDefText.fontSize = 18;
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
            unlockedCameraDefText.fontSize = 20;
            var unlockedCameraDefColor = unlockCameraButton.colors;
            unlockedCameraDefColor.normalColor = gray;
            unlockCameraButton.colors          = unlockedCameraDefColor;
        }
        if (playerData.metaData >= cameraPrice &&  playerData.unlockedCameraDef == 0)
        {
            playerData.unlockedCameraDef =  1;
            playerData.metaData          -= cameraPrice;
            metaDataSystem.SetMetaData(playerData.metaData);
            metaDataSystem.SetUnlockedCamera(playerData.unlockedCameraDef);
            unlockedCameraDefText.text     =  "Unlocked";
            var unlockedCameraDefColor = unlockCameraButton.colors;
            unlockedCameraDefColor.normalColor = gray;
            unlockCameraButton.colors          = unlockedCameraDefColor;
            RefreshPriceTexts();
        }
        
        if (playerData.metaData < cameraPrice && playerData.unlockedCameraDef == 0)
        {
            unlockedCameraDefText.fontSize = 18;
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
            unlockedGlowstickDefText.fontSize = 20;
            var unlockedGlowstickDefColor = unlockGlowstickButton.colors;
            unlockedGlowstickDefColor.normalColor = gray;
            unlockGlowstickButton.colors          = unlockedGlowstickDefColor;
        }

        if (playerData.metaData >= glowstickPrice && playerData.unlockedGlowstickDef == 0)
        {
            playerData.unlockedGlowstickDef =  1;
            playerData.metaData             -= glowstickPrice;
            metaDataSystem.SetMetaData(playerData.metaData);
            metaDataSystem.SetUnlockedGlowstick(playerData.unlockedGlowstickDef);
            unlockedGlowstickDefText.text = "Unlocked";
            var unlockedGlowstickDefColor = unlockGlowstickButton.colors;
            unlockedGlowstickDefColor.normalColor = gray;
            unlockGlowstickButton.colors          = unlockedGlowstickDefColor;
            RefreshPriceTexts();
        }

        if (playerData.metaData < glowstickPrice && playerData.unlockedGlowstickDef == 0)
        {
            unlockedGlowstickDefText.fontSize = 18;
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
            unlockedGlowstickDefText.fontSize  = 20;
            unlockedGlowstickDefText.text = "Unlocked";
            var unlockedGlowstickDefColor = unlockGlowstickButton.colors;
            unlockedGlowstickDefColor.normalColor = gray;
            unlockGlowstickButton.colors          = unlockedGlowstickDefColor;  
        }
        else
        {
            unlockedGlowstickDefText.fontSize = 20;
            unlockedGlowstickDefText.text     = "Unlock";
            var unlockedGlowstickDefColor = unlockGlowstickButton.colors;
            unlockedGlowstickDefColor.normalColor = white;
            unlockGlowstickButton.colors          = unlockedGlowstickDefColor;  
        }

        if (playerData.unlockedCameraDef == 1)
        {
            unlockedCameraDefText.fontSize = 20;
            unlockedCameraDefText.text     = "Unlocked";
            var unlockedCameraDefColor = unlockCameraButton.colors;
            unlockedCameraDefColor.normalColor = gray;
            unlockCameraButton.colors          = unlockedCameraDefColor;
        }
        else
        {
            unlockedCameraDefText.text     = "Unlock";
            unlockedCameraDefText.fontSize = 20;
            var unlockedCameraDefColor = unlockCameraButton.colors;
            unlockedCameraDefColor.normalColor = white;
            unlockCameraButton.colors          = unlockedCameraDefColor;
        }

        if (playerData.unlockedBulbDef == 1)
        {
            unlockedBulbDefText.fontSize = 20;
            unlockedBulbDefText.text       = "Unlocked";
            var unlockedBulbDefColor = unlockBulbButton.colors;
            unlockedBulbDefColor.normalColor = gray;
            unlockBulbButton.colors          = unlockedBulbDefColor; 
        }
        else
        {
            unlockedBulbDefText.fontSize = 20;
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
