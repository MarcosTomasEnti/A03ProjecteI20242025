using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Capsula : MonoBehaviour
{
    private bool Canjump = true;
    private int totalCoins = 0;
    [SerializeField]
    private Rigidbody2D rb2D;
    // Start is called before the first frame update

    public float horizontalSpeed;
    public float jumpForce;

    void Start()
    {
        if(rb2D == null)
        {
            Debug.Log("Rigidbody2D is not initlialitzed");
            rb2D = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.H))
        {
            // rb2D.velocity = new Vector3(-15f, 0);
            rb2D.velocity = new Vector3(0-horizontalSpeed, 0);
        }
        if (Input.GetKey(KeyCode.J))
        {
            // rb2D.velocity = new Vector3(15f, 0);
            rb2D.velocity = new Vector3(horizontalSpeed, 0);
        }

        if (Input.GetKeyDown(KeyCode.U)&& Canjump == true)
        {
            rb2D.AddForce(new Vector2(rb2D.totalForce.x, jumpForce));
            Canjump = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin")) 
        {
            totalCoins++;
            Debug.Log("Monedas totales: " + totalCoins);
        }
   
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            Debug.Log("Toca Suelo");
            Canjump = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            Debug.Log("Salta");
            Canjump = false;
        }
    }
}
