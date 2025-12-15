using UnityEngine;

public class DescriptionItem : MonoBehaviour
{
    [SerializeField] AudioSource    select ;
    public           WeaponsManager weaponsManager;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void CloseGlowStickDescription()
    {
        select.Play();
        weaponsManager.glowStickDescription.SetActive(false);
        Time.timeScale = 1f;
    }
    public void CloseCameraDescription()
    {
        select.Play();
        weaponsManager.cameraDescription.SetActive(false);
        Time.timeScale = 1f;
    }
    public void CloseBulbDescription()
    {
        select.Play();
        weaponsManager.bulbDescription.SetActive(false);
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    
}
