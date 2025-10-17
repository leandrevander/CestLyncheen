using System.Collections;
using UnityEngine;

public class GenerateurScript : MonoBehaviour
{
    public int pourcentage = 100;

    public int        pourcentage_gagner = 1;
    public int        pourcentage_perdu = 1;
    public GameObject player;
    public bool       playerOnZone = false;
    public Coroutine  coroutineW;
    public Coroutine  coroutineL;
    public int        cooldown = 1;
    public SpriteRenderer  sprite;

    public Color color;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnZone && coroutineW == null)
        {
            coroutineW = StartCoroutine(CoroutineW());
            sprite.color =  Color.green;
        }
        else if  (!playerOnZone && coroutineL == null)
        {
            coroutineL   = StartCoroutine(CoroutineL());
            sprite.color = Color.red;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("cacaboudin");
            playerOnZone = true;
        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("pipipuepue");
            playerOnZone = false;
        }
    }

    IEnumerator CoroutineW()
    {
        if (pourcentage < 100)
        {
            pourcentage = pourcentage + pourcentage_gagner;
        }
        yield return new WaitForSeconds(cooldown);
        coroutineW = null;
    }
    
    IEnumerator CoroutineL()
    {
        if (pourcentage > 0)
        {
            pourcentage = pourcentage - pourcentage_perdu; 

        }
        yield return new WaitForSeconds(cooldown);
        coroutineL = null;
    }
}
