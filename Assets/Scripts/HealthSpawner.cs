using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject       healthprefab;
    public List<GameObject> HealthSpawnerLocation = new List<GameObject>();
    public List<GameObject> AvailableLocation = new List<GameObject>();

    public float timer;

    public float spawningInterval;

    public GameObject arrowPrefab;
    
    public GameObject mainCanvas;

    [HideInInspector]public GameObject healthItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetLocation();
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
        if (AvailableLocation.Count == 0)
        {
            ResetLocation();
        }
        int random =Random.Range(0, AvailableLocation.Count);
        healthItem =Instantiate(healthprefab, AvailableLocation[random].transform.position, Quaternion.identity);
        Instantiate(arrowPrefab,  mainCanvas.transform);
        AvailableLocation.RemoveAt(random);
        
    }

    void ResetLocation()
    {
        AvailableLocation = new List<GameObject>(HealthSpawnerLocation);
    }
}
