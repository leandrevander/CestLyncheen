using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject healthprefab;
    public List<GameObject> HealthSpawnerLocation = new List<GameObject>();

    public float timer;

    public float spawningInterval;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawningInterval)
            {
            timer = 0;
            SpawnHealth();
            }
    }

    void SpawnHealth()
    {
        int random =Random.Range(0, HealthSpawnerLocation.Count);
        Instantiate(healthprefab, HealthSpawnerLocation[random].transform.position, Quaternion.identity);
    }
}
