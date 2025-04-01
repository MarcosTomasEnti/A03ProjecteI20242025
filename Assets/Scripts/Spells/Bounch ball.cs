using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounchball : MonoBehaviour
{
    public int Rebotes = 2;
    float golpe = 10;
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
            {
                Rebotes--;
                golpe += golpe * 1.25f;
            }
            else
                Destroy(gameObject.gameObject);
        }
        else if (collision.gameObject.CompareTag("MeleeEnemy"))
        {    
            golpe += golpe * 5f;
            collision.gameObject.GetComponent<MeleeEnemy>().RecibirGolpe(golpe);   
            
        }
        else if (collision.gameObject.CompareTag("RangedEnemy"))
        {                
            golpe += golpe + 5;
            collision.gameObject.GetComponent<RangedEnemy>().RecibirGolpe(golpe);
            
        }
    }
}
