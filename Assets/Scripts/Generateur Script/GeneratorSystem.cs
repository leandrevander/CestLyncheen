using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GeneratorSystem : MonoBehaviour
{
    public int percentage = 100;

    public int            percentageWin = 3;
    public int            percentageLost  = 1;
    public GameObject     player;
    public bool           playerOnZone = false;
    public Coroutine      coroutineW;
    public Coroutine      coroutineL;
    public int            cooldown = 1;
    public SpriteRenderer sprite;
    
    
    public GameObject     sliderGO;
    
    private LightPhare _lightPhare;
    private GameObject lightPhareGO;
    
    private Image      fillImage;
    private GameObject fillGO;

    public TextMeshProUGUI textPercentage;

    public Color color;
    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = gameObject.GetComponent<SpriteRenderer>();
        
        
        fillGO    = GameObject.Find("Fill");
        fillImage = fillGO.GetComponent<Image>();
    }

    void Start()
    {
        sliderGO.SetActive(false);
        
    }

    
    void Update()
    {
        if (playerOnZone && coroutineW == null)
        {
            coroutineW    = StartCoroutine(CoroutineW());
            sprite.color  = Color.green;
            

        }
        else if  (!playerOnZone && coroutineL == null)
        {
            coroutineL      = StartCoroutine(CoroutineL());
            sprite.color    = Color.red;
            
        }

        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerOnZone = true;
            sliderGO.SetActive(true);
            if (percentage >= 25)
            {
                if (percentage >= 50)
                {
                    if (percentage >= 75)
                    {
                        textPercentage.color = Color.green;
                    }
                    else
                    {
                        textPercentage.color = Color.green;
                    }
                }
                else
                {
                    textPercentage.color = Color.yellow;
                }
            }
            else
            {
                textPercentage.color = Color.red;
            }

        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerOnZone = false;
            sliderGO.SetActive(false);

        }
    }

    IEnumerator CoroutineW()
    {
        if (percentage < 100)
        {
            percentage = percentage + percentageWin;
            
            if (percentage > 100)
            {
                percentage = 100;
            }
        }

        textPercentage.text = percentage + "%";
        yield return new WaitForSeconds(cooldown);
        coroutineW = null;
    }
    
    IEnumerator CoroutineL()
    {
        if (percentage > 0)
        {
            percentage = percentage - percentageLost; 

        }
        yield return new WaitForSeconds(cooldown);
        coroutineL = null;
    }
}
