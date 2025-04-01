using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseBox : MonoBehaviour
{
    public GameObject Enemy;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Bullet"))
        {
            GameObject enemy = Instantiate(Enemy.gameObject, transform.position, transform.rotation);
            Destroy(gameObject.gameObject);
        }
        
    }
}
