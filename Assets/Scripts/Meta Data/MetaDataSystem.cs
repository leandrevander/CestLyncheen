using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MetaDataSystem : MonoBehaviour
{
    
    string metaDataKey             = "MetaData";
    string unlockedBulbDefKey      = "UnlockedBulbDef";
    string unlockedCameraDefKey    = "UnlockedCameraDef";
    string unlockedGlowstickDefKey = "UnlockedGlowstickDef";
    string unlockedLevel2DefKey = "UnlockedLevel2Def";

    
    public int CurrentMetaData { get; set; }
    public int CurrentUnlockedBulbDef { get; set; }
    
    public int CurrentUnlockedCameraDef { get; set; }
    public int CurrentUnlockedGlowstickDef { get; set; }
    
    public int CurrentUnlockedLevel2Def { get; set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        CurrentMetaData             = PlayerPrefs.GetInt(metaDataKey);
        CurrentUnlockedBulbDef      = PlayerPrefs.GetInt(unlockedBulbDefKey);
        CurrentUnlockedCameraDef    = PlayerPrefs.GetInt(unlockedCameraDefKey);
        CurrentUnlockedGlowstickDef = PlayerPrefs.GetInt(unlockedGlowstickDefKey);
        CurrentUnlockedLevel2Def = PlayerPrefs.GetInt(unlockedLevel2DefKey);
        
    }

    public void SetMetaData(int metaData)
    {
        PlayerPrefs.SetInt(metaDataKey, metaData);
    }
    
    public void SetUnlockedBulb(int unlockedBulbDef)
    {
        PlayerPrefs.SetInt(unlockedBulbDefKey, unlockedBulbDef);
    }
    
    public void SetUnlockedCamera(int unlockedCameraDef)
    {
        PlayerPrefs.SetInt(unlockedCameraDefKey, unlockedCameraDef);
    }
    
    public void SetUnlockedGlowstick(int unlockedGlowstickDef)
    {
        PlayerPrefs.SetInt(unlockedGlowstickDefKey, unlockedGlowstickDef);
    }
    
    public void SetUnlockedLevel2(int unlockedLevel2Def)
    {
        PlayerPrefs.SetInt(unlockedLevel2DefKey, unlockedLevel2Def);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
