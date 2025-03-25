using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Great_FireBall : MonoBehaviour
{
    int golpe = 60;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.CompareTag("Enemigo"))
        {
            collision.gameObject.GetComponent<Enemigos>().RecibirGolpe(golpe);
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Suelo"))
        {
            Destroy(gameObject);
        }
    }
}
