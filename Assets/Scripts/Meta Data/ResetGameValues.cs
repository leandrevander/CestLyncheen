using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetGameValues : MonoBehaviour
{
    public MetaDataSystem metaDataSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void ResetData()
    { 
        Debug.Log("Reset Game Values");
        metaDataSystem.SetMetaData(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Start()
    {
        metaDataSystem = FindObjectOfType<MetaDataSystem>();
    }
}
