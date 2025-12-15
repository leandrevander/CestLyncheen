using UnityEngine;

public class RemoveFromList : MonoBehaviour
{
    public EnnemiesDetector detector;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        detector = GameObject.FindGameObjectWithTag("Detector").GetComponent<EnnemiesDetector>();
    }
    // Update is called once per frame
    private void OnDestroy()
    {
	    detector.enemies.Remove(this.gameObject);
    }
}
