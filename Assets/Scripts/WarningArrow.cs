using UnityEngine;

public class WarningArrow : MonoBehaviour
{
    public bool timeIsRunning;
    public float time = 2;
    public SeagullAIV2 parentSeagullScript;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        parentSeagullScript = transform.parent.gameObject.GetComponent<SeagullAIV2>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        timeIsRunning = true;
        
        if (timeIsRunning)
        {
            if (time > 0)
            {
                time -=  Time.deltaTime;
            }
            else
            {
                timeIsRunning = false;
                parentSeagullScript.warningOver = true;
                spriteRenderer.enabled = false;
            }
        }
    }
}
