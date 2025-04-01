using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float projectileSpeed = 15;
    int golpe = 40;
    Rigidbody2D shotRB;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 shotDir = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y).normalized;
        shotRB = GetComponent<Rigidbody2D>();
        shotRB.velocity = new Vector2(shotDir.x * projectileSpeed, shotDir.y * projectileSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit!");
            Destroy(gameObject.gameObject);
        }
    }
    
}