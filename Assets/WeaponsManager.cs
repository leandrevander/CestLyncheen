using System.Collections;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class WeaponsManager : MonoBehaviour
{
    public GameObject   ampoule;
    public Bulb         ampouleScript;
    public GameObject   recupAmpoule;
    public int          nombreAmpoule = 0;
    public GameObject   AppareillePhoto;
    public int          nombreAppareillePhoto = 0;
    public GameObject   RecupAppareillePhoto;
    
    
    public float        freezeDuration = 2f;
    public NavMeshAgent ennemi_NavMesh;
    public bool         GlowStickRecup = false;
    public GameObject   prefabGlowStick;
    public Coroutine    GlowStickCoroutine;
    public int          numberOfGlowStick = 0;
    public StreetLamp   glowStickScript;
    public UpgradeMenu  upgradeMenu;
    public bool         haveCamera = false;
    public GameObject   glowStickDestroy;
    public GameObject   glowStickDestroy2;
    public GameObject   glowStickDestroy3;
    public int          hitpoint          = 1;
    public int          hitByBulb         = 1;
    public int          hitByLighthouse   = 1;
    public float        GlowStickDuration = 10f;
    public GameObject   cameraDescription;
    public GameObject   bulbDescription;
    public GameObject   glowStickDescription;
    
    
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
       if  (nombreAmpoule > 1)
       {
          
           nombreAmpoule += 1;
           Debug.Log("Vous avez " + nombreAmpoule + " ampoules.");
          
       }
       else if  (nombreAmpoule == 0)
       {
           ampoule.SetActive(true);
           nombreAmpoule += 1;
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
       if (GlowStickRecup == true && GlowStickCoroutine == null && (numberOfGlowStick == 0) && upgradeMenu.levelupgrade4 == 1)
       {
           GlowStickCoroutine = StartCoroutine(GlowStickSpwanlvl1());
       }
       else if (GlowStickRecup == true && GlowStickCoroutine == null && (numberOfGlowStick == 0 ) && (upgradeMenu.levelupgrade4 == 2 || upgradeMenu.levelupgrade4 == 3))
       {             GlowStickCoroutine = StartCoroutine(GlowStickSpwanlvl2());
       }
       else if (GlowStickRecup == true && GlowStickCoroutine == null && (numberOfGlowStick == 0) && upgradeMenu.levelupgrade4 >= 4)
       {
           GlowStickCoroutine = StartCoroutine(GlowStickSpwanlvl4());
       }
       recupAmpoule = GameObject.FindGameObjectWithTag("RecupAmpoule");
       RecupAppareillePhoto = GameObject.FindGameObjectWithTag("RecupAppareilPhoto");
   }


}




