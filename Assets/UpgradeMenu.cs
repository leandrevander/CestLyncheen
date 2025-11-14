using System;
using JetBrains.Annotations;
using Player_Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Collections.Generic;


public class UpgradeMenu : MonoBehaviour
{
   public CameraUpgrade cameraUpgradeScript;
   public TMP_Text              Upgrade1;
   public TMP_Text              Upgrade2;
   public TMP_Text              Upgrade3;
   public Experience            experience;
   public GameObject            upgradeMenu;
   public Button                upgrade1button;
   public Button                upgrade2button;
   public Button                upgrade3button;
   public Button                upgrade4button;
   public TMP_Text              LevelUpgrade4;
   public TMP_Text              LevelUpgrade1;
   public TMP_Text              LevelUpgrade2;
   public TMP_Text              LevelUpgrade3;
   public TMP_Text              describleTextUpgrade1;
   public TMP_Text              describleTextUpgrade2;
   public TMP_Text              describleTextUpgrade3;
   public TMP_Text              describleTextUpgrade4;
   public int                   levelupgrade1 = 1;
   public int                   levelupgrade2 = 1;
   public int                   levelupgrade3 = 1;
   public int                   levelupgrade4 = 1;
   public int                   randomUpgradeCase1;
   public int                   randomUpgradeCase2;
   public int                   randomUpgradeCase3;
   public GameObject[]          mesUpgrades;
   public Vector2               emplacement1;
   public Vector2               emplacement2;
   public Vector2               emplacement3;
   public GameObject            Case1;
   public GameObject            Case2;
   public GameObject            Case3;
   public PlayerControl         playerControl;
   public float                 Multiplier = 1.2f;
   public Bulb                  bulbScript;
   public Light2D               bulb;
   public WeaponsManager        weaponsManager;
   public EnemyHealthManagement enemyHealthManagement;
   public List<GameObject>      mesUpgradesList = new List<GameObject>();
   public GameObject            speedUpgrade;
   public GameObject            bulbUpgrade;
   public GameObject            cameraUpgrade;
   public GameObject            glowstickupgrade;
    
    [Header("UI")]
    public EventSystem eventSystem;
    private GameObject firstButtonInUpgradeMenu;
    
    
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Start()
   {
       mesUpgradesList.Add(speedUpgrade);
       emplacement1       = Case1.transform.position;
       emplacement2       = Case2.transform.position;
       emplacement3       = Case3.transform.position;
       LevelUpgrade1.text = "Level " + levelupgrade1;
       LevelUpgrade2.text = "Level " + levelupgrade2;
       LevelUpgrade3.text = "Level " + levelupgrade3;
       LevelUpgrade4.text = "Level " + levelupgrade4;
   }


   // Update is called once per frame
   void Update()
   {
       if (Input.GetKeyDown(KeyCode.Tab))
       {
           UpgradeMenuClose();
       }


       if (weaponsManager.haveCamera == true && !mesUpgradesList.Contains(cameraUpgrade))
       {
           mesUpgradesList.Add(cameraUpgrade);
       }


       if ((weaponsManager.nombreAmpoule) > 0&& !mesUpgradesList.Contains(bulbUpgrade))
       {
           mesUpgradesList.Add(bulbUpgrade);
       }


       if (weaponsManager.GlowStickRecup == true&& !mesUpgradesList.Contains(glowstickupgrade))
       {
           mesUpgradesList.Add(glowstickupgrade);
       }
     


   }
   public void UpgradeMenuOpen()
   {
       upgradeMenu.SetActive(true);
       Time.timeScale = 0f;


       {
           randomUpgradeCase1 = Random.Range(0, mesUpgradesList.Count);
           Instantiate(mesUpgradesList[randomUpgradeCase1], emplacement1, Quaternion.identity, upgradeMenu.transform);
           randomUpgradeCase2 = Random.Range(0, mesUpgradesList.Count);
           Instantiate(mesUpgradesList[randomUpgradeCase2], emplacement2, Quaternion.identity, upgradeMenu.transform);
           randomUpgradeCase3 = Random.Range(0, mesUpgradesList.Count);
           Instantiate(mesUpgradesList[randomUpgradeCase3], emplacement3, Quaternion.identity, upgradeMenu.transform);
       }
       eventSystem.SetSelectedGameObject(firstButtonInUpgradeMenu);




       Debug.Log(mesUpgradesList[randomUpgradeCase1]);
       Debug.Log(mesUpgradesList[randomUpgradeCase2]);
       Debug.Log(mesUpgradesList[randomUpgradeCase3]);
   }
   public void UpgradeMenuClose()
   {
       upgradeMenu.SetActive(false);
       Time.timeScale = 1f;
      
      


   }
  


