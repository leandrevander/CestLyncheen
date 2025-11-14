using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponsSpawnerManagerLevel1 : MonoBehaviour
{
    [Header("Spawner")]
    public Transform spawnPoint1;

    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;

    [Header("RecupWeapons")]
    public GameObject bulbRecup;

    public GameObject cameraRecup;
    public GameObject glowstickRecup;

    public List<Transform>  SpawnerList  = new List<Transform>();
    public List<GameObject> RecupWeapons = new List<GameObject>();
    public int              radomWeapons;
    public GameObject       WeaponsSpwaner;
    public int              randomSpawner;
    public GameObject       Weapons1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RecupWeapons.Add(bulbRecup);
        RecupWeapons.Add(cameraRecup);
        RecupWeapons.Add(glowstickRecup);
        SpawnerList.Add(spawnPoint1);
        SpawnerList.Add(spawnPoint2);
        SpawnerList.Add(spawnPoint3);
        SpawnerList.Add(spawnPoint4);
        Spawn();

    }

    public IEnumerator Spawn()
    {
        radomWeapons = Random.Range(0, RecupWeapons.Count);
        Debug.Log(radomWeapons);
        randomSpawner = Random.Range(0, SpawnerList.Count);
        Debug.Log(randomSpawner);
        Weapons1 = Instantiate(RecupWeapons[radomWeapons], SpawnerList[randomSpawner]);
        Debug.Log("Un objet est apparu .");
        RecupWeapons.Remove(Weapons1);
        SpawnerList.Remove(SpawnerList[randomSpawner]);
        yield return new WaitForSeconds(10);
        radomWeapons = Random.Range(0, RecupWeapons.Count);
        Debug.Log(radomWeapons);
        randomSpawner = Random.Range(0, SpawnerList.Count);
        Debug.Log(randomSpawner);
        Weapons1 = Instantiate(RecupWeapons[radomWeapons], SpawnerList[randomSpawner]);
        Debug.Log("Un objet est apparu .");
        RecupWeapons.Remove(Weapons1);
        SpawnerList.Remove(SpawnerList[randomSpawner]);
        yield return new WaitForSeconds(10);
        radomWeapons = Random.Range(0, RecupWeapons.Count);
        Debug.Log(radomWeapons);
        randomSpawner = Random.Range(0, SpawnerList.Count);
        Debug.Log(randomSpawner);
        Weapons1 = Instantiate(RecupWeapons[radomWeapons], SpawnerList[randomSpawner]);
        Debug.Log("Un objet est apparu .");
        RecupWeapons.Remove(Weapons1);
        SpawnerList.Remove(SpawnerList[randomSpawner]);
        yield return new WaitForSeconds(10);
        radomWeapons = Random.Range(0, RecupWeapons.Count);
        Debug.Log(radomWeapons);
        randomSpawner = Random.Range(0, SpawnerList.Count);
        Debug.Log(randomSpawner);
        Weapons1 = Instantiate(RecupWeapons[radomWeapons], SpawnerList[randomSpawner]);
        Debug.Log("Un objet est apparu .");
        RecupWeapons.Remove(Weapons1);
        SpawnerList.Remove(SpawnerList[randomSpawner]);
        
    }
}


