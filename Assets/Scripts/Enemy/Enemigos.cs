using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public GameObject BubbleDamage;
    public GameObject magician;
    public Rigidbody2D rb;
    public float vida = 100;
    public float acceleration = 5;
    public float maxSpeed = 10;
    public bool playerDetected = false;



    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        magician = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected)
        {
            FollowPlayer();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* if (collision.gameObject.CompareTag("Bullet"))
         {
             playerDetected = true;
             if (collision.gameObject.name == "FireBall(Clone)")
             {
                 vida -= 40;
             }
             else if(collision.gameObject.name == "Bounch ball Variant(Clone)")
             {
                 vida -= 25;
             }


             Debug.Log("Vida restante: " + vida);
         }
         if (vida <= 0)
         {
             Destroy(gameObject);
         }*/
    }
    public void OnTriggerEnter2D(Collider2D Vision)
    {
        if (Vision.gameObject.CompareTag("Player"))
        {
            playerDetected = true;
        }
    }
    void FollowPlayer()
    {
        Vector2 fpos = Vector2.MoveTowards(transform.position, magician.transform.position, acceleration * Time.deltaTime);
        rb.velocity += fpos - (Vector2)transform.position;
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.y > maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxSpeed);
        }
        else if (rb.velocity.y < -maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, -maxSpeed);
        }
    }

    public void RecibirGolpe(float golpe)
    {
        vida -= golpe;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Vida Restante: " + vida);
    }

    public void efectoStun (float stun)
    {
        
        acceleration = 0;    
    }
}