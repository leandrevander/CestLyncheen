using UnityEngine;

public class PlayerData : MonoBehaviour
{
	public int     metaData;
	MetaDataSystem metaDataSystem;
	
	void Start()
	{
		metaDataSystem = FindObjectOfType<MetaDataSystem>();
		metaData       = metaDataSystem.CurrentMetaData;
		

	}

	// Update is called once per frame
	void Update()
	{
        
	}
	



	
}
