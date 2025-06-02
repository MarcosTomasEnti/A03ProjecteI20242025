
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseBox : MonoBehaviour
{
    public GameObject meleeEnemy;
    public GameObject Heart;
    public GameObject rangedEnemy;
    public GameObject Coin;
    public GameObject PotionMana;
    public GameObject Fly;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
   

         if (collision.gameObject.CompareTag("Bullet"))
        {
            int goodLuck = Random.Range(0, 7);
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
            else if ((goodLuck == 5))
            {
                GameObject potionMana = Instantiate(PotionMana.gameObject, transform.position, transform.rotation);
                Destroy(gameObject.gameObject);
            }
            else if ((goodLuck == 6))
            {
                int flyChance = Random.Range(1, 6);
                for (int i = 0; i < flyChance; i++)
                {
                    GameObject fly = Instantiate(Fly.gameObject, transform.position, transform.rotation);
                }
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
            float goodLuck = Random.Range(0, 120);//hearts: 10% enemies: 30% coins: 10% mana potion: 10%
            Debug.Log(goodLuck);

            if (goodLuck >= 0 && goodLuck < 10)
            {
                GameObject enemy = Instantiate(meleeEnemy.gameObject, transform.position, transform.rotation);
                Destroy(gameObject.gameObject);
            }
            else if (goodLuck >= 10 && goodLuck < 20)
            {
                GameObject heart = Instantiate(Heart.gameObject, transform.position, transform.rotation);
                Destroy(gameObject.gameObject);
            }
            else if (goodLuck >= 20 && goodLuck < 30)
            {
                GameObject enemy = Instantiate(rangedEnemy.gameObject, transform.position, transform.rotation);
                Destroy(gameObject.gameObject);
            }
            else if (goodLuck >= 30 && goodLuck < 40)
            {
                GameObject coin = Instantiate(Coin.gameObject, transform.position, transform.rotation);
                Destroy(gameObject.gameObject);
            }
            else if (goodLuck >= 40 && goodLuck < 50)
            {
                GameObject potionMana = Instantiate(PotionMana.gameObject, transform.position, transform.rotation);
                Destroy(gameObject.gameObject);
            }
            else if (goodLuck >= 50 && goodLuck < 60)
            {
                int flyChance = Random.Range(3, 6);
                for (int i = 0; i < flyChance; i++)
                {
                    GameObject fly = Instantiate(Fly.gameObject, transform.position, transform.rotation);
                }
                Destroy(gameObject.gameObject);
            }
            else
            {
                Destroy(gameObject.gameObject);
            }
        }

    }



}
