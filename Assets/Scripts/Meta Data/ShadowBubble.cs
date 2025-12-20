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
    public GameObject damageEffect;

    int randomNumber;
    
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
        damageEffect.SetActive(true);
        yield return new WaitForSeconds(1);
        damageEffect.SetActive(false);
        coroutine            = null;
        isHittenByFlashlight = false;
    }
} 
