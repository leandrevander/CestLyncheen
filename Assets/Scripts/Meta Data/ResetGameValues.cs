using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetGameValues : MonoBehaviour
{
    public MetaDataSystem metaDataSystem;
    public PlayerData playerData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void ResetData()
    { 
        Debug.Log("Reset Game Values");
        playerData.metaData             = 0;
        playerData.unlockedBulbDef      = 0;
        playerData.unlockedCameraDef    = 0;
        playerData.unlockedGlowstickDef = 0;
        metaDataSystem.SetMetaData(playerData.metaData);
        metaDataSystem.SetMetaData(playerData.unlockedBulbDef);
        metaDataSystem.SetMetaData(playerData.unlockedCameraDef);
        metaDataSystem.SetMetaData(playerData.unlockedGlowstickDef);
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
