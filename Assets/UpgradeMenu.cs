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
    
    [Header("Script")]
   public PlayerControl         playerControl;
   public float                 Multiplier = 1.1f;
   public WeaponsManager        weaponsManager;
   public EnemyHealthManagement enemyHealthManagement;
   public Experience            experience;
   
   
   
   
   
   [Header("Menu")]
   [SerializeField] AudioSource    select ;
   public int        randomUpgradeCase1;
   public int randomUpgradeCase2;
   public int randomUpgradeCase3;
   public GameObject       Case1;
   public GameObject       Case2;
   public GameObject       Case3;
   public GameObject       upgradeMenu;
   public List<GameObject> mesUpgradesList = new List<GameObject>();
   public TMP_Text         Upgrade1;
   public TMP_Text         Upgrade2;
   public TMP_Text         Upgrade3;
   public Vector2          emplacement1;
   public Vector2          emplacement2;
   public Vector2          emplacement3;
   
  
   
   
   
   
   
   [Header("Speed")]
   public Button                upgrade1button;
   public int        levelupgrade1 = 0;
   public GameObject speedUpgrade;
   public TMP_Text   LevelUpgrade1;
   public TMP_Text   describleTextUpgrade1;
   
   
   
   
   [Header("Bulb")]
   public Button   upgrade2button;
   public Bulb       bulbScript;
   public int        levelupgrade2 = 0;
   public GameObject bulbUpgrade;
   public Light2D    bulb;
   public TMP_Text   LevelUpgrade2;
   public TMP_Text   describleTextUpgrade2;
    public bool              bulbMaxed = false;
   
   [Header("Camera")]
   public int                   levelupgrade3 = 0;
   public Button        upgrade3button;
   public CameraUpgrade cameraUpgradeScript;
   public GameObject    cameraUpgrade;
   public TMP_Text      describleTextUpgrade3;
   public TMP_Text      LevelUpgrade3;
   public bool cameraMaxed = false;
   
   
   [Header("GlowStick")]
   
   public int      levelupgrade4 = 0;
   public Button     upgrade4button;
   public GameObject glowstickupgrade;
   public TMP_Text   describleTextUpgrade4;
   public TMP_Text   LevelUpgrade4;
   public bool glowstickMaxed = false;
   
   
   
    [Header("Flashlight")]
    public                   int               levelupgrade5 = 0;
    public  Button        upgrade5Button;
    private DetectorLight detectorLight;
    public  GameObject    flashlightUpgradeObject;
    public  Light2D       flashlightLight;
    public  TMP_Text      levelUpgrade5Name;
    public                   TMP_Text          describeLevel5;
    public                   PolygonCollider2D flashlightCollider;
    [SerializeField] private Vector2[]         flashlightCollider2DArray;
    
    
    [Header("UI")]
    public EventSystem eventSystem;
    private GameObject firstButtonInUpgradeMenu;
    public  GameObject upgradeCase1;
    public  GameObject upgradeCase2;
    public  GameObject upgradeCase3;
    public  GameObject closeButtonUpgradeMenu;
    
    
    
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Start()
   {
       closeButtonUpgradeMenu.SetActive(false);
       mesUpgradesList.Add(speedUpgrade);
       mesUpgradesList.Add(flashlightUpgradeObject);
       emplacement1       = Case1.transform.position;
       emplacement2       = Case2.transform.position;
       emplacement3       = Case3.transform.position;
       LevelUpgrade1.text = "Level : " + (levelupgrade1 +1);
       LevelUpgrade2.text = "Level : " + (levelupgrade2 +1);
       LevelUpgrade3.text = "Level : " + (levelupgrade3 +1);
       LevelUpgrade4.text = "Level : " + (levelupgrade4 +1);
   }


   // Update is called once per frame
   void Update()
   {
       if (Input.GetKeyDown(KeyCode.JoystickButton1))
       {
           UpgradeMenuClose();
       }


       if (weaponsManager.haveCamera == true && !mesUpgradesList.Contains(cameraUpgrade) && (cameraMaxed == false))
       {
           mesUpgradesList.Add(cameraUpgrade);
       }


       if ((weaponsManager.nombreAmpoule) > 0&& !mesUpgradesList.Contains(bulbUpgrade) && (bulbMaxed == false))
       {
           mesUpgradesList.Add(bulbUpgrade);
       }


       if (weaponsManager.GlowStickRecup == true&& !mesUpgradesList.Contains(glowstickupgrade)&& (glowstickMaxed == false))
       {
           mesUpgradesList.Add(glowstickupgrade);
       }
     


   }
   public void UpgradeMenuOpen()
   {
       closeButtonUpgradeMenu.SetActive(true);
       upgradeMenu.SetActive(true);
       Time.timeScale = 0f;


       {
           randomUpgradeCase1 = Random.Range(0, mesUpgradesList.Count);
           upgradeCase1       = Instantiate(mesUpgradesList[randomUpgradeCase1], emplacement1, Quaternion.identity, upgradeMenu.transform);
           randomUpgradeCase2 = Random.Range(0, mesUpgradesList.Count);
           upgradeCase2       = Instantiate(mesUpgradesList[randomUpgradeCase2], emplacement2, Quaternion.identity, upgradeMenu.transform);
           randomUpgradeCase3 = Random.Range(0, mesUpgradesList.Count);
           upgradeCase3       = Instantiate(mesUpgradesList[randomUpgradeCase3], emplacement3, Quaternion.identity, upgradeMenu.transform);
       }
       firstButtonInUpgradeMenu = upgradeCase1.transform.GetChild(0).gameObject;
       eventSystem.SetSelectedGameObject(firstButtonInUpgradeMenu);
       
       speedUpgrade.SetActive(false);
       bulbUpgrade.SetActive(false);
       cameraUpgrade.SetActive(false);
       glowstickupgrade.SetActive(false);
       flashlightUpgradeObject.SetActive(false);
       




       Debug.Log(mesUpgradesList[randomUpgradeCase1]);
       Debug.Log(mesUpgradesList[randomUpgradeCase2]);
       Debug.Log(mesUpgradesList[randomUpgradeCase3]);
   }
   public void UpgradeMenuClose()
   {
       select.Play();

       closeButtonUpgradeMenu.SetActive(false);
       upgradeMenu.SetActive(false);
       Time.timeScale = 1f;
       
       Destroy(upgradeCase1);
       Destroy(upgradeCase2);
       Destroy(upgradeCase3);
       
       speedUpgrade.SetActive(true);
       bulbUpgrade.SetActive(true);
       cameraUpgrade.SetActive(true);
       glowstickupgrade.SetActive(true);
       flashlightUpgradeObject.SetActive(true);
      
      


   }
  


   public void SpeedUpgrade()
   {
       levelupgrade1++;


       if (levelupgrade1 == 0)
       {
           playerControl.moveSpeed = Mathf.RoundToInt(playerControl.moveSpeed * Multiplier);
           LevelUpgrade1.text      = ("Level : 1");
           UpgradeMenuClose();  
       }
       
       else if (levelupgrade1 == 1)
       {
           
           playerControl.moveSpeed = Mathf.RoundToInt(playerControl.moveSpeed * Multiplier);
           LevelUpgrade1.text      = ("Level : 2");
           UpgradeMenuClose();  
       }
       
       else if (levelupgrade1 == 2)
       {
           playerControl.moveSpeed = Mathf.RoundToInt(playerControl.moveSpeed * Multiplier);
           LevelUpgrade1.text      = ("Level : 3");
           UpgradeMenuClose();  
       }
       
       else if (levelupgrade1 == 3)
       {
           playerControl.moveSpeed = Mathf.RoundToInt(playerControl.moveSpeed * Multiplier);
           LevelUpgrade1.text      = ("Final Level");
           UpgradeMenuClose();  
       }
       
       else if (levelupgrade1 == 4)
       {
           playerControl.moveSpeed = Mathf.RoundToInt(playerControl.moveSpeed * Multiplier);
           LevelUpgrade1.text      = ("Level Max");
           mesUpgradesList.Remove(speedUpgrade);

           UpgradeMenuClose();  
       }
       
   }

   
   
   
   public void BulbUpgrade()
   {
       if ((levelupgrade2 == 0 && (weaponsManager.nombreAmpoule) > 0))
       {
           select.Play();
           levelupgrade2++;
           describleTextUpgrade2.text = "Increase Bulb's damages to your enemies.";
           weaponsManager.hitByBulb   = 20;
           LevelUpgrade2.text         = "Level : 2";
           UpgradeMenuClose();
       }
       else if ((levelupgrade2 == 1) && (weaponsManager.nombreAmpoule > 0))
       {
           select.Play();
           levelupgrade2++;
           describleTextUpgrade2.text = "Increase Bulb's damages to your enemies.";
           LevelUpgrade2.text         = "Level : 3";
           bulbScript.BulbLevel3();
           UpgradeMenuClose();
       }
       else if ((levelupgrade2 == 2) && (weaponsManager.nombreAmpoule > 0))
       {
           select.Play();
           levelupgrade2++;
           describleTextUpgrade2.text = "Increase Bulb's range.";
           weaponsManager.hitByBulb   = 30;
           LevelUpgrade2.text         = "Final Level";
           UpgradeMenuClose();
       }
       else if ((levelupgrade2 == 3) && (weaponsManager.nombreAmpoule > 0))
       {
           select.Play();
           levelupgrade2++;
           describleTextUpgrade2.text = "Max Level";
           bulbScript.BulbLevel5();
           LevelUpgrade2.text = "Level :" + levelupgrade2;
           bulbMaxed          = true;
           mesUpgradesList.Remove(bulbUpgrade);
           UpgradeMenuClose();
       }
       else if ((levelupgrade2 == 4) && (weaponsManager.nombreAmpoule > 0))
       {
           //LevelUpgrade2.text          = "Max Level";
           upgrade2button.interactable = false;
           UpgradeMenuClose();
       }
   }










   public void FlashlightUpgrade()
   {
       if (levelupgrade5 == 0)
       {
           select.Play();
           levelupgrade5++;
           describeLevel5.text            = "Increase Flashlight's damages to your enemies.";
           levelUpgrade5Name.text         = "Level : 2";
           weaponsManager.hitByFlashlight = 20;
           Debug.Log("hit dgt 2");

           UpgradeMenuClose();
       }
       else if (levelupgrade5 == 1)
       {
           select.Play();
           levelupgrade5++;
           describeLevel5.text            = "Increase Flashlight's range.";
         
           levelUpgrade5Name.text         = "Level : 3";
           
           weaponsManager.hitByFlashlight = 25;
           Debug.Log("hit degat 3");


           UpgradeMenuClose();
       }
       else if (levelupgrade5 == 2)
       {
           select.Play();
           levelupgrade5++;
           describeLevel5.text                   = "Increase Flashlight's damages to your enemies.";
           levelUpgrade5Name.text                = "Level : 4";
           flashlightLight.pointLightOuterRadius = 13;
           flashlightLight.falloffIntensity      = 0.3f;
           flashlightCollider.SetPath(0, flashlightCollider2DArray);
           Debug.Log("portée augmentée" );


           
           UpgradeMenuClose();

           
       }
       else if (levelupgrade5 == 3)
       {
           select.Play();
           describeLevel5.text            = "Increase Flashlight's damages to your enemies.";
           levelUpgrade5Name.text         = "Level : 5";
           weaponsManager.hitByFlashlight = 30;
           Debug.Log("hit dgt 4");
           levelupgrade5++;
           UpgradeMenuClose();
       }
       else if (levelupgrade5 == 4)
       {
           select.Play();
           levelupgrade5++;
           describeLevel5.text            = "Increase Flashlight's damages to your enemies.";
           levelUpgrade5Name.text         = "Level : 6";
           weaponsManager.hitByFlashlight = 35;
           Debug.Log("hit dgt 5");

           UpgradeMenuClose();
       }
       else if  (levelupgrade5 == 5)
       {
           select.Play();
           levelupgrade5++;
           describeLevel5.text            = "Increase Flashlight's damages to your enemies.";
           levelUpgrade5Name.text         = "Level : 7";
           weaponsManager.hitByFlashlight = 40;
           Debug.Log("hit dgt 6");

           UpgradeMenuClose();
       }
       else if (levelupgrade5 == 6)
       {
           select.Play();
           levelupgrade5++;
            describeLevel5.text           = "Level Max.";
           levelUpgrade5Name.text         = "Level : 8";
           weaponsManager.hitByFlashlight = 50;
           upgrade5Button.interactable    = false;
           mesUpgradesList.Remove(flashlightUpgradeObject);
           Debug.Log("hit dgt 6");
           UpgradeMenuClose();
       }
      
   }


















   public void CameraUpgrade()
   {
       if ((levelupgrade3 == 0 && (weaponsManager.haveCamera == true)))
       {
           select.Play();
           levelupgrade3++;
           LevelUpgrade3.text = "Level : 2";
           describleTextUpgrade3.text = "Increase stun's duration.";
           
           cameraUpgradeScript.CameraLevel1();
          
           UpgradeMenuClose();


       }
       else if ((levelupgrade3 == 1) && (weaponsManager.haveCamera == true))
       {
           select.Play();
           levelupgrade3++;
           describleTextUpgrade3.text = "Increase Camera's range.";
           weaponsManager.freezeDuration = 3f;
           LevelUpgrade3.text = "Level : 3";
           // augmente la dur�e du Stun
           
          
          
           UpgradeMenuClose();
       }
       else if ((levelupgrade3 == 2) && (weaponsManager.haveCamera == true))
       {
           select.Play();
           levelupgrade3++;
           describleTextUpgrade3.text = "Increase stun's duration.";
           LevelUpgrade3.text = "Final Level";
           cameraUpgradeScript.CameraLevel3();
         
           UpgradeMenuClose();
       }
       else if ((levelupgrade3 == 3) && (weaponsManager.haveCamera == true))
       {
           select.Play();
           levelupgrade3++;
           describleTextUpgrade3.text    = "Max Level";
           LevelUpgrade3.text            = "Level :" + levelupgrade3;
           weaponsManager.freezeDuration = 4f; // augmente la dur�e du Stun
           cameraMaxed                   = true;
           mesUpgradesList.Remove(cameraUpgrade);

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
           levelupgrade4++;
           describleTextUpgrade4.text = "Increase Glowstick's duration.";
           LevelUpgrade4.text = "Level : 2";
           
           UpgradeMenuClose();
       }
       else if ((levelupgrade4 == 1) && (weaponsManager.GlowStickRecup == true))
       {
           levelupgrade4++;
           describleTextUpgrade4.text = "Place 3 GlowSticks instead of 2.";
           weaponsManager.GlowStickDuration = 12.5f;// augmente la dur�e des glowstick
           LevelUpgrade4.text = "Level : 3";
           
           UpgradeMenuClose();
       }
       else if ((levelupgrade4 == 2) && (weaponsManager.GlowStickRecup == true))
       {
           levelupgrade4++;
           describleTextUpgrade4.text = "Increase Glowstick's duration.";
           // d�pose 3 glowstick au lieu de 1
           LevelUpgrade4.text = "Level : 4";
           
           UpgradeMenuClose();
       }
       else if ((levelupgrade4 == 3) && (weaponsManager.GlowStickRecup == true))
       {
           levelupgrade4++;
           describleTextUpgrade4.text = "Increase Glowstick's damage.";
           weaponsManager.GlowStickDuration = 15f; // augmente la durée des glowstick
           LevelUpgrade4.text = "Final Level";
           
           UpgradeMenuClose();
       }
       else if ((levelupgrade4 == 4) && (weaponsManager.GlowStickRecup == true))
       {
           levelupgrade4++;
           describleTextUpgrade4.text = "Max Level";
           weaponsManager.hitpoint    = 40; // augmente les dégats des glowstick
           LevelUpgrade4.text         = "Level Max";
           glowstickMaxed                = true;
           mesUpgradesList.Remove(glowstickupgrade);
           
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
