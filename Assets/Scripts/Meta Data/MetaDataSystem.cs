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
    
    string musicVolKey = "musicVol";
    string sfxVolKey = "sfxVol";
    
    string snailsKilledKey = "SnailsKilledDef";
    string seagullsKilledKey = "SeagullsKilledDef";
    string sharksKilledKey = "SharksKilledDef";
    string dolphinsKilledKey = "DolphinsKilledDef";



    
    public int CurrentMetaData { get; set; }
    public int CurrentUnlockedBulbDef { get; set; }
    
    public int CurrentUnlockedCameraDef { get; set; }
    public int CurrentUnlockedGlowstickDef { get; set; }
    
    public int CurrentUnlockedLevel2Def { get; set; }
    
    public int CurrentMusicVol { get; set; }
    
    public int CurrentSFXVol { get; set; }
    
    public int CurrentSnailsKilled { get; set; }
    
    public int CurrentSeagullsKilled { get; set; }
    
    public int CurrentSharksKilled { get; set; }
    
    public int CurrentDolphinsKilled { get; set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        CurrentMetaData             = PlayerPrefs.GetInt(metaDataKey);
        CurrentUnlockedBulbDef      = PlayerPrefs.GetInt(unlockedBulbDefKey);
        CurrentUnlockedCameraDef    = PlayerPrefs.GetInt(unlockedCameraDefKey);
        CurrentUnlockedGlowstickDef = PlayerPrefs.GetInt(unlockedGlowstickDefKey);
        CurrentUnlockedLevel2Def = PlayerPrefs.GetInt(unlockedLevel2DefKey);
        CurrentMusicVol         = PlayerPrefs.GetInt(musicVolKey);
        CurrentSFXVol         = PlayerPrefs.GetInt(sfxVolKey);
        CurrentSnailsKilled      = PlayerPrefs.GetInt(snailsKilledKey);
        CurrentSharksKilled      = PlayerPrefs.GetInt(sharksKilledKey);
        CurrentSeagullsKilled    = PlayerPrefs.GetInt(seagullsKilledKey);
        CurrentDolphinsKilled    = PlayerPrefs.GetInt(dolphinsKilledKey);
        
    }

    public void SetMetaData(int metaData)
    {
        PlayerPrefs.SetInt(metaDataKey, metaData);
    }

    public void SetMusicVol(int musicVol)
    {
        PlayerPrefs.SetInt(musicVolKey, musicVol);
    }

    public void SetSFXVol(int sfxVol)
    {
        PlayerPrefs.SetInt(sfxVolKey, sfxVol);
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

    public void SetSnailsKilled(int snailsKilledDef)
    {
        PlayerPrefs.SetInt(snailsKilledKey, snailsKilledDef);
    }

    public void SetSeagullsKilled(int seagullsKilledDef)
    {
        PlayerPrefs.SetInt(seagullsKilledKey, seagullsKilledDef);
    }

    public void SetSharksKilled(int sharksKilledDef)
    {
        PlayerPrefs.SetInt(sharksKilledKey, sharksKilledDef);
    }

    public void SetDolphinsKilled(int dolphinsKilledDef)
    {
        PlayerPrefs.SetInt(dolphinsKilledKey, dolphinsKilledDef);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
