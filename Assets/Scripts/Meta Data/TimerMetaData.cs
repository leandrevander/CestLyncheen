using UnityEngine;

public class TimerMetaData : MonoBehaviour
{
    public float timer;
    public int minutes = 0;

    public int metaRessourceBonus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 60)
        {
            timer = 0;
            minutes++;
            metaRessourceBonus = 5 * (minutes * minutes);
        }
    }
}
