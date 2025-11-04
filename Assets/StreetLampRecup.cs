using UnityEngine;

public class StreetLampRecup : MonoBehaviour
{
    public WeaponsManager weaponsManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            weaponsManager.GlowStickRecup = true;
            Destroy(gameObject);
            
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
}
