using System.Collections;
using UnityEngine;

public class ShadowBubble : MonoBehaviour
{

    public int            HealthZombie = 5;
    public WeaponsManager weaponsManager;
    public bool           isHittenByFlashlight = false;
    public Coroutine      coroutine;
    public GameObject     metaDataOrb;
    public GameObject     healthGO;

    int randomNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isHittenByFlashlight == true && coroutine == null)
        {
            coroutine = StartCoroutine(PerteDePv());
        }
    }

    IEnumerator PerteDePv()
    {
        HealthZombie = HealthZombie - weaponsManager.hitByFlashlight;
        if (HealthZombie <= 0)
        {
            Destroy(gameObject);
            randomNumber  = Random.Range(0, 2);
            if (randomNumber == 1)
            {
                Instantiate(metaDataOrb, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(healthGO, transform.position, transform.rotation);
            }
        }
        yield return new WaitForSeconds(1);
        coroutine            = null;
        isHittenByFlashlight = false;
    }
} 
