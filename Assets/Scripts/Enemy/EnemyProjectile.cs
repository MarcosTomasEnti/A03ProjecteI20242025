using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float projectileSpeed = 15;
    float damage = 10;
    Rigidbody2D shotRB;

    BarraVida barraVida;

    // Start is called before the first frame update
    void Start()
    {
        barraVida = FindObjectOfType<BarraVida>();
        Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 shotDir = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y).normalized;
        shotRB = GetComponent<Rigidbody2D>();
        shotRB.velocity = new Vector2(shotDir.x * projectileSpeed, shotDir.y * projectileSpeed);
    }

    public void setDamage(float dmg)
    {
        damage = dmg;
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
            
            barraVida.VidaConsumida(damage);
            Destroy(gameObject.gameObject);
        }
    }
    
}