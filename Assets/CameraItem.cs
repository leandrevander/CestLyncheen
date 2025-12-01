using UnityEngine;

public class CameraItem : MonoBehaviour

{
    public GameObject     player;
    public WeaponsManager weaponsManager;
    
    public UpgradeMenu upgradeMenu;

    public GameObject barreEXPGO;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player         = GameObject.FindGameObjectWithTag("Player");
        weaponsManager = GameObject.FindWithTag("Player").GetComponent<WeaponsManager>();
        barreEXPGO     = GameObject.FindWithTag("BarreEXP");
        upgradeMenu    = barreEXPGO.GetComponent<UpgradeMenu>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (weaponsManager.nombreAppareillePhoto == 0)
            {
                weaponsManager.AgmentationDuNiveauAppareillePhoto();
                weaponsManager.haveCamera = true;

  
            }
            else
            {
              upgradeMenu.CameraUpgrade();  
            }
            Destroy(gameObject);
            
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
