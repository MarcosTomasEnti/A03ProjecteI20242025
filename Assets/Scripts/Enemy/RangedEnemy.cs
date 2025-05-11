using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField]
    LayerMask includeLayers;
    public GameObject BubbleDamage;
    public GameObject projectile;
    public GameObject Coin;
    public float projectileSpeed = 15;

    public GameObject magician;
    public Rigidbody2D rb;
    public float vida = 100;
    public float damage = 10;
    public float attackDelay = 5;
    public float visionRange = 50;

    float attackTimer;


    public float acceleration = 5;
    public float maxSpeed = 10;

    bool playerDetected = false;
    bool inRange = false;

    CircleCollider2D hitBox;

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        
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
        if (sprite.color.a < 1)
        {

            sprite.color += new Color(0, 0, 0, 2 * Time.deltaTime);
        }
        else if (sprite.color.a > 1)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
        }


        Vector2 playerDir = new Vector2(transform.position.x - magician.transform.position.x, transform.position.y - magician.transform.position.y).normalized;
        float playerDist = Vector2.Distance(transform.position, magician.transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -playerDir, visionRange, includeLayers);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                playerDetected = true;


                if ( inRange)
                { 
                    fleeFromPlayer();
                }
                else
                {
                    rb.velocity *= new Vector2(0.99f, 0.99f);
                }
            }
            else
            {
                rb.velocity *= new Vector2(0.99f, 0.99f);
                playerDetected = false;
            }
        }
        else
        {
            playerDetected = false;
        }

        if(playerDetected && !inRange)
        {
            
            attackTimer += Time.deltaTime;
            if (attackTimer > attackDelay)
            {
                attackTimer = 0;
                GameObject Projectile = Instantiate(projectile.gameObject, transform.position, transform.rotation);
                Vector2 shotDir = new Vector2(magician.transform.position.x - transform.position.x, magician.transform.position.y - transform.position.y).normalized;
                Rigidbody2D shotRB = projectile.GetComponent<Rigidbody2D>();
                shotRB.velocity = new Vector2(shotDir.x * projectileSpeed, shotDir.y * projectileSpeed);
                
                projectile.GetComponent<EnemyProjectile>().setDamage(damage);

            }
        }







    }

    void fleeFromPlayer()
    {
        Vector2 fpos = Vector2.MoveTowards(transform.position, magician.transform.position, acceleration * Time.deltaTime);
        rb.velocity -= fpos - (Vector2)transform.position;

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
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);

        vida -= golpe;
        if (vida <= 0)
        {
            int randomCoin = Random.Range(0, 5);
            if (randomCoin <= 3)
            {
                GameObject coin = Instantiate(Coin.gameObject, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
        Debug.Log("Vida Restante: " + vida);
    }

    public void efectoStun(float stun)
    {

        acceleration = 0;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }

}
