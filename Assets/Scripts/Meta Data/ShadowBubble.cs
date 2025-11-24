using System.Collections;
using UnityEngine;

public class ShadowBubble : MonoBehaviour
{

    public int            HealthZombie = 5;
    public WeaponsManager weaponsManager;
    public bool           isHittenByFlashlight = false;
    public Coroutine      coroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator PerteDePv()
    {


        HealthZombie = HealthZombie - weaponsManager.hitByFlashlight;
        if (HealthZombie <= 0)
        {
            Destroy(gameObject);
            //Instantiate(experiencepointPrefab, transform.position, transform.rotation);
        }

        yield return new WaitForSeconds(1);
        coroutine            = null;
        isHittenByFlashlight = false;
    }
} 
