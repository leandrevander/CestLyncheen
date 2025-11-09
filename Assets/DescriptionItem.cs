using UnityEngine;

public class DescriptionItem : MonoBehaviour
{
    public WeaponsManager weaponsManager;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void CloseGlowStickDescription()
    {
        weaponsManager.glowStickDescription.SetActive(false);
        Time.timeScale = 1f;
    }
    public void CloseCameraDescription()
    {
        weaponsManager.cameraDescription.SetActive(false);
        Time.timeScale = 1f;
    }
    public void CloseBulbDescription()
    {
        weaponsManager.bulbDescription.SetActive(false);
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    
}
