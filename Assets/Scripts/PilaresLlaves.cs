using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilaresLlaves : MonoBehaviour
{

    public bool activado = false;
    public GameObject llaves;

 


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            llaves.SetActive(true);
            activado = true;
            Destroy(collision.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            activado = true;
            llaves.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}