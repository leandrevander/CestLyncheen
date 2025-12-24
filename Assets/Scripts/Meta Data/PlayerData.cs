using UnityEngine;

public class PlayerData : MonoBehaviour
{
	public int metaData;
	public int unlockedBulbDef;
	public int unlockedCameraDef;
	public int unlockedGlowstickDef;
	public int unlockedLevel2Def;
	public float musicVol;
	public float sfxVol;

	MetaDataSystem metaDataSystem;
	
	void Start()
	{
		metaDataSystem       = FindObjectOfType<MetaDataSystem>();
		metaData             = metaDataSystem.CurrentMetaData;
		unlockedBulbDef      = metaDataSystem.CurrentUnlockedBulbDef;
		unlockedCameraDef    = metaDataSystem.CurrentUnlockedCameraDef;
		unlockedGlowstickDef = metaDataSystem.CurrentUnlockedGlowstickDef;
		unlockedLevel2Def    = metaDataSystem.CurrentUnlockedLevel2Def;
		musicVol         = metaDataSystem.CurrentMusicVol;
		sfxVol         = metaDataSystem.CurrentSFXVol;


	}

	// Update is called once per frame
	void Update()
	{
        
	}
	



	
}
