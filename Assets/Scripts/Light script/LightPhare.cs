using UnityEngine;

public class LightPhare : MonoBehaviour
{
    public GameObject generateur1;
    public GameObject generateur2;

    public int   pourcentage_generateur1;
    public int   pourcentage_generateur2;
    public int[] array = new int[2];
    public int   pourcentage_totale;
    public int   lightPhareSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pourcentage_generateur1 = generateur1.GetComponent<GenerateurScript>().pourcentage;
        pourcentage_generateur2 = generateur2.GetComponent<GenerateurScript>().pourcentage;
        array[0] = pourcentage_generateur1;
        array[1] = pourcentage_generateur2;

        for (int i = 0; i < array.Length; i++)
        {
            pourcentage_totale += array[i];
        }
        //if (pourcentage_totale >= )
    }
}
