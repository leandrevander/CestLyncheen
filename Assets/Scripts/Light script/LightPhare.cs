using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class LightPhare : MonoBehaviour
{
    

    public GeneratorSystem generator1;
    public GeneratorSystem generator2;
    public GeneratorSystem generator3;
    public GeneratorSystem generator4;
    public int             generatorsNumber;
    
    public  int              totalPercentage;
    
    public  int              lightPhareSpeed;
    private Rigidbody2D      rb;
    private Light2D          light;
    

    public float level1 = 16f;
    public float level2 = 12f;
    public float level3 = 8f;
    public float level4 = 4f;
    
    public PhareRotation phareRotation;
    
    


    private void Awake()
    {
        rb         = GetComponent<Rigidbody2D>();
        light      = gameObject.GetComponent<Light2D>();
        level1 = 10 * generatorsNumber;
        level2 = 25 * generatorsNumber;
        level3 = 50 * generatorsNumber;
        level4 = 82 * generatorsNumber;
    }

    // Update is called once per frame
    void Update()
    {
        totalPercentage = generator1.percentage +  generator2.percentage + generator3.percentage + generator4.percentage;

        if (totalPercentage >= level1)
        {
            if (totalPercentage >= level2)
            {
                if (totalPercentage >= level3)
                {
                    if (totalPercentage >= level4)
                    {
                        //Debug.Log("Phare niveau 4");
                        phareRotation.lighthouseRespawnDelay = level4;

                    }
                    else
                    {
                        //Debug.Log("Phare niveau 3");
                        phareRotation.lighthouseRespawnDelay = level3;
                        
                    }
                }
                else
                {
                    //Debug.Log("Phare niveau 2");
                    phareRotation.lighthouseRespawnDelay = level2;
                    
                }
            }
            else
            {
                //Debug.Log("Phare niveau 1");
                light.enabled                        = true;
                phareRotation.lighthouseRespawnDelay = level1;
                
            }
            
        }
        else
        {
            //Debug.Log("Phare niveau 0");
            light.enabled                        = false;
            phareRotation.lighthouseRespawnDelay = 1000f;
        }
    }
}
