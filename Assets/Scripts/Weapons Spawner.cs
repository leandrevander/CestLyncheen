using System.Collections.Generic;
using UnityEngine;

public class WeaponsSpawner : MonoBehaviour
{
    public List<GameObject> weaponLocationsList;
    public List<GameObject> weaponItemList;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < weaponLocationsList.Count; i++)
        {
            //Instantiate(weaponItemList[i], )
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
