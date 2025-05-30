using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Golem_script : MonoBehaviour
{
    [SerializeField]
    LayerMask includeLayers;

    public GameObject damageOutput;

    public GameObject magician;
    public GameObject Coin;
    public Rigidbody2D rb;
    public float vida = 1000;
    public float damage = 40;
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
        hitBox = GetComponent<CircleCollider2D>();
        hitBox.enabled = true;

        sprite = GetComponent<SpriteRenderer>();

        stunTimer = stunDuration / 2;

    }

    // Update is called once per frame
    void Update()
    {

        if (magician.transform.position.x > transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -playerDir, Mathf.Infinity, includeLayers);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player") && playerDist < sightDistance)
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
        if (playerDetected && playerDist < hitBox.radius && attackTimer > attackDelay)
        {
            attackTimer = 0;
            attacking = true;
        }
        if (attackTimer > activeAttackTime && attackTimer <= attackDelay)
        {
            attacking = false;
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
            Destroy(gameObject);
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
            {
                attacking = false;
                Debug.Log("hitPlayer!");
                barraVida.VidaConsumida(damage);
                stopOnAttack = 0;
            }
        }
        if (collision.CompareTag("Player"))
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + (Time.deltaTime * 1500));
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
