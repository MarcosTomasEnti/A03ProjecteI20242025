using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounchball : MonoBehaviour
{
    public int Rebotes = 2;
    int golpe = 25;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            if (Rebotes > 0)
                Rebotes--;
            else
                Destroy(gameObject.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemigo"))
        {
            if (Rebotes > 0)
            {
                Rebotes--;
                collision.gameObject.GetComponent<Enemigos>().RecibirGolpe(golpe);
            }
            else
            {
                collision.gameObject.GetComponent<Enemigos>().RecibirGolpe(golpe);
                Destroy(gameObject.gameObject);
            }
            
        }
    }
}
