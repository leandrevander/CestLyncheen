using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public Transform playerPosition;
    public  float      remainingTime;
    
    private float snailSpawnTimer;
    private float snailHordeSpawnTimer;
    private float sharkSpawnTimer;
    private float dolphinSpawnTimer;
    private float seagullSpawnTimer;


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
        snailSpawnTimer      += Time.deltaTime;
        snailHordeSpawnTimer += Time.deltaTime;
        sharkSpawnTimer      += Time.deltaTime;
        dolphinSpawnTimer    += Time.deltaTime;
        seagullSpawnTimer    += Time.deltaTime;
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        
        
        //-------------------Les conditions du spawn--------------

        if (snailSpawn && (snailSpawnTimer >= snailSpawnInterval) )
        {
            snailSpawnTimer = 0;
            SpawnSnail();
        }
        
        if (snailHordeSpawn && (snailHordeSpawnTimer >= snailHordeSpawnInterval) )
        {
            snailHordeSpawnTimer = 0;
            SpawnSnailHorde();
        }
        
        if (snailLevel2Spawn && (snailSpawnTimer >= snailSpawnInterval) )
        {
            snailSpawnTimer = 0;
            SpawnSnailLevel2();
        }
        
        if (snailLevel2HordeSpawn && (snailHordeSpawnTimer >= snailHordeSpawnInterval) )
        {
            snailHordeSpawnTimer = 0;
            SpawnSnailLevel2Horde();
        }
        
        if (snailLevel3Spawn && (snailSpawnTimer >= snailSpawnInterval) )
        {
            snailSpawnTimer = 0;
            SpawnSnailLevel3();
        }
        
        if (snailLevel3HordeSpawn && (snailHordeSpawnTimer >= snailHordeSpawnInterval) )
        {
            snailHordeSpawnTimer = 0;
            SpawnSnailLevel3Horde();
        }
        
        if (sharkSpawn && (sharkSpawnTimer >= sharkSpawnInterval))
        {
            sharkSpawnTimer = 0;
            SpawnShark();
        }
        
        if (sharkLevel2Spawn && (sharkSpawnTimer >= sharkSpawnInterval))
        {
            sharkSpawnTimer = 0;
            SpawnSharkLevel2();
        }
        
        if (dolphinSpawn && (dolphinSpawnTimer >= dolphinSpawnInterval))
        {
            dolphinSpawnTimer = 0;
            SpawnDolphin();
        }
        
        if (dolphinLevel2Spawn && (dolphinSpawnTimer >= dolphinSpawnInterval))
        {
            dolphinSpawnTimer = 0;
            SpawnDolphinLevel2();
        }

        if (seagullSpawn && (seagullSpawnTimer >= seagullSpawnInterval))
        {
            seagullSpawnTimer = 0;
            SpawnSeagull();
        }
        
        if (seagullLevel2Spawn && (seagullSpawnTimer >= seagullSpawnInterval))
        {
            seagullSpawnTimer = 0;
            SpawnSeagullLevel2();
        }
        
        //----------------------Les Temps de spawns------------------

        if (remainingTime >= 590f)
        {
            
        }
        else if (remainingTime >= 540f)
        {
            snailSpawn = true;
        }
        else if (remainingTime >= 510f)
        {
            seagullSpawn = true;
        }
        else if (remainingTime >= 480f)
        {
            sharkSpawn = true;
        }
        else if (remainingTime >= 420f)
        {
            seagullSpawn = false;
            sharkSpawn = false;
            
            snailHordeSpawn = true;
            dolphinSpawn = true;
        }
        else if (remainingTime >= 380f)
        {
            snailSpawn = false;
            snailHordeSpawn = false;

            snailLevel2Spawn = true;
        }
        else if (remainingTime >= 320f)
        {
            seagullLevel2Spawn = true;
            
        }
        else if (remainingTime >= 220f)
        {
            seagullLevel2Spawn    = false;
            dolphinLevel2Spawn    = false;
            
            snailLevel2HordeSpawn = true;
            sharkLevel2Spawn      = true;
        }
        else if (remainingTime >= 180f)
        {
            snailLevel2Spawn      = false;
            snailLevel2HordeSpawn = false;
            sharkLevel2Spawn      = false;

            snailLevel3Spawn      = true;
            snailLevel3HordeSpawn = true;
        }
        else if (remainingTime >= 120f)
        {
            seagullLevel2Spawn = true;
            dolphinLevel2Spawn = true;

        }
        else if (remainingTime >= 0f)
        {
            sharkLevel2Spawn = true;
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
        Debug.Log("La mouette a pop");
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
        Debug.Log("Flipper a pop");
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
