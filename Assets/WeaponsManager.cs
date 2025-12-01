using System.Collections;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class WeaponsManager : MonoBehaviour
{
    public NavMeshAgent ennemi_NavMesh;
    public UpgradeMenu  upgradeMenu;
    public PlayerData playerData;
    public int          hitByLighthouse   = 1;
    
    [Header("Bulb")]
    
    public int        nombreAmpoule = 0;
    public int        hitByBulb     = 1;
    public GameObject bulbDescription;
    public GameObject ampoule;
    public GameObject recupAmpoule;
    public Bulb       ampouleScript;
    
    
    [Header("Camera")]
    
    
    public int        nombreAppareillePhoto = 0;
    public float      freezeDuration = 2f;
    public bool       haveCamera     = false;
    public GameObject cameraDescription;
    public GameObject AppareillePhoto;
    public GameObject RecupAppareillePhoto;
    
    [Header("GlowStick")]
    public bool         GlowStickRecup = false;
    public Coroutine  GlowStickCoroutine;
    public int        numberOfGlowStick = 0;
    public int        hitpoint          = 1;
    public float      GlowStickDuration = 10f;
    public GameObject glowStickDescription;
    public GameObject prefabGlowStick;
    public GameObject glowStickDestroy;
    public GameObject glowStickDestroy2;
    public GameObject glowStickDestroy3;
    public StreetLamp glowStickScript;
    
    
    [Header("Flashlight")]
    public int hitByFlashlight = 2;
    
    [Header("UI")]
    public EventSystem eventSystem;
    public GameObject buttonBulbDescription;
    public GameObject buttonCameraDescription;
    public GameObject buttonGlowstickDescription;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Start()
   {
       if (playerData.unlockedBulbDef == 1)
       {
           nombreAmpoule += 1;
           ampoule.SetActive(true); 
       }
       

       if (playerData.unlockedGlowstickDef == 1)
       {
           GlowStickRecup = true;
       }
       

       if (playerData.unlockedCameraDef == 1)
       {
           AppareillePhoto.SetActive(true);
           nombreAppareillePhoto += 1;
           StartCoroutine(Flash());
       }
       
   }

   
   public void AgmentationDuNiveauAppareillePhoto()
   {


       if  (nombreAppareillePhoto >= 1)
       {
          
           nombreAppareillePhoto += 1;
           Debug.Log("Vous avez " + nombreAppareillePhoto + " appareils photos.");
          
       }
       else if  (nombreAppareillePhoto >= 0)
       {
           AppareillePhoto.SetActive(true);
           nombreAppareillePhoto += 1;
           eventSystem.SetSelectedGameObject(buttonCameraDescription);
           Debug.Log("Vous avez d�bloquer l'appareil photo !");
           cameraDescription.SetActive(true);
           Time.timeScale = 0f;
           StartCoroutine(Flash());
       }
   }
   public IEnumerator Flash()
  
       {
           while (nombreAppareillePhoto >= 1)
           {
               Debug.Log("Flash !");
               AppareillePhoto.SetActive(false);
               Debug.Log("L'appareil photo est en recharge...");
               yield return new WaitForSeconds(freezeDuration);
               AppareillePhoto.SetActive(true);
               Debug.Log("Vous pouvez r�utiliser l'appareil photo !");
               yield return new WaitForSeconds(0.1f);
               AppareillePhoto.SetActive(false);
               Debug.Log("Appareille Photo Utilis� !");


           }


       }


   public void UpgradeAmpoule()
   {
       if  (nombreAmpoule >= 1)
       {
          
           nombreAmpoule += 1;
           Debug.Log("Vous avez " + nombreAmpoule + " ampoules.");
          
       }
       else if  (nombreAmpoule == 0)
       {
           ampoule.SetActive(true);
           nombreAmpoule += 1;
           bulbDescription.SetActive(true);
           Time.timeScale = 0f;
           eventSystem.SetSelectedGameObject(buttonBulbDescription);
           Debug.Log("Vous avez d�bloquer l'ampoule !");
          


       }
       
   }

   public void UnlockGlowstick()
   {
       glowStickDescription.SetActive(true);
       eventSystem.SetSelectedGameObject(buttonGlowstickDescription);
       Time.timeScale                = 0f;
       GlowStickRecup = true;
   }
   public IEnumerator GlowStickSpwanlvl1()
   {
       glowStickDestroy = Instantiate(prefabGlowStick, transform.position, transform.rotation);
       numberOfGlowStick += 1;
       Debug.Log("Street Lamp Spawned");
       yield return new WaitForSeconds(GlowStickDuration);
       Debug.Log("Street Lamp fin de la coroutine");
       numberOfGlowStick = 0;
       Debug.Log("Street Lamp -1");
       Destroy(glowStickDestroy);
       Debug.Log("Street Lamp detruit");
       GlowStickCoroutine = null;


   }
   public IEnumerator GlowStickSpwanlvl2()
   {
       glowStickDestroy = Instantiate(prefabGlowStick, transform.position, transform.rotation);
       yield return new WaitForSeconds(1);
       glowStickDestroy2 = Instantiate(prefabGlowStick, transform.position, transform.rotation);
       numberOfGlowStick += 2;
       Debug.Log("Street Lamp Spawned");
       yield return new WaitForSeconds(GlowStickDuration);
       Debug.Log("Street Lamp fin de la coroutine");
       numberOfGlowStick = 0;
       Debug.Log("Street Lamp -1");
       Destroy(glowStickDestroy);
       Destroy(glowStickDestroy2);
       Debug.Log("Street Lamp detruit");
       GlowStickCoroutine = null;


   }
   public IEnumerator GlowStickSpwanlvl4()
   {
       glowStickDestroy = Instantiate(prefabGlowStick, transform.position, transform.rotation);
       yield return new WaitForSeconds(1);
       glowStickDestroy2 = Instantiate(prefabGlowStick, transform.position, transform.rotation);
       yield return new WaitForSeconds(1);
       glowStickDestroy3 = Instantiate(prefabGlowStick, transform.position, transform.rotation);
       numberOfGlowStick += 3;
       Debug.Log("Street Lamp Spawned");
       yield return new WaitForSeconds(GlowStickDuration);
       Debug.Log("Street Lamp fin de la coroutine");
       numberOfGlowStick = 0;
       Debug.Log("Street Lamp -1");
       Destroy(glowStickDestroy);
       Destroy(glowStickDestroy2);
       Destroy(glowStickDestroy3);
       Debug.Log("Street Lamp detruit");
       GlowStickCoroutine = null;


   }




   // Update is called once per frame
   void Update()
   {
       if (GlowStickRecup == true && GlowStickCoroutine == null && (numberOfGlowStick == 0) && upgradeMenu.levelupgrade4 == 0)
       {
           GlowStickCoroutine = StartCoroutine(GlowStickSpwanlvl1());
       }
       else if (GlowStickRecup == true && GlowStickCoroutine == null && (numberOfGlowStick == 0 ) && (upgradeMenu.levelupgrade4 == 1 || upgradeMenu.levelupgrade4 == 2))
       {             GlowStickCoroutine = StartCoroutine(GlowStickSpwanlvl2());
       }
       else if (GlowStickRecup == true && GlowStickCoroutine == null && (numberOfGlowStick == 0) && upgradeMenu.levelupgrade4 >= 3)
       {
           GlowStickCoroutine = StartCoroutine(GlowStickSpwanlvl4());
       }
       recupAmpoule = GameObject.FindGameObjectWithTag("RecupAmpoule");
       RecupAppareillePhoto = GameObject.FindGameObjectWithTag("RecupAppareilPhoto");
   }


}




