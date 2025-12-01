using UnityEngine;

public class PlayerData : MonoBehaviour
{
	public int     metaData;
	public int     unlockedBulbDef;
	public int     unlockedCameraDef;
	public int     unlockedGlowstickDef;
	MetaDataSystem metaDataSystem;
	
	void Start()
	{
		metaDataSystem    = FindObjectOfType<MetaDataSystem>();
		metaData          = metaDataSystem.CurrentMetaData;
		unlockedBulbDef   = metaDataSystem.CurrentUnlockedBulbDef;
		unlockedCameraDef = metaDataSystem.CurrentUnlockedCameraDef;
		unlockedGlowstickDef = metaDataSystem.CurrentUnlockedGlowstickDef;


	}

	// Update is called once per frame
	void Update()
	{
        
	}
	



	
}
