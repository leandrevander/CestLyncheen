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
        metaDataSystem.SetMetaData(0);
        metaDataSystem.SetUnlockedBulb(0); 
        metaDataSystem.SetUnlockedCamera(0);
        metaDataSystem.SetUnlockedGlowstick(0);
        metaDataSystem.SetUnlockedLevel2(0);
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
