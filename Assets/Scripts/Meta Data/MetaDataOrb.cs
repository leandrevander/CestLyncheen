using UnityEngine;

public class MetaDataOrb : MonoBehaviour
{
    MetaDataSystem metaDataSystem;
    PlayerData playerData;

    public int metaData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        metaDataSystem = FindObjectOfType<MetaDataSystem>();
        playerData = FindObjectOfType<PlayerData>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerData.metaData += 10;
            metaDataSystem.SetMetaData(playerData.metaData);
            Destroy(gameObject);
        }



    }
    
}
