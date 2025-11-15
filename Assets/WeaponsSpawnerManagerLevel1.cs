using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponsSpawnerManagerLevel1 : MonoBehaviour
{
    [Header("Spawner")]
    

    [Header("RecupWeapons")]
   

    public List<Transform>  SpawnerList  = new List<Transform>();
    public List<GameObject> RecupWeapons = new List<GameObject>();
    public int              radomWeapons;
    public int              randomSpawner;
    public GameObject       Weapons1;

    [Header("Timers")]
    public float timer;

    public float spawnInterval;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval && RecupWeapons.Count >= 1)
        {
            timer = 0;
            SpawnWeapon();
        }
    }

    public void SpawnWeapon()
    {
        radomWeapons  = Random.Range(0, RecupWeapons.Count);
        randomSpawner = Random.Range(0, SpawnerList.Count);
        Instantiate(RecupWeapons[radomWeapons], SpawnerList[randomSpawner]);
        RecupWeapons.Remove(RecupWeapons[radomWeapons]);
        SpawnerList.Remove(SpawnerList[randomSpawner]);
        
        
        
    }

    public IEnumerator Spawn()
    {
        radomWeapons = Random.Range(0, RecupWeapons.Count);
        Debug.Log(radomWeapons);
        randomSpawner = Random.Range(0, SpawnerList.Count);
        Debug.Log(randomSpawner);
        Weapons1 = Instantiate(RecupWeapons[radomWeapons], SpawnerList[randomSpawner]);
        Debug.Log("Un objet est apparu .");
        RecupWeapons.Remove(RecupWeapons[radomWeapons]);
        SpawnerList.Remove(SpawnerList[randomSpawner]);
        yield return new WaitForSeconds(5);
        radomWeapons = Random.Range(0, RecupWeapons.Count);
        Debug.Log(radomWeapons);
        randomSpawner = Random.Range(0, SpawnerList.Count);
        Debug.Log(randomSpawner);
        Weapons1 = Instantiate(RecupWeapons[radomWeapons], SpawnerList[randomSpawner]);
        Debug.Log("Un objet est apparu .");
        RecupWeapons.Remove(RecupWeapons[radomWeapons]);
        SpawnerList.Remove(SpawnerList[randomSpawner]);
        yield return new WaitForSeconds(5);
        radomWeapons = Random.Range(0, RecupWeapons.Count);
        Debug.Log(radomWeapons);
        randomSpawner = Random.Range(0, SpawnerList.Count);
        Debug.Log(randomSpawner);
        Weapons1 = Instantiate(RecupWeapons[radomWeapons], SpawnerList[randomSpawner]);
        Debug.Log("Un objet est apparu .");
        RecupWeapons.Remove(RecupWeapons[radomWeapons]);
        SpawnerList.Remove(SpawnerList[randomSpawner]);
        yield return new WaitForSeconds(5);




    }
}


