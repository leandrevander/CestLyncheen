using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class PhareRotation : MonoBehaviour
{
    public float rotationSpeed = 45f;
    public float targetZ = 95f;
    
    public float lighthouseTimer = 2f;
    public float lighthouseRespawnDelay = 1f;

    private Light2D           light2D;
    private PolygonCollider2D polyCollider;
    private Vector3           startRotation;

    void Start()
    {
        light2D       = GetComponent<Light2D>();
        polyCollider  = GetComponent<PolygonCollider2D>();
        startRotation = transform.eulerAngles;
        
        StartCoroutine(RunCycle());
    }
    
    IEnumerator RunCycle()
    {
        while (true)
        {
            yield return RotateTo(targetZ);
            
            yield return new WaitForSeconds(lighthouseTimer);
            
            if (light2D) light2D.enabled           = false;
            if (polyCollider) polyCollider.enabled = false;
            
            yield return new WaitForSeconds(lighthouseRespawnDelay);

            // Remet la rota de base
            transform.eulerAngles = startRotation;
            
            if (light2D) light2D.enabled           = true;
            if (polyCollider) polyCollider.enabled = true;
        }
    }

    IEnumerator RotateTo(float targetAngle)
    {
        float currentZ                = transform.eulerAngles.z;
        if (currentZ > 180f) currentZ -= 360f;

        while (currentZ < targetAngle)
        {
            float step = rotationSpeed * Time.deltaTime;
            currentZ += step;
            if (currentZ > targetAngle)
                currentZ = targetAngle;

            transform.eulerAngles = new Vector3(0f, 0f, currentZ);
            yield return null;
        }
    }
}