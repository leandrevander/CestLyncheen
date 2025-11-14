using UnityEngine;

public class CameraItem : MonoBehaviour

{
    public WeaponsManager weaponsManager;
    public UpgradeMenu upgradeMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            weaponsManager.AgmentationDuNiveauAppareillePhoto();
            Destroy(gameObject);
            weaponsManager.haveCamera = true;
            upgradeMenu.mesUpgradesList.Add(upgradeMenu.cameraUpgrade);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
