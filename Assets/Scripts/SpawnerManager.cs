using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public  float      spawnTimer;
    public Transform playerPosition;
    public  float      remainingTime;

    
    [Header("Mob to spawn")]
    public GameObject snailPrefab;
    public GameObject snailHordePrefab;
    public GameObject snailLevel2Prefab;
    public GameObject snailLevel3Prefab;
    public GameObject sharkPrefab;
    public GameObject dolphinPrefab;
    public GameObject seagullPrefab;
    
    [Header("Active spawn")]
    public bool snailSpawn = false;
    public bool snailHordeSpawn = false;
    public bool snailLevel2Spawn = false;
    public bool snailLevel3Spawn = false;
    public bool sharkSpawn = false;
    public bool dolphinSpawn = false;
    public bool seagullSpawn = false;
    
    
    
    [Header("Distance")]
    public float minDistance;
    public float maxDistance;

    [Header("Insert cooldowns of enemies spawners")]
    public float snailSpawnInterval;
    public float snailHordeSpawnInterval;
    public float sharkSpawnInterval;
    public float dolphinSpawnInterval;
    public float seagullSpawnInterval;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        
        
        //-------------------Les conditions du spawn--------------

        if (snailSpawn && (spawnTimer >= snailSpawnInterval) )
        {
            spawnTimer = 0;
            SpawnSnail();
        }

        if (snailHordeSpawn && (spawnTimer >= snailHordeSpawnInterval))
        {
            spawnTimer = 0;
            SpawnSnailHorde();
        }

        if (snailLevel2Spawn && (spawnTimer >= snailSpawnInterval) )
        {
            spawnTimer = 0;
            SpawnSnailLevel2();
        }
        
        if (snailLevel3Spawn && (spawnTimer >= snailSpawnInterval) )
        {
            spawnTimer = 0;
            SpawnSnailLevel3();
        }
        
        if (sharkSpawn && (spawnTimer >= sharkSpawnInterval))
        {
            spawnTimer = 0;
            SpawnShark();
        }
        
        if (dolphinSpawn && (spawnTimer >= dolphinSpawnInterval))
        {
            spawnTimer = 0;
            SpawnDolphin();
        }

        if (seagullSpawn && (spawnTimer >= seagullSpawnInterval))
        {
            spawnTimer = 0;
            SpawnSeagull();
        }
        
        //----------------------Les Temps de spawns------------------
        if (remainingTime >= 590f)
        {
            snailSpawn      = true;
            snailHordeSpawn = true;
            return;
        }
        
        if (remainingTime >= 540f)
        {
            snailSpawn = true;
            snailHordeSpawn = true;
            return;
        }

        if (remainingTime >= 480f)
        {
            snailSpawn       = false;
            snailLevel2Spawn = true;
            return;
        }
        
        if (remainingTime >= 420f)
        {
            snailLevel2Spawn = true;
            sharkSpawn       = true;
            return;
        }
        
        if (remainingTime >= 380f)
        {
            
            return;
        }
        
        if (remainingTime >= 320f)
        {
            
            return;
        }
    }
    
    //-------------------Les fonctions de spawner-------------------------
    void SpawnSnail()
    {
        float   angleDegre    = Random.Range(0f, 360f);
        float   angleRad      = angleDegre * Mathf.Deg2Rad;
        float   distanceSpawn = Random.Range(minDistance, maxDistance);
        Vector2 localisation  = new Vector2(Mathf.Cos(angleRad) * distanceSpawn, Mathf.Sin(angleRad)* distanceSpawn);
        Vector2 SpawnPosition = new Vector2(playerPosition.position.x, playerPosition.position.y) + localisation;
        Instantiate(snailPrefab, SpawnPosition, Quaternion.identity);
    }
    
    void SpawnSnailHorde()
    {
        float   angleDegre    = Random.Range(0f, 360f);
        float   angleRad      = angleDegre * Mathf.Deg2Rad;
        float   distanceSpawn = Random.Range(minDistance, maxDistance);
        Vector2 localisation  = new Vector2(Mathf.Cos(angleRad) * distanceSpawn, Mathf.Sin(angleRad)* distanceSpawn);
        Vector2 SpawnPosition = new Vector2(playerPosition.position.x, playerPosition.position.y) + localisation;
        Instantiate(snailHordePrefab, SpawnPosition, Quaternion.identity);
    }
    
    void SpawnSnailLevel2()
    {
        float   angleDegre    = Random.Range(0f, 360f);
        float   angleRad      = angleDegre * Mathf.Deg2Rad;
        float   distanceSpawn = Random.Range(minDistance, maxDistance);
        Vector2 localisation  = new Vector2(Mathf.Cos(angleRad) * distanceSpawn, Mathf.Sin(angleRad)* distanceSpawn);
        Vector2 SpawnPosition = new Vector2(playerPosition.position.x, playerPosition.position.y) + localisation;
        Instantiate(snailLevel2Prefab, SpawnPosition, Quaternion.identity);
    }
    
    void SpawnSnailLevel3()
    {
        float   angleDegre    = Random.Range(0f, 360f);
        float   angleRad      = angleDegre * Mathf.Deg2Rad;
        float   distanceSpawn = Random.Range(minDistance, maxDistance);
        Vector2 localisation  = new Vector2(Mathf.Cos(angleRad) * distanceSpawn, Mathf.Sin(angleRad)* distanceSpawn);
        Vector2 SpawnPosition = new Vector2(playerPosition.position.x, playerPosition.position.y) + localisation;
        Instantiate(snailLevel3Prefab, SpawnPosition, Quaternion.identity);
    }

    void SpawnShark()
    {
        float   angleDegre    = Random.Range(0f, 360f);
        float   angleRad      = angleDegre * Mathf.Deg2Rad;
        float   distanceSpawn = Random.Range(minDistance, maxDistance);
        Vector2 localisation  = new Vector2(Mathf.Cos(angleRad) * distanceSpawn, Mathf.Sin(angleRad)* distanceSpawn);
        Vector2 SpawnPosition = new Vector2(playerPosition.position.x, playerPosition.position.y) + localisation;
        Instantiate(sharkPrefab, SpawnPosition, Quaternion.identity);
    }
    
    void SpawnSeagull()
    {
        float   angleDegre    = Random.Range(0f, 360f);
        float   angleRad      = angleDegre * Mathf.Deg2Rad;
        float   distanceSpawn = Random.Range(minDistance, maxDistance);
        Vector2 localisation  = new Vector2(Mathf.Cos(angleRad) * distanceSpawn, Mathf.Sin(angleRad)* distanceSpawn);
        Vector2 SpawnPosition = new Vector2(playerPosition.position.x, playerPosition.position.y) + localisation;
        Instantiate(seagullPrefab, SpawnPosition, Quaternion.identity);
    }
    void SpawnDolphin()
    {
        float   angleDegre    = Random.Range(0f, 360f);
        float   angleRad      = angleDegre * Mathf.Deg2Rad;
        float   distanceSpawn = Random.Range(minDistance, maxDistance);
        Vector2 localisation  = new Vector2(Mathf.Cos(angleRad) * distanceSpawn, Mathf.Sin(angleRad)* distanceSpawn);
        Vector2 SpawnPosition = new Vector2(playerPosition.position.x, playerPosition.position.y) + localisation;
        Instantiate(dolphinPrefab, SpawnPosition, Quaternion.identity);
    }
    
}
