using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{

    public GameObject magician;
    public Rigidbody2D rb;
    public float vida = 100;
    public float damage = 20;
    public float attackDelay = 2;
    public float activeAttackTime = 0.5f;
    float attackTimer;
    int stopOnAttack = 1;
    
    public float acceleration = 5;
    public float maxSpeed = 10;
    public float sightDistance = 25;
    bool playerDetected = false;
    bool attacking = false;
    CircleCollider2D hitBox;

    SpriteRenderer sprite;

    BarraVida barraVida;

    // Start is called before the first frame update
    void Start()
    {
        barraVida = FindObjectOfType<BarraVida>();

        attackTimer = attackDelay;
        rb = GetComponent<Rigidbody2D>();
        magician = GameObject.FindGameObjectWithTag("Player");
        hitBox = GetComponent<CircleCollider2D>();
        hitBox.enabled = true;

        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       


        Vector2 playerDir = new Vector2(transform.position.x - magician.transform.position.x, transform.position.y - magician.transform.position.y).normalized;
        float playerDist = Vector2.Distance(transform.position, magician.transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -playerDir, Mathf.Infinity, ~LayerMask.GetMask("Enemy"));

        if (hit.collider != null)
        {
            if(hit.collider.CompareTag("Player") && playerDist < sightDistance)
            {
                FollowPlayer();
                playerDetected = true;
            }
            else
            {
                rb.velocity *= new Vector2(0.999f, 0.999f);
                playerDetected = false;
            }
        }

        attackTimer += Time.deltaTime;
        if(playerDetected && playerDist < hitBox.radius && attackTimer > attackDelay)
        {
            attackTimer = 0;
            attacking = true;
        }
        if(attackTimer > activeAttackTime && attackTimer <= attackDelay)
        {
            attacking = false;
        }



    }

    void FollowPlayer()
    {
        Vector2 fpos = Vector2.MoveTowards(transform.position, magician.transform.position, acceleration * Time.deltaTime);
        rb.velocity += fpos - (Vector2)transform.position;
        rb.velocity *= stopOnAttack;
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



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && attacking == true)
        {
            {
                attacking = false;  
                Debug.Log("hitPlayer!");
                barraVida.VidaConsumida(damage);
                stopOnAttack = 0;



            }
        }
        else if(collision.CompareTag("Player") && attacking == false)
        {


        }
        if (collision.CompareTag("Player"))
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + (Time.deltaTime * 1500));
        }
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            {
                Debug.Log("PlayerLeft");
                stopOnAttack = 1;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

}
