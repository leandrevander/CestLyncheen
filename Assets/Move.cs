using UnityEngine;


public class Move : MonoBehaviour
{
    public GameObject Avatar;

    // Start is called before the first frame update

    private Vector2 direction = new Vector2(2, 0);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector2.left * Time.deltaTime);
            Debug.Log("La touche Q à bien était presser");
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime);
            Debug.Log("D à bien était presser");
        }

        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector2.left * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * Time.deltaTime);
            Debug.Log("S à bien était presser");
        }
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector2.up * Time.deltaTime);
            Debug.Log("Z à bien était presser");
        }
    }
}

