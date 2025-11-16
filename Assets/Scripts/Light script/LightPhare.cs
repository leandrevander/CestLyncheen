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
    

    public float level1 = 50f;
    public float level2 = 150f;
    public float level3 = 200f;
    public float level4 = 300f;
    
    public float phareRespawnLevel1 = 8f;
    public float phareRespawnLevel2 = 6f;
    public float phareRespawnLevel3 = 4f;
    public float phareRespawnLevel4 = 2f;

    
    public PhareRotation phareRotation;


    private void Awake()
    {
        rb         = GetComponent<Rigidbody2D>();
        light      = gameObject.GetComponent<Light2D>();
    }

    // Update is called once per frame
    
    
    void Update()
    {
        totalPercentage = generator1.percentage +  generator2.percentage + generator3.percentage + generator4.percentage;
        //Debug.Log($"total percentage = {totalPercentage}");


        if (totalPercentage >= level4)
        {
            phareRotation.lighthouseRespawnDelay = phareRespawnLevel4;
            return;
        }

        if (totalPercentage >= level3)
        {
            phareRotation.lighthouseRespawnDelay = phareRespawnLevel3;
            return;
        }

        if (totalPercentage >= level2)
        {
            phareRotation.lighthouseRespawnDelay = phareRespawnLevel2;
            return;
        }

        if (totalPercentage >= level1)
        {
            phareRotation.lighthouseRespawnDelay = phareRespawnLevel1;
            return;
        }
        else
        {
            //light.enabled                        = false;
            phareRotation.lighthouseRespawnDelay = 30f;
        }
        
        /*if (totalPercentage >= level1)
        {
            if (totalPercentage >= level2)
            {
                if (totalPercentage >= level3)
                {
                    if (totalPercentage >= level4)
                    {
                        //Debug.Log("Phare niveau 4");
                        phareRotation.lighthouseRespawnDelay = phareRespawnLevel4;
                       
                    }
                    else
                    {
                        //Debug.Log("Phare niveau 3");
                        phareRotation.lighthouseRespawnDelay = phareRespawnLevel3;
                    }
                }
                else
                {
                    //Debug.Log("Phare niveau 2");
                    phareRotation.lighthouseRespawnDelay = phareRespawnLevel2;
                    
                }
            }
            else
            {
                //Debug.Log("Phare niveau 1");
                light.enabled                        = true;
                phareRotation.lighthouseRespawnDelay = phareRespawnLevel1;
                
            }
            
        }
        else
        {
            //Debug.Log("Phare niveau 0");
            light.enabled                        = false;
            phareRotation.lighthouseRespawnDelay = 1000f;
        }*/
        
    }
}
