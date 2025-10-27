using System.Collections;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class WeaponsManager : MonoBehaviour
{
    public GameObject ampoule;
    public Bulb ampouleScript;
    public GameObject recupAmpoule;
    public int nombreAmpoule = 0;
    public GameObject AppareillePhoto;
    public int nombreAppareillePhoto = 0;
    public GameObject RecupAppareillePhoto;
    public GameObject PrefabEnnemi;
    public Rigidbody2D ennemi_Rigidbody2D;
    public float freezeDuration = 2f;
    public NavMeshAgent ennemi_NavMesh;
    public freezeEnnemi freeze;



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
            Debug.Log("Vous avez d�bloquer l'appareil photo !");
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
                Debug.Log("Vous pouvez r�utiliser l'appareil photo !");
                yield return new WaitForSeconds(2);
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
        else if  (nombreAmpoule >= 0)
        {
            ampoule.SetActive(true);
            nombreAmpoule += 1;
            Debug.Log("Vous avez d�bloquer l'ampoule !");
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

