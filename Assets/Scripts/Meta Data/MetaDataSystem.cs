using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MetaDataSystem : MonoBehaviour
{
    
    string  metaDataKey = "MetaData";

    
    public int CurrentMetaData { get; set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        CurrentMetaData = PlayerPrefs.GetInt(metaDataKey);
    }

    public void SetMetaData(int metaData)
    {
        PlayerPrefs.SetInt(metaDataKey, metaData);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
