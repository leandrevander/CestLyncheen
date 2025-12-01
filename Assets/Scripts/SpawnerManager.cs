using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public  float      spawnTimer;
    public Transform playerPosition;
    public  float      remainingTime;
        
    [Header("Distance")]
    public float minDistance;
    public float maxDistance;
    
    [Header("Mob to spawn ")]
    public GameObject snailPrefab;
    public GameObject snailHordePrefab;
    public GameObject snailLevel2Prefab;
    public GameObject snailLevel2HordePrefab;
    public GameObject snailLevel3Prefab;
    public GameObject snailLevel3HordePrefab;
    public GameObject sharkPrefab;
    public GameObject sharkLevel2Prefab;
    public GameObject dolphinPrefab;
    public GameObject dolphinLevel2Prefab;
    public GameObject seagullPrefab;
    public GameObject seagullLevel2Prefab;
    
    [Header("Cooldowns of enemies spawners")]
    public float snailSpawnInterval;
    public float snailHordeSpawnInterval;
    public float sharkSpawnInterval;
    public float dolphinSpawnInterval;
    public float seagullSpawnInterval;
    
    [Header("Active spawn")]
    public bool snailSpawn = false;
    public bool snailHordeSpawn       = false;
    public bool snailLevel2Spawn      = false;
    public bool snailLevel2HordeSpawn = false;
    public bool snailLevel3Spawn      = false;
    public bool snailLevel3HordeSpawn = false;
    public bool sharkSpawn         = false;
    public bool sharkLevel2Spawn   = false;
    public bool dolphinSpawn       = false;
    public bool dolphinLevel2Spawn = false;
    public bool seagullSpawn       = false;
    public bool seagullLevel2Spawn = false;

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
        
        if (snailHordeSpawn && (spawnTimer >= snailHordeSpawnInterval) )
        {
            spawnTimer = 0;
            SpawnSnailHorde();
        }
        
        if (snailLevel2Spawn && (spawnTimer >= snailSpawnInterval) )
        {
            spawnTimer = 0;
            SpawnSnailLevel2();
        }
        
        if (snailLevel2HordeSpawn && (spawnTimer >= snailHordeSpawnInterval) )
        {
            spawnTimer = 0;
            SpawnSnailLevel2Horde();
        }
        
        if (snailLevel3Spawn && (spawnTimer >= snailSpawnInterval) )
        {
            spawnTimer = 0;
            SpawnSnailLevel3();
        }
        
        if (snailLevel3HordeSpawn && (spawnTimer >= snailHordeSpawnInterval) )
        {
            spawnTimer = 0;
            SpawnSnailLevel3Horde();
        }
        
        if (sharkSpawn && (spawnTimer >= sharkSpawnInterval))
        {
            spawnTimer = 0;
            SpawnShark();
        }
        
        if (sharkLevel2Spawn && (spawnTimer >= sharkSpawnInterval))
        {
            spawnTimer = 0;
            SpawnSharkLevel2();
        }
        
        if (dolphinSpawn && (spawnTimer >= dolphinSpawnInterval))
        {
            spawnTimer = 0;
            SpawnDolphin();
        }
        
        if (dolphinLevel2Spawn && (spawnTimer >= dolphinSpawnInterval))
        {
            spawnTimer = 0;
            SpawnDolphinLevel2();
        }

        if (seagullSpawn && (spawnTimer >= seagullSpawnInterval))
        {
            spawnTimer = 0;
            SpawnSeagull();
        }
        
        if (seagullLevel2Spawn && (spawnTimer >= seagullSpawnInterval))
        {
            spawnTimer = 0;
            SpawnSeagullLevel2();
        }
        
        //----------------------Les Temps de spawns------------------
        if (remainingTime >= 590f)
        {
            snailSpawn = true;
            return;
        }
        
        if (remainingTime >= 540f)
        {
            seagullSpawn = true;
            return;
        }

        if (remainingTime >= 480f)
        {
            seagullSpawn    = false;
            snailHordeSpawn = true;
            sharkSpawn      = true;
            return;
        }
        
        if (remainingTime >= 420f)
        {
            snailSpawn = false;
            snailHordeSpawn = false;
            sharkSpawn    = false;
            snailLevel2Spawn = true;
            return;
        }
        
        if (remainingTime >= 380f)
        {
            snailLevel2HordeSpawn = true;
            seagullLevel2Spawn    = true;
            return;
        }
        
        if (remainingTime >= 320f)
        {
            dolphinSpawn = true;
            return;
        }
        
        if (remainingTime >= 280f)
        {
            seagullLevel2Spawn = false;
            dolphinLevel2Spawn = false;
            sharkLevel2Spawn   = true;
            return;
        }
        
        if (remainingTime >= 220f)
        {
            snailLevel2Spawn      = false;
            snailLevel2HordeSpawn = false;
            snailLevel3Spawn    = true;
            return;
        }
        
        if (remainingTime >= 180f)
        {
            sharkLevel2Spawn      = false;
            snailLevel3HordeSpawn = true;
            seagullLevel2Spawn    = true;
            return;
        }
        
        if (remainingTime >= 120f)
        {
            sharkLevel2Spawn = true;
            return;
        }
        
        if (remainingTime >= 60f)
        {
            dolphinLevel2Spawn = true;
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
    
    void SpawnSnailLevel2Horde()
    {
        float   angleDegre    = Random.Range(0f, 360f);
        float   angleRad      = angleDegre * Mathf.Deg2Rad;
        float   distanceSpawn = Random.Range(minDistance, maxDistance);
        Vector2 localisation  = new Vector2(Mathf.Cos(angleRad) * distanceSpawn, Mathf.Sin(angleRad)* distanceSpawn);
        Vector2 SpawnPosition = new Vector2(playerPosition.position.x, playerPosition.position.y) + localisation;
        Instantiate(snailLevel2HordePrefab, SpawnPosition, Quaternion.identity);
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
    
    void SpawnSnailLevel3Horde()
    {
        float   angleDegre    = Random.Range(0f, 360f);
        float   angleRad      = angleDegre * Mathf.Deg2Rad;
        float   distanceSpawn = Random.Range(minDistance, maxDistance);
        Vector2 localisation  = new Vector2(Mathf.Cos(angleRad) * distanceSpawn, Mathf.Sin(angleRad)* distanceSpawn);
        Vector2 SpawnPosition = new Vector2(playerPosition.position.x, playerPosition.position.y) + localisation;
        Instantiate(snailLevel3HordePrefab, SpawnPosition, Quaternion.identity);
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
    
    void SpawnSharkLevel2()
    {
        float   angleDegre    = Random.Range(0f, 360f);
        float   angleRad      = angleDegre * Mathf.Deg2Rad;
        float   distanceSpawn = Random.Range(minDistance, maxDistance);
        Vector2 localisation  = new Vector2(Mathf.Cos(angleRad) * distanceSpawn, Mathf.Sin(angleRad)* distanceSpawn);
        Vector2 SpawnPosition = new Vector2(playerPosition.position.x, playerPosition.position.y) + localisation;
        Instantiate(sharkLevel2Prefab, SpawnPosition, Quaternion.identity);
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
    
    void SpawnSeagullLevel2()
    {
        float   angleDegre    = Random.Range(0f, 360f);
        float   angleRad      = angleDegre * Mathf.Deg2Rad;
        float   distanceSpawn = Random.Range(minDistance, maxDistance);
        Vector2 localisation  = new Vector2(Mathf.Cos(angleRad) * distanceSpawn, Mathf.Sin(angleRad)* distanceSpawn);
        Vector2 SpawnPosition = new Vector2(playerPosition.position.x, playerPosition.position.y) + localisation;
        Instantiate(seagullLevel2Prefab, SpawnPosition, Quaternion.identity);
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
    
    void SpawnDolphinLevel2()
    {
        float   angleDegre    = Random.Range(0f, 360f);
        float   angleRad      = angleDegre * Mathf.Deg2Rad;
        float   distanceSpawn = Random.Range(minDistance, maxDistance);
        Vector2 localisation  = new Vector2(Mathf.Cos(angleRad) * distanceSpawn, Mathf.Sin(angleRad)* distanceSpawn);
        Vector2 SpawnPosition = new Vector2(playerPosition.position.x, playerPosition.position.y) + localisation;
        Instantiate(dolphinLevel2Prefab, SpawnPosition, Quaternion.identity);
    }
    
}
