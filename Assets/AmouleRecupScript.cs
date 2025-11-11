using UnityEngine;

public class AmpouleRecupScript : MonoBehaviour
{
    public WeaponsManager weaponsManager;
    public GameObject ampoule;
    public Bulb ampouleScript;
    public GameObject recupAmpoule;
    public int nombreAmpoule = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void OnCollisionEnter2D(Collision2D other)
    {
       
        {
            ampoule.SetActive(true);
            weaponsManager.UpgradeAmpoule();
            weaponsManager.bulbDescription.SetActive(true);
            Time.timeScale = 0f;
            Destroy(gameObject);
        }

        // Update is called once per frame
    }
    void Update()
    {

    }

}