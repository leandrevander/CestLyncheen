using UnityEngine;

public class StreetLampRecup : MonoBehaviour
{
    public WeaponsManager weaponsManager;
    public GameObject     player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        weaponsManager = player.GetComponent<WeaponsManager>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            weaponsManager.UnlockGlowstick();
            Destroy(gameObject);
            
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
}
