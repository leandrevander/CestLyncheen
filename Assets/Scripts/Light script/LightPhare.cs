using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class LightPhare : MonoBehaviour
{


    public GeneratorSystem generator1;
    public GeneratorSystem generator2;
    public GeneratorSystem generator3;
    public GeneratorSystem generator4;
    public int             generatorsNumber;

    public int totalPercentage;

    public  int         lightPhareSpeed;
    private Rigidbody2D rb;
    private Light2D     light;


    public float level1 = 50f;
    public float level2 = 150f;
    public float level3 = 200f;
    public float level4 = 300f;

    public float phareRespawnLevel1 = 8f;
    public float phareRespawnLevel2 = 6f;
    public float phareRespawnLevel3 = 4f;
    public float phareRespawnLevel4 = 2f;


    public PhareRotation phareRotation;

    [Header("Ouais ça c'est pour tout ce qui est lié au texte en dessous du timer")]
    public TextMeshProUGUI phareBonusText;

    public GameObject phareBonusTextGO;

    public float timer;
    public float timerInterval = 120f;
    
    Coroutine coroutine;


    [Header("Recompense MetaData ")]
    public int metaDataLVL4 = 40;

    public int metaDataLVL3 = 30;
    public int metaDataLVL2 = 20;
    public int metaDataLVL1 = 10;
    
    
    MetaDataSystem metaDataSystem;
    PlayerData     playerData;

    private void Awake()
    {
        rb    = GetComponent<Rigidbody2D>();
        light = gameObject.GetComponent<Light2D>();
        
        metaDataSystem = FindObjectOfType<MetaDataSystem>();
        playerData     = FindObjectOfType<PlayerData>();
        
        phareBonusTextGO.SetActive(false);
    }

    // Update is called once per frame


    void Update()
    {
        timer += Time.deltaTime;
        /*if (timer >= timerInterval && coroutine == null)
        {
            //coroutine = StartCoroutine(checkBonus());
            timer     = 0;
        }*/

        totalPercentage = generator1.percentage + generator2.percentage + generator3.percentage + generator4.percentage;
        //Debug.Log($"total percentage = {totalPercentage}");


        if (totalPercentage >= level4)
        {
            phareRotation.lighthouseRespawnDelay = phareRespawnLevel4;
            return;
        }

        if (totalPercentage >= level3)
        {
            phareRotation.lighthouseRespawnDelay = phareRespawnLevel3;
            return;
        }

        if (totalPercentage >= level2)
        {
            phareRotation.lighthouseRespawnDelay = phareRespawnLevel2;
            return;
        }

        if (totalPercentage >= level1)
        {
            phareRotation.lighthouseRespawnDelay = phareRespawnLevel1;
            return;
        }
        else
        {
            //light.enabled                        = false;
            phareRotation.lighthouseRespawnDelay = 30f;
        }

    }

    public IEnumerator checkBonus()
    {
        
        
        if (totalPercentage >= level4)
        {
                phareBonusTextGO.SetActive(true);
                phareBonusText.text =  "Metadata obtenu : " + metaDataLVL4;
                playerData.metaData += metaDataLVL4;
                metaDataSystem.SetMetaData(playerData.metaData);
                yield return new WaitForSeconds(3);
                phareBonusTextGO.SetActive(false);

        }

            
        

        else if (totalPercentage >= level3)
        {
            phareBonusTextGO.SetActive(true);
            phareBonusText.text =  "Metadata obtenu : " + metaDataLVL3;
            playerData.metaData += metaDataLVL3;
            metaDataSystem.SetMetaData(playerData.metaData);
            yield return new WaitForSeconds(3);
            phareBonusTextGO.SetActive(false);
        }

         else if (totalPercentage >= level2)
        {
            phareBonusTextGO.SetActive(true);
            phareBonusText.text =  "Metadata obtenu : " + metaDataLVL2;
            playerData.metaData += metaDataLVL2;
            metaDataSystem.SetMetaData(playerData.metaData);
            yield return new WaitForSeconds(3);
            phareBonusTextGO.SetActive(false);
        }

        else if (totalPercentage >= level1)
        {
            phareBonusTextGO.SetActive(true);
            phareBonusText.text =  "Metadata obtenu : " + metaDataLVL1;
            playerData.metaData += metaDataLVL1;
            metaDataSystem.SetMetaData(playerData.metaData);
            yield return new WaitForSeconds(3);
            phareBonusTextGO.SetActive(false);
        }
        else
        {
            phareBonusTextGO.SetActive(true);
            phareBonusText.text =  "Metadata obtenu : 0 :( ";
            yield return new WaitForSeconds(3);
            phareBonusTextGO.SetActive(false);
        }
        coroutine = null;
        StopCoroutine(checkBonus());


    }
}


