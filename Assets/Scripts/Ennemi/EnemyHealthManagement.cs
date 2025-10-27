using System.Collections;
using JetBrains.Annotations;
using Player_Scripts;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealthManagement : MonoBehaviour
{
    public  bool       IsHitten     = false;
    public  int        HealthZombie = 5;
    public  int        pvperdu;
    private Coroutine  coroutine;
    public  GameObject experiencepointPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsHitten && coroutine == null)
        {
            coroutine = StartCoroutine(PerteDePv());
        }
    }
    
    IEnumerator PerteDePv()
    {

        HealthZombie = HealthZombie - pvperdu;
        if (HealthZombie <= 0)
        {
            Destroy(gameObject);
            Instantiate(experiencepointPrefab, transform.position, transform.rotation);
        }

        Debug.Log("PV perdu");
        IsHitten = false;
        yield return new WaitForSeconds(1);
        coroutine = null;
    }
}
