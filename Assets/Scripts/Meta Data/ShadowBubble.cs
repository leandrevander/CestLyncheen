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
    public GameObject     damageEffect;
    public GameObject     spawnLocation;
    GameObject            player;
    public GameObject     ShadowBubbleGO;

    int randomNumber;

    void Start()
    {
        weaponsManager = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponsManager>();
    }
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
            Destroy(ShadowBubbleGO);
            //randomNumber  = Random.Range(0, 2);
            randomNumber = 1;
            if (randomNumber == 1)
            {
                Instantiate(metaDataOrb, spawnLocation.transform.position, transform.rotation);
            }
            else
            {
                Instantiate(healthGO, spawnLocation.transform.position, transform.rotation);
            }
        }
        damageEffect.SetActive(true);
        yield return new WaitForSeconds(1);
        damageEffect.SetActive(false);
        coroutine            = null;
        isHittenByFlashlight = false;
    }
} 
