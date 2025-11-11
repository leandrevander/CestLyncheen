using System.Collections;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WeaponsManager : MonoBehaviour
{
    public GameObject   ampoule;
    public Bulb         ampouleScript;
    public GameObject   recupAmpoule;
    public int          nombreAmpoule = 0;
    public GameObject   AppareillePhoto;
    public int          nombreAppareillePhoto = 0;
    public GameObject   RecupAppareillePhoto;
    public GameObject   PrefabEnnemi;
    public Rigidbody2D  ennemi_Rigidbody2D;
    public float        freezeDuration = 20f;
    public NavMeshAgent ennemi_NavMesh;
    public bool         GlowStickRecup = false;
    public GameObject   prefabGlowStick;
    public Coroutine    GlowStickCoroutine;
    public int          numberOfGlowStick = 0;
    //public StreetLamp   glowStickScript;
    public bool         haveCamera = false;
    public GameObject   glowStickDestroy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ennemi_Rigidbody2D = PrefabEnnemi.GetComponent<Rigidbody2D>();
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
            Debug.Log("Vous avez débloquer l'appareil photo !");
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
                yield return new WaitForSeconds(2);
                AppareillePhoto.SetActive(true);
                Debug.Log("Vous pouvez réutiliser l'appareil photo !");
                yield return new WaitForSeconds(2);
                AppareillePhoto.SetActive(false);
                Debug.Log("Appareille Photo Utilisé !");

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
            Debug.Log("Vous avez débloquer l'ampoule !");
            

        }
    }
    public IEnumerator GlowStickSpwan()
    {
        Debug.Log("Street Lamp Spawned");
        yield return new WaitForSeconds(10f);
        Debug.Log("Street Lamp fin de la coroutine");
        numberOfGlowStick = 0;
        Debug.Log("Street Lamp -1");
        Destroy(glowStickDestroy);
        Debug.Log("Street Lamp detruit");
        GlowStickCoroutine = null;

    }
    
    // Update is called once per frame
    void Update()
    {
        if (GlowStickRecup == true && GlowStickCoroutine == null && (numberOfGlowStick == 0))
        {
               glowStickDestroy = Instantiate(prefabGlowStick, transform.position, transform.rotation);
            numberOfGlowStick += 1;
            GlowStickCoroutine = StartCoroutine(GlowStickSpwan());
        }
    }
}

