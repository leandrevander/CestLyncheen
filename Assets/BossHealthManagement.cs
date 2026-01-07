using System;
using UnityEngine;

public class BossHealthManagement : MonoBehaviour
{
	public LightPhare lightPhare;
	
	void Start()
	{
		lightPhare = GameObject.Find ("Phare Light").GetComponent<LightPhare> ();
	}
	void Update()
	{
		if (lightPhare.totalPercentage >= lightPhare.LevelBoss)
		{
			
			Destroy(gameObject);
		}
	}
}
