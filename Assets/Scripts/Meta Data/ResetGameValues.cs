using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetGameValues : MonoBehaviour
{
    public MetaDataSystem metaDataSystem;
    public PlayerData playerData;

    public AudioSource select;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void ResetData()
    { 
        select.Play();
        Debug.Log("Reset Game Values");
        playerData.metaData             = 0;
        playerData.unlockedBulbDef      = 0;
        playerData.unlockedCameraDef    = 0;
        playerData.unlockedGlowstickDef = 0;
        playerData.unlockedLevel2Def    = 0;
        playerData.snailsKilled         = 0;
        playerData.seagullsKilled       = 0;
        playerData.sharksKilled         = 0;
        playerData.dolphinsKilled       = 0;
        metaDataSystem.SetMetaData(0);
        metaDataSystem.SetUnlockedBulb(0); 
        metaDataSystem.SetUnlockedCamera(0);
        metaDataSystem.SetUnlockedGlowstick(0);
        metaDataSystem.SetUnlockedLevel2(0);
        metaDataSystem.SetSnailsKilled(0);
        metaDataSystem.SetSeagullsKilled(0);
        metaDataSystem.SetSharksKilled(0);
        metaDataSystem.SetDolphinsKilled(0);
        PlayerPrefs.Save();
    }

    public void Cheat()
    {
        select.Play();

        Debug.Log("Cheat");
        playerData.metaData             = 9999;
        metaDataSystem.SetMetaData(9999);
        
        playerData.unlockedLevel2Def    = 1;
        metaDataSystem.SetUnlockedLevel2(1);
        
        playerData.snailsKilled        = 200;
        playerData.seagullsKilled      = 150;
        playerData.sharksKilled        = 100;
        playerData.dolphinsKilled      = 50;
        
        metaDataSystem.SetSnailsKilled(200);
        metaDataSystem.SetSeagullsKilled(150);
        metaDataSystem.SetSharksKilled(100);
        metaDataSystem.SetDolphinsKilled(50);
        
        PlayerPrefs.Save();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Start()
    {
        metaDataSystem = FindObjectOfType<MetaDataSystem>();
        playerData     = FindObjectOfType<PlayerData>();
    }
}
