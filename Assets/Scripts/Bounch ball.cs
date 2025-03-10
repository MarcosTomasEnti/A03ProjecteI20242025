using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounchball : MonoBehaviour
{
    public int Rebotes = 2;
    private bool hitEnemy = false;
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
        if ((collision.gameObject.CompareTag("Suelo") && Rebotes > 0))
        {
            Rebotes--;
        }
        else if(collision.gameObject.CompareTag("Enemigo") || (collision.gameObject.CompareTag("Suelo") && Rebotes == 0))
        {
            Destroy(gameObject);
        }
    }
}
