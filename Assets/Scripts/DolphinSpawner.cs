using UnityEngine;

public class DolphinSpawner : MonoBehaviour
{
    public GameObject enemyprefab;

    public float spawnTimer;

    public float spawnInterval;

    public float minDistance;
    public float maxDistance;
    private Collider2D newEnemyCol;
    

    public float distanceSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0;
            SpawnEnemy();
            print("Spawné");
        }
    }

    public void SpawnEnemy()
    {
        float   angleDegre    = Random.Range(0f, 360f);
        float   angleRad      = angleDegre * Mathf.Deg2Rad;
        float   distanceSpawn = Random.Range(minDistance, maxDistance);
        Vector2 localisation  = new Vector2(Mathf.Cos(angleRad) * distanceSpawn, Mathf.Sin(angleRad)* distanceSpawn);
        Vector2 SpawnPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) + localisation;
        Instantiate(enemyprefab, SpawnPosition, Quaternion.identity);
        
        
        
        
    }
}