using UnityEngine;

public class WarningArrow : MonoBehaviour
{
    public bool timeIsRunning;
    public float time = 2;
    public SeagullAI parentSeagullScript;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        parentSeagullScript = transform.parent.gameObject.GetComponent<SeagullAI>();
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
