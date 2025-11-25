using UnityEngine;

public class PlayerData : MonoBehaviour
{
	public int     metaData;
	public int     unlockedBulbDef;
	MetaDataSystem metaDataSystem;
	
	void Start()
	{
		metaDataSystem  = FindObjectOfType<MetaDataSystem>();
		metaData        = metaDataSystem.CurrentMetaData;
		unlockedBulbDef = metaDataSystem.CurrentUnlockedBulbDef;


	}

	// Update is called once per frame
	void Update()
	{
        
	}
	



	
}
