using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic : MonoBehaviour
{

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
        if (collision.gameObject.CompareTag("Suelo") || collision.gameObject.CompareTag("Enemigo"))        
        {
            if (collision.gameObject.CompareTag("Enemigo"))
            {
                collision.gameObject.GetComponent<Enemigos>().DamageEnemy(40);
            }            
            Destroy(gameObject);
        }
    }
}
