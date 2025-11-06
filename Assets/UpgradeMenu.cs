using System;
using JetBrains.Annotations;
using Player_Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UpgradeMenu : MonoBehaviour
{
    public TMP_Text      Upgrade1;
    public TMP_Text      Upgrade2;
    public TMP_Text      Upgrade3;
    public Experience    experience;
    public GameObject    upgradeMenu;
    public Button        upgrade1button;
    public Button        upgrade2button;
    public Button        upgrade3button;
    public TMP_Text      LevelUpgrade1;
    public TMP_Text      LevelUpgrade2;
    public TMP_Text      LevelUpgrade3;
    public int           levelupgrade1 = 1;
    public int           levelupgrade2 = 1;
    public int           levelupgrade3 = 1;
    public int           randomUpgradeCase1;
    public int           randomUpgradeCase2;
    public int           randomUpgradeCase3;
    public GameObject [] mesUpgrades;
    public Vector2       emplacement1;
    public Vector2       emplacement2;
    public Vector2       emplacement3;
    public GameObject    Case1;
    public GameObject    Case2;
    public GameObject    Case3;
    public PlayerControl playerControl; 
    public float Multiplier = 1.2f;
    public Bulb bulbScript;
    public Light2D bulb;
    public WeaponsManager  weaponsManager;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      emplacement1       = Case1.transform.position;
      emplacement2       = Case2.transform.position;
      emplacement3       = Case3.transform.position;
      LevelUpgrade1.text = "Level " + levelupgrade1;
      LevelUpgrade2.text = "Locked";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UpgradeMenuClose();
        }


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
            playerControl.moveSpeed = Mathf.RoundToInt(playerControl.moveSpeed * Multiplier);
            LevelUpgrade1.text      = "Level " + levelupgrade1;
            UpgradeMenuClose();
        }
    }
    public void Upgrade2Seclect()
    {
        if ((levelupgrade2 == 0 && ( weaponsManager.nombreAmpoule) > 0)) 
        {
            
            levelupgrade2++; 
            
            LevelUpgrade2.text = "Level :" + levelupgrade2;
            UpgradeMenuClose();
            
        }
        else if  ((levelupgrade2 == 1) && (weaponsManager.nombreAmpoule > 0))
        {
            
            levelupgrade2++;
            bulb.GetComponent<CircleCollider2D>() .enabled = false;
            bulb.GetComponent<CircleCollider2D>() .enabled = true;
            LevelUpgrade2.text                             = "Level :" + levelupgrade2;
            bulb.GetComponent<Light2D>(); 
            bulbScript.BulbLevel2();
            UpgradeMenuClose();
        }
        else if ((levelupgrade2 == 2) && ( weaponsManager.nombreAmpoule > 0))
        {
            
            levelupgrade2++;
           
            LevelUpgrade2.text = "Level :" + levelupgrade2;
            UpgradeMenuClose();
        }
        else if  ((levelupgrade2 == 3) && (weaponsManager.nombreAmpoule > 0))
        {
            
            levelupgrade2++;
            bulb.GetComponent<CircleCollider2D>() .enabled = false;
            bulb.GetComponent<CircleCollider2D>() .enabled = true;
            bulbScript.BulbLevel4();
            LevelUpgrade2.text                             = "Max Level";
            upgrade2button.interactable                    = false;
            UpgradeMenuClose();
        }
        else if ((levelupgrade2 == 0 && ( weaponsManager.nombreAmpoule) <= 0)) 
        {
            LevelUpgrade2.text          = "Locked";
            
        }
    }
    public void Upgrade3Seclect()
    {
        
        if (levelupgrade3 >= 4)
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

    void FixedUpdate()
    {
        if (weaponsManager.nombreAmpoule > 0)
        {
            upgrade2button.interactable = true;
            
        }
        else if (weaponsManager.nombreAmpoule == 0)
        {
            upgrade2button.interactable = false;
        }
    }
}
