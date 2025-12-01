using UnityEngine;

public class CameraItem : MonoBehaviour

{
    [SerializeField] AudioSource      recup;
    public           GameObject     player;
    public           WeaponsManager weaponsManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player         = GameObject.FindGameObjectWithTag("Player");
        weaponsManager = GameObject.FindWithTag("Player").GetComponent<WeaponsManager>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            recup.Play();
            weaponsManager.AgmentationDuNiveauAppareillePhoto();
            Destroy(gameObject);
            weaponsManager.haveCamera = true;
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
