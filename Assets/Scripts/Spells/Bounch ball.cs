using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounchball : MonoBehaviour
{
    public int Rebotes = 2;
    public float golpe = 10;
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
        if (collision.gameObject.CompareTag("Suelo") || collision.gameObject.CompareTag("Puerta"))
        {
            if (Rebotes > 0)
            {
                Rebotes--;
                golpe += 2.5f;
            }
            else
                Destroy(gameObject.gameObject);
        }
        else if (collision.gameObject.CompareTag("MeleeEnemy"))
        {    
            
            collision.gameObject.GetComponent<MeleeEnemy>().RecibirGolpe(golpe);
            golpe +=  5;
        }
        else if (collision.gameObject.CompareTag("TrainEnemy"))
        {
            collision.gameObject.GetComponent<TrainEnemy>().RecibirGolpe(golpe);
        }
        else if (collision.gameObject.CompareTag("RangedEnemy"))
        {                
            
            collision.gameObject.GetComponent<RangedEnemy>().RecibirGolpe(golpe);
            golpe += 5;
        }
    }
}
