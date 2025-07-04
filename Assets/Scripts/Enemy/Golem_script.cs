using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Golem_script : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField]
    LayerMask includeLayers;
    [SerializeField] private Animator animator_p;
    public GameObject damageOutput;
    [SerializedField] 
    public GameObject firehit;
    [SerializeField]
    CapsuleCollider2D capsuleCol;
    [SerializeField]
    CircleCollider2D circleCol;
    public GameObject magician;
    public GameObject Coin;
    public Rigidbody2D rb;
    public float vida = 1000;
    public float damage = 40;
    public float attackDelay = 2;
    public float activeAttackTime = 0.5f;
    float attackRadius = 3;
    float delaySound = 3f;
    float getTime = 0;
    float getTimeSound = 0;


    float attackTimer;
    int stopOnAttack = 1;

    public float acceleration = 5;
    public float maxSpeed = 10;
    public float sightDistance = 25;
    bool playerDetected = false;
    bool attacking = false;
    bool dead = false;
    

    float stunTimer;
    float stunDuration = 2;
    int stunMultiplier = 1;

    SpriteRenderer sprite;

    BarraVida barraVida;



    // Start is called before the first frame update
    void Start()
    {
        barraVida = FindObjectOfType<BarraVida>();
        attackTimer = attackDelay;
        rb = GetComponent<Rigidbody2D>();
        magician = GameObject.FindGameObjectWithTag("Player");
        
        
        sprite = GetComponent<SpriteRenderer>();

        stunTimer = stunDuration / 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected)
        {
            getTime += Time.deltaTime;
        }
        if (getTime - getTimeSound >= delaySound)
        {
            getTimeSound = getTime;
            audio.Play();
        }
       

        if (dead)
        {
            animator_p.SetBool("attack", false);
            animator_p.SetBool("IsDead", true);
            rb.velocity = new Vector2(0, 0);
            Destroy(gameObject, 1.5f);
            capsuleCol.enabled = false;
            circleCol.enabled = false;
        }
        if (magician.transform.position.x > transform.position.x)
        {
            
            sprite.flipX = false;
        }
        else
        {
           
            sprite.flipX = true;
        }
        if (sprite.color.a < 1)
        {

            sprite.color += new Color(0, 0, 0, 2 * Time.deltaTime);
        }
        else if (sprite.color.a > 1)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
        }
        if (!dead)
        {
            Vector2 playerDir = new Vector2(transform.position.x - magician.transform.position.x, transform.position.y - magician.transform.position.y).normalized;
            float playerDist = Vector2.Distance(transform.position, magician.transform.position);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -playerDir, Mathf.Infinity, includeLayers);
            
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Player") && playerDist < sightDistance)
                {
                    FollowPlayer();
                    playerDetected = true;
                    animator_p.SetBool("Detected", true);
                }
                else
                {
                    rb.velocity *= new Vector2(0.999f, 0.999f);
                    playerDetected = false;
                }
            }
            if (magician.GetComponent<PlayerMovement>().alive)
            {
                attackTimer += Time.deltaTime;
                if (playerDetected && playerDist < attackRadius && attackTimer > attackDelay)
                {
                    attackTimer = 0;
                    attacking = true;

                }
                if (attackTimer > activeAttackTime && attackTimer <= attackDelay)
                {
                    attacking = false;

                }
            }
           
        }


        stunTimer += Time.deltaTime;
        if (stunTimer < stunDuration)
            stunMultiplier = 0;
        else
            stunMultiplier = 1;
    }

    void FollowPlayer()
    {
        Vector2 fpos = Vector2.MoveTowards(transform.position, magician.transform.position, acceleration * Time.deltaTime);
        rb.velocity += fpos - (Vector2)transform.position;
        rb.velocity *= stopOnAttack * stunMultiplier;
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
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.33333f);
        GameObject damageText = damageOutput;
        Instantiate(damageText, transform.position, transform.rotation);
        damageText.GetComponent<DamageOutput>().getNumber(golpe);

        if (vida <= 0)
        {
            int randomCoin = Random.Range(0, 5);
            if (randomCoin <= 3)
            {
                GameObject coin = Instantiate(Coin.gameObject, transform.position, transform.rotation);
            }
            dead = true;
           
        }
        Debug.Log("Vida Restante: " + vida);


    }

    public void efectoStun(float stun)
    {

        stunTimer = 0;
    }


    
    private void OnTriggerStay2D(Collider2D collision)
    {
     
        
        if (collision.CompareTag("Player") && attacking == true)
        {
            animator_p.SetBool("attack", true);

            attacking = false;
            
            Debug.Log("hitPlayer!");
            if(sprite.flipX == false)
                Instantiate(firehit, transform.position + new Vector3(2, 0, 0), transform.rotation);
            else
                Instantiate(firehit, transform.position - new Vector3(2, 0, 0), transform.rotation);
            
            //barraVida.VidaConsumida(damage);
            stopOnAttack = 0;
            
        }
        else
        {
            animator_p.SetBool("attack", false);
        }

    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            {
                Debug.Log("PlayerLeft");
                stopOnAttack = 1;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

}
