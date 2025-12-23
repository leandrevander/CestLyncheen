using UnityEngine;

public class FlashlightRecupScript : MonoBehaviour
{
	[SerializeField] private AudioSource    recup;
	public                   GameObject     player;
	public                   WeaponsManager weaponsManager;
	
	public                   UpgradeMenu    upgradeMenu;

	public GameObject barreEXPGO;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		player         = GameObject.FindWithTag("Player");
		weaponsManager = player.GetComponent<WeaponsManager>();
		barreEXPGO     = GameObject.FindWithTag("BarreEXP");
		upgradeMenu    = barreEXPGO.GetComponent<UpgradeMenu>();

	}
	public void OnCollisionEnter2D(Collision2D other)
	{
       
		{
			if (other.gameObject.CompareTag("Player"))
			{
				upgradeMenu.FlashlightUpgrade();
				Destroy(gameObject); 
			}
            
            
		}

		// Update is called once per frame
	}
	void Update()
	{

	}

}