using UnityEngine;

public class PlayerData : MonoBehaviour
{
	public int metaData;
	public int unlockedBulbDef;
	public int unlockedCameraDef;
	public int unlockedGlowstickDef;
	public int unlockedLevel2Def;

	MetaDataSystem metaDataSystem;
	
	void Start()
	{
		metaDataSystem       = FindObjectOfType<MetaDataSystem>();
		metaData             = metaDataSystem.CurrentMetaData;
		unlockedBulbDef      = metaDataSystem.CurrentUnlockedBulbDef;
		unlockedCameraDef    = metaDataSystem.CurrentUnlockedCameraDef;
		unlockedGlowstickDef = metaDataSystem.CurrentUnlockedGlowstickDef;
		unlockedLevel2Def    = metaDataSystem.CurrentUnlockedLevel2Def;


	}

	// Update is called once per frame
	void Update()
	{
        
	}
	



	
}
