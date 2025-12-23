using UnityEngine;

public class StreetLampRecup : MonoBehaviour
{
    [SerializeField] private AudioSource      recup;
    public                   WeaponsManager weaponsManager;
    public                   GameObject     player;
    public                   UpgradeMenu    upgradeMenu;

    public GameObject barreEXPGO;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player         = GameObject.FindGameObjectWithTag("Player");
        weaponsManager = player.GetComponent<WeaponsManager>();
        barreEXPGO     = GameObject.FindWithTag("BarreEXP");
        upgradeMenu    = barreEXPGO.GetComponent<UpgradeMenu>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            recup.Play();

            if (weaponsManager.GlowStickRecup == false)
            {
                weaponsManager.UnlockGlowstick();
 
            }
            else
            {
              upgradeMenu.GlowStickUpgrade();  
            }
            Destroy(gameObject,0.1f);
            
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
}
