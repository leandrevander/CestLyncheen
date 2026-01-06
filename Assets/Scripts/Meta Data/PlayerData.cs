using UnityEngine;

public class PlayerData : MonoBehaviour
{
	public int   metaData;
	public int   unlockedBulbDef;
	public int   unlockedCameraDef;
	public int   unlockedGlowstickDef;
	public int   unlockedLevel2Def;
	public float musicVol;
	public float sfxVol;
	public int   snailsKilled;
	public int   seagullsKilled;
	public int   sharksKilled;
	public int   dolphinsKilled;


	MetaDataSystem metaDataSystem;
	
	void Start()
	{
		metaDataSystem       = FindObjectOfType<MetaDataSystem>();
		metaData             = metaDataSystem.CurrentMetaData;
		unlockedBulbDef      = metaDataSystem.CurrentUnlockedBulbDef;
		unlockedCameraDef    = metaDataSystem.CurrentUnlockedCameraDef;
		unlockedGlowstickDef = metaDataSystem.CurrentUnlockedGlowstickDef;
		unlockedLevel2Def    = metaDataSystem.CurrentUnlockedLevel2Def;
		musicVol             = metaDataSystem.CurrentMusicVol;
		sfxVol               = metaDataSystem.CurrentSFXVol;
		snailsKilled         = metaDataSystem.CurrentSnailsKilled;
		sharksKilled         = metaDataSystem.CurrentSharksKilled;
		seagullsKilled       = metaDataSystem.CurrentSeagullsKilled;
		dolphinsKilled       = metaDataSystem.CurrentDolphinsKilled;


	}

	// Update is called once per frame
	void Update()
	{
        
	}
	



	
}