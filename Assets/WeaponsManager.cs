using System.Collections;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public GameObject ampoule;
    public Ampoule ampouleScript;
    public GameObject recupAmpoule;
    public int nombreAmpoule = 0;
    public GameObject AppareillePhoto;
   public int nombreAppareillePhoto = 0;
    public GameObject RecupAppareillePhoto;
    public GameObject PrefabEnnemi;


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
            Debug.Log("Vous avez débloquer l'appareil photo !");
            StartCoroutine(Flash());
        }
    }
    public IEnumerator Flash()
    {   while (nombreAppareillePhoto >= 1)
        {
            Debug.Log("Flash !");
            AppareillePhoto.SetActive(false);
            Debug.Log("L'appareil photo est en recharge...");
            yield return new WaitForSeconds(2);
            AppareillePhoto.SetActive(true);
            PrefabEnnemi.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Debug.Log("Vous pouvez réutiliser l'appareil photo !");
            yield return new WaitForSeconds(2);
            PrefabEnnemi.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            AppareillePhoto.SetActive(false);
            Debug.Log("Appareille Photo Utilisé !");
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
            Debug.Log("Vous avez débloquer l'ampoule !");
            

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
