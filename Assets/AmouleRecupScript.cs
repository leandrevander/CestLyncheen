using UnityEngine;

public class AmpouleRecupScript : MonoBehaviour
{
    [SerializeField] private AudioSource    recup;
    public                   GameObject     player;
    public                   WeaponsManager weaponsManager;
    public                   GameObject     ampoule;
    public                   Bulb           ampouleScript;
    public                   GameObject     recupAmpoule;
    public                   int            nombreAmpoule = 0;
    public                   UpgradeMenu    upgradeMenu;

    public GameObject barreEXPGO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player         = GameObject.FindWithTag("Player");
        weaponsManager = player.GetComponent<WeaponsManager>();
        barreEXPGO = GameObject.FindWithTag("BarreEXP");
        upgradeMenu    = barreEXPGO.GetComponent<UpgradeMenu>();

    }
    public void OnCollisionEnter2D(Collision2D other)
    {
       
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (weaponsManager.nombreAmpoule == 0)
                {
                    recup.Play();
                    ampoule.SetActive(true);
                    weaponsManager.UpgradeAmpoule();
                    weaponsManager.bulbDescription.SetActive(true);
                    Time.timeScale = 0f;
                }
                else
                {
                    recup.Play();
                    upgradeMenu.BulbUpgrade();
                }
                Destroy(gameObject); 
            }
            
            
        }

        // Update is called once per frame
    }
    void Update()
    {

    }

}