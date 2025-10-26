using System.Collections;
using UnityEngine;

public class freezeEnnemi : MonoBehaviour
{
    public WeaponsManager wM;
    public Rigidbody2D ennemi_Rigidbody2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        wM = GameObject.Find("WeaponsManager").GetComponent<WeaponsManager>();
        ennemi_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        {
            while (wM.nombreAppareillePhoto >= 1)
                if (other.gameObject.CompareTag("Ennemi"))
                {

                    Debug.Log("Courroutune Flash lancé");
                    StartCoroutine(FreezeDuration());
                    Debug.Log("Courroutune Freeze lancé");

                }
        }
    }
    public IEnumerator FreezeDuration()

    {
        Debug.Log("Couroutine Freeze appelé");
        ennemi_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        Debug.Log("Ennemi gelé ! Enfin je crois...");
        yield return new WaitForSeconds(wM.freezeDuration);
        ennemi_Rigidbody2D.constraints = RigidbodyConstraints2D.None;
        Debug.Log("Ennemi dégelé ! Normalement...");
    }
}