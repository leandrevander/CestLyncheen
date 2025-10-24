using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float remainingTime;

    public GameObject sceneManager;
    
    private WinMenu winMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winMenu = sceneManager.GetComponent<WinMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)
        {
            remainingTime = 0;
            winMenu.win =  true;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
}
