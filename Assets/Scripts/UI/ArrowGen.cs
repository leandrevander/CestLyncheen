using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowGen : MonoBehaviour
{
    

    public Image      imagePointeur;
    public GameObject imageGO;
    
    [Header("Cible à suivre")]
    public GameObject target;
    public WeaponsSpawnerManagerLevel1 weaponsLocation;
    public Transform targetposition;

    [Header("Marge du bord d'écran (en pixels)")]
    public float edgePadding = 50f;

    private RectTransform pointerRectTransform;
    private Camera        mainCamera;
    public  GameObject    targetchildren;

    
    
    

    private void Awake()
    {
        
        
        pointerRectTransform    = GetComponent<RectTransform>();
        mainCamera              = Camera.main;
        
        
        
        imagePointeur.enabled = false;

    }



    void Update()
    {
        if (targetchildren)
        {
            Vector3 screenPos = mainCamera.WorldToScreenPoint(target.transform.position);

            bool isOffScreen = screenPos.x < 0 || screenPos.x > Screen.width || screenPos.y < 0 || screenPos.y > Screen.height;

            // Détection apparition dans l'écran
            if (!isOffScreen && target)
            {
                isOffScreen = true;
                Debug.Log("La cible est visible");
                imagePointeur.enabled = false;
                // Fait disparaitre la fleche tant que la target est dans l'ecran
            }
            else if (isOffScreen&& target)
            {
                Debug.Log("La cible n'est pas visible");
                imagePointeur.enabled = true;
                // Fait aparaitre la fleche tant que la target n'est pas dans l'ecran
            }
            // Met une marge a de x au bord de l'ecran
            screenPos.x = Mathf.Clamp(screenPos.x, edgePadding, Screen.width - edgePadding);
            screenPos.y = Mathf.Clamp(screenPos.y, edgePadding, Screen.height - edgePadding);
            screenPos.z = 0f;
            
        
            pointerRectTransform.position = screenPos;

            // Calcul direction (vers la cible dans le monde)
            Vector3 toTarget = (target.transform.position - mainCamera.transform.position).normalized;
            float   angle    = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg;
            pointerRectTransform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        else
        {
            imagePointeur.enabled = false;
            gameObject.SetActive(false);
        }
        
    }
}