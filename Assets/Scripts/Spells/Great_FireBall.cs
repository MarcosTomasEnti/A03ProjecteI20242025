using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Great_FireBall : MonoBehaviour
{
    public int golpe = 60;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6f);
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.CompareTag("MeleeEnemy"))
        {
            collision.gameObject.GetComponent<MeleeEnemy>().RecibirGolpe(golpe);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("TrainEnemy"))
        {
            collision.gameObject.GetComponent<TrainEnemy>().RecibirGolpe(golpe);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("RangedEnemy"))
        {
            collision.gameObject.GetComponent<RangedEnemy>().RecibirGolpe(golpe);
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Suelo") || collision.gameObject.CompareTag("Puerta"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Obstaculos"))
        {
            Destroy(gameObject);
        }
    }
}
