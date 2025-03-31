
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseBox : MonoBehaviour
{
    public GameObject Enemy;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entro");

         if (collision.gameObject.CompareTag("Bullet"))
        {
            int goodLuck = Random.Range(0, 2);

            if (goodLuck == 1)
            {
                GameObject enemy = Instantiate(Enemy.gameObject, transform.position, transform.rotation);
                Destroy(gameObject.gameObject);
            }
            else
            {
                Destroy(gameObject.gameObject);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entro2");
        if (collision.gameObject.CompareTag("Bullet"))
        {
            int goodLuck = Random.Range(0, 2);
            Debug.Log(goodLuck);
            if (goodLuck == 1)
            {
                GameObject enemy = Instantiate(Enemy.gameObject, transform.position, transform.rotation);
                Destroy(gameObject.gameObject);
            }
            else
            {
                Destroy(gameObject.gameObject);
            }
        }

    }



}
