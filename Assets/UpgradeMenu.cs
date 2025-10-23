using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UpgradeMenu : MonoBehaviour
{
    public TMP_Text Upgrade1;
    public TMP_Text Upgrade2;
    public TMP_Text Upgrade3;
    public Experience experience;
    public GameObject upgradeMenu;
    public Button upgrade1button;
    public Button upgrade2button;
    public Button upgrade3button;
    public TMP_Text LevelUpgrade1;
    public TMP_Text LevelUpgrade2;
    public TMP_Text LevelUpgrade3;
    public int levelupgrade1 = 1;
    public int levelupgrade2 = 1;
    public int levelupgrade3 = 1;
    public int randomUpgradeCase1;
    public int randomUpgradeCase2;
    public int randomUpgradeCase3;
    public GameObject [] mesUpgrades;
    public Vector2 emplacement1;
    public Vector2 emplacement2;
    public Vector2 emplacement3;
    public GameObject Case1;
    public GameObject Case2;
    public GameObject Case3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      emplacement1 = Case1.transform.position;
      emplacement2 = Case2.transform.position;
      emplacement3 = Case3.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       


    }
    public void UpgradeMenuOpen()
    { upgradeMenu.SetActive(true);
        Time.timeScale = 0f;
        
                {
            randomUpgradeCase1 = Random.Range(0, mesUpgrades.Length);
            Instantiate(mesUpgrades[randomUpgradeCase1], emplacement1, Quaternion.identity, upgradeMenu.transform);
            randomUpgradeCase2 = Random.Range(0, mesUpgrades.Length);
            Instantiate(mesUpgrades[randomUpgradeCase2], emplacement2, Quaternion.identity, upgradeMenu.transform);
            randomUpgradeCase3 = Random.Range(0, mesUpgrades.Length);
            Instantiate(mesUpgrades[randomUpgradeCase3], emplacement3, Quaternion.identity, upgradeMenu.transform);
        }


        Debug.Log(mesUpgrades[randomUpgradeCase1]);
        Debug.Log(mesUpgrades[randomUpgradeCase2]);
        Debug.Log(mesUpgrades[randomUpgradeCase3]);
    }
    public void UpgradeMenuClose()
    { upgradeMenu.SetActive(false);
        Time.timeScale = 1f;

    }
    public void Upgrade1Seclect()
    {
        if (levelupgrade1 >= 3)
        {
            
            LevelUpgrade1.text = "Max Level";
            upgrade1button.interactable = false;

        }
        else
        {
            
            levelupgrade1++;
            LevelUpgrade1.text = "Level " + levelupgrade1;
            UpgradeMenuClose();
        }
    }
    public void Upgrade2Seclect()
    {
        if (levelupgrade2 >= 3)
        {
            LevelUpgrade2.text = "Max Level";
            upgrade2button.interactable = false;
        }
        else
        {
            levelupgrade2++;
            LevelUpgrade2.text = "Level " + levelupgrade2;
            UpgradeMenuClose();
        }
    }
    public void Upgrade3Seclect()
    {
        if (levelupgrade3 >= 3)
        {
            LevelUpgrade3.text = "Max Level";
            upgrade3button.interactable = false;
        }
        else
        {
            levelupgrade3++;
            LevelUpgrade3.text = "Level " + levelupgrade3;
            UpgradeMenuClose();
        }
    }
    
}
