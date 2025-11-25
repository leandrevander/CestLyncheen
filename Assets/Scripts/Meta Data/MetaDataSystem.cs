using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MetaDataSystem : MonoBehaviour
{
    
    string  metaDataKey = "MetaData";
    string unlockedBulbDefKey = "UnlockedBulbDef";

    
    public int CurrentMetaData { get; set; }
    public int CurrentUnlockedBulbDef { get; set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        CurrentMetaData     = PlayerPrefs.GetInt(metaDataKey);
        CurrentUnlockedBulbDef = PlayerPrefs.GetInt(unlockedBulbDefKey);
    }

    public void SetMetaData(int metaData)
    {
        PlayerPrefs.SetInt(metaDataKey, metaData);
    }
    
    public void SetUnlockedBulb(int unlockedBulbDef)
    {
        PlayerPrefs.SetInt(unlockedBulbDefKey, unlockedBulbDef);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
