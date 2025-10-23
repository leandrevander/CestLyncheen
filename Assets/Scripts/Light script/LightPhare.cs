using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class LightPhare : MonoBehaviour
{
    

    public GeneratorSystem generator1;
    public GeneratorSystem generator2;
    public int             generatorsNumber;
    
    public  int              totalPercentage;
    
    public  int              lightPhareSpeed;
    private Rigidbody2D      rb;
    private Light2D          light;
    

    public int level1 = 10 ;
    public int level2 = 25;
    public int level3 = 50;
    public int level4 = 82;
    
    private Vector2 directionUp = new Vector2(0, 1);
    private Vector2 directionDown  = new Vector2(0, -1);
    public  bool    goDown = true;
    public  bool    goUp;
    


    private void Awake()
    {
        rb         = GetComponent<Rigidbody2D>();
        light      = gameObject.GetComponent<Light2D>();
        level1 = 10 * generatorsNumber;
        level2 = 25 * generatorsNumber;
        level3 = 50 * generatorsNumber;
        level4 = 82 * generatorsNumber;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (goDown)
        {
            rb.linearVelocity = directionDown * lightPhareSpeed;

        }
        if (goUp)
        {
            rb.linearVelocity = directionUp * lightPhareSpeed;

        }
    }

    // Update is called once per frame
    void Update()
    {
        totalPercentage = generator1.percentage +  generator2.percentage;

        if (totalPercentage >= level1)
        {
            if (totalPercentage >= level2)
            {
                if (totalPercentage >= level3)
                {
                    if (totalPercentage >= level4)
                    {
                        //Debug.Log("Phare niveau 4");
                        lightPhareSpeed    = 4;
                        
                        
                    }
                    else
                    {
                        //Debug.Log("Phare niveau 3");
                        lightPhareSpeed    = 3;
                        
                    }
                }
                else
                {
                    //Debug.Log("Phare niveau 2");
                    lightPhareSpeed    = 2;
                    
                }
            }
            else
            {
                //Debug.Log("Phare niveau 1");
                light.enabled      = true;
                lightPhareSpeed    = 1;
                
            }
            
        }
        else
        {
            //Debug.Log("Phare niveau 0");
            light.enabled = false;
            lightPhareSpeed = 0;
        }
    }
}
