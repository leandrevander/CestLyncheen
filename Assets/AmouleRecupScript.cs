using UnityEngine;

public class AmpouleRecupScript : MonoBehaviour
{
    public GameObject     player;
    public WeaponsManager weaponsManager;
    public GameObject     ampoule;
    public Bulb           ampouleScript;
    public GameObject     recupAmpoule;
    public int            nombreAmpoule = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        weaponsManager = player.GetComponent<WeaponsManager>();

    }
    public void OnCollisionEnter2D(Collision2D other)
    {
       
        {
            if (other.gameObject.CompareTag("Player"))
            {
                ampoule.SetActive(true);
                weaponsManager.UpgradeAmpoule();
                weaponsManager.bulbDescription.SetActive(true);
                Time.timeScale = 0f;
                Destroy(gameObject); 
            }
            
            
        }

        // Update is called once per frame
    }
    void Update()
    {

    }

}