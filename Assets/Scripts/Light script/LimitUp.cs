using UnityEngine;

public class LimitUp : MonoBehaviour
{
	public GameObject lightPhare;

	private LightPhare lp;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
		lp         = lightPhare.GetComponent<LightPhare>();
	}

	// Update is called once per frame
	void Update()
	{
        
	}

	
	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == lightPhare)
		{
			//lp.goUp = false;
			//lp.goDown  = true;
		}
	}
}