   public void SpeedUpgrade()
   {
       if (levelupgrade1 >= 4)
       {
           LevelUpgrade1.text = "Max Level";
           upgrade1button.interactable = false;






       }
       else
       {


           levelupgrade1++;
           playerControl.moveSpeed = Mathf.RoundToInt(playerControl.moveSpeed * Multiplier);
           LevelUpgrade1.text = "Level " + levelupgrade1;
           UpgradeMenuClose();
       }
   }
   public void BulbUpgrade()
   {
       if ((levelupgrade2 == 0 && (weaponsManager.nombreAmpoule) > 0))
       {
          
           describleTextUpgrade2.text = "Increase damage to your enemies.";
           levelupgrade2++;
           weaponsManager.hitByBulb = 2;
           LevelUpgrade2.text = "Level :" + levelupgrade2;
           UpgradeMenuClose();
       }
       else if ((levelupgrade2 == 1) && (weaponsManager.nombreAmpoule > 0))
       {
           describleTextUpgrade2.text = "Increase the bulb's range.";
           levelupgrade2++;
           LevelUpgrade2.text = "Level :" + levelupgrade2;
           bulbScript.BulbLevel3();
           UpgradeMenuClose();
       }
       else if ((levelupgrade2 == 2) && (weaponsManager.nombreAmpoule > 0))
       {
           describleTextUpgrade2.text = "Increase damage to your enemies.";
           levelupgrade2++;
           weaponsManager.hitByBulb = 3;
           LevelUpgrade2.text = "Level :" + levelupgrade2;
           UpgradeMenuClose();
       }
       else if ((levelupgrade2 == 3) && (weaponsManager.nombreAmpoule > 0))
       {
           describleTextUpgrade2.text = "Increase the bulb's range.";
           levelupgrade2++;
           bulbScript.BulbLevel5();
           LevelUpgrade2.text = "Level :" + levelupgrade2;
           UpgradeMenuClose();
       }
       else if ((levelupgrade2 == 4) && (weaponsManager.nombreAmpoule > 0))
       {
           LevelUpgrade2.text = "Max Level";
           upgrade2button.interactable = false;
           UpgradeMenuClose();
       }
      
      
   }






























   public void CameraUpgrade()
   {
       if ((levelupgrade3 == 0 && (weaponsManager.haveCamera == true)))
       {
          
           LevelUpgrade3.text = "Level :" + levelupgrade3;
           describleTextUpgrade3.text = "Being the camera's range.";
           levelupgrade3++;
           cameraUpgradeScript.CameraLevel1();
          
           UpgradeMenuClose();


       }
       else if ((levelupgrade3 == 1) && (weaponsManager.haveCamera == true))
       {
           describleTextUpgrade3.text = "Increase the duration of the stun.";
           weaponsManager.freezeDuration = 3f;
           LevelUpgrade3.text = "Level :" + levelupgrade3;
           // augmente la dur�e du Stun
           levelupgrade3++;
          
          
           UpgradeMenuClose();
       }
       else if ((levelupgrade3 == 2) && (weaponsManager.haveCamera == true))
       {
           describleTextUpgrade3.text = "Being the camera's range.";
           LevelUpgrade3.text = "Level :" + levelupgrade3;
           levelupgrade3++;
           cameraUpgradeScript.CameraLevel3();
         
           UpgradeMenuClose();
       }
       else if ((levelupgrade3 == 3) && (weaponsManager.haveCamera == true))
       {
           describleTextUpgrade3.text = "Increase the duration of the stun.";
           LevelUpgrade3.text = "Level :" + levelupgrade3;
           levelupgrade3++;
           weaponsManager.freezeDuration = 4f; // augmente la dur�e du Stun
           UpgradeMenuClose();
       }
       else if ((levelupgrade3 == 4) && (weaponsManager.haveCamera == true))
       {
           LevelUpgrade3.text = "Max Level";
           upgrade3button.interactable = false;
           UpgradeMenuClose();
       }
      
   }


























































   public void GlowStickUpgrade()
   {
       if ((levelupgrade4 == 0 && (weaponsManager.GlowStickRecup == true)))
       {
          
           describleTextUpgrade4.text = "Place 2 GlowSticks instead of 1.";
           LevelUpgrade4.text = "Level :" + levelupgrade4;
           levelupgrade4++;
           UpgradeMenuClose();
       }
       else if ((levelupgrade4 == 1) && (weaponsManager.GlowStickRecup == true))
       {
           describleTextUpgrade4.text = "Increase the duration of the GlowStick.";
           weaponsManager.GlowStickDuration = 12.5f;// augmente la dur�e des glowstick
           LevelUpgrade4.text = "Level :" + levelupgrade4;
           levelupgrade4++;
           UpgradeMenuClose();
       }
       else if ((levelupgrade4 == 2) && (weaponsManager.GlowStickRecup == true))
       {
           describleTextUpgrade4.text = "Place 3 GlowSticks instead of 1.";
           // d�pose 3 glowstick au lieu de 1
           LevelUpgrade4.text = "Level :" + levelupgrade4;
           levelupgrade4++;
           UpgradeMenuClose();
       }
       else if ((levelupgrade4 == 3) && (weaponsManager.GlowStickRecup == true))
       {
           describleTextUpgrade4.text = "Increase the duration of the GlowStick.";
           weaponsManager.GlowStickDuration = 15f; // augmente la dur�e des glowstick
           LevelUpgrade4.text = "Level :" + levelupgrade4;
           levelupgrade4++;
           UpgradeMenuClose();
       }
       else if ((levelupgrade4 == 4) && (weaponsManager.GlowStickRecup == true))
       {
           describleTextUpgrade4.text = "Increase damage of the glowStick.";
           weaponsManager.hitpoint = 2; // augmente les d�gats des glowstick
           LevelUpgrade4.text = "Level :" + levelupgrade4;
           levelupgrade4++;
           UpgradeMenuClose();
       }
       else if ((levelupgrade4 == 5) && (weaponsManager.GlowStickRecup == true))
       {
           LevelUpgrade4.text = "Max Level";
           upgrade4button.interactable = false;
           UpgradeMenuClose();
       }
      
   }
}
