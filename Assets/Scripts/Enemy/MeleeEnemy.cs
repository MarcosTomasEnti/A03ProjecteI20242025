using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{

    public GameObject magician;
    public Rigidbody2D rb;
    public float vida = 100;
    public float damage = 10;
    public float attackDelay = 2;
    float attackTimer = 0;
    public float acceleration = 5;
    public float maxSpeed = 10;
    public bool playerDetected = false;
    bool playerInRange = false;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        magician = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if(playerDetected)
        {
            FollowPlayer();

            if(attackTimer <= 0)
            {
                attackTimer = attackDelay;

            }
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

    public void efectoStun(float stun)
    {

        acceleration = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector2 playerDir = new Vector2(transform.position.x - magician.transform.position.x, transform.position.y - magician.transform.position.y).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDir);
        if (collision.CompareTag("Player") && hit.collider.CompareTag("Player"))
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerDetected = false;
    }

}
