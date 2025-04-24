
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseBox : MonoBehaviour
{
    public GameObject meleeEnemy;
    public GameObject Heart;
    public GameObject rangedEnemy;
    public GameObject Coin;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
   

         if (collision.gameObject.CompareTag("Bullet"))
        {
            int goodLuck = Random.Range(0, 5);
            Debug.Log(goodLuck);

            if (goodLuck == 1)
            {
                GameObject enemy = Instantiate(meleeEnemy.gameObject, transform.position, transform.rotation);
                Destroy(gameObject.gameObject);
            }
            else if (goodLuck == 2)
            {
                GameObject heart = Instantiate(Heart.gameObject, transform.position, transform.rotation);
                Destroy(gameObject.gameObject);
            }
            else if(goodLuck == 3)
            {
                GameObject enemy = Instantiate(rangedEnemy.gameObject, transform.position, transform.rotation);
                Destroy(gameObject.gameObject);
            }
            else if ((goodLuck == 4))
            {
                GameObject coin = Instantiate(Coin.gameObject, transform.position, transform.rotation);
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
       
        if (collision.gameObject.CompareTag("Bullet"))
        {
            int goodLuck = Random.Range(0, 3);
           
          
            if (goodLuck == 1)
            {
                GameObject enemy = Instantiate(meleeEnemy.gameObject, transform.position, transform.rotation);
                Destroy(gameObject.gameObject);
            }
            else if (goodLuck == 2)
            {
                GameObject heart = Instantiate(Heart.gameObject, transform.position, transform.rotation);
                Destroy(gameObject.gameObject);
            }
            else
            {
                Destroy(gameObject.gameObject);
            }
        }

    }



}
