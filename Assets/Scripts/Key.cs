using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    CircleCollider2D collider;
    bool following = false;
    float diferencia = 0;  //la diferencia de la segunda o demás llaves siguiendo al jugador
    float speed;
    GameObject player;
   /* GameObject key;
    GameObject followingKey;*/
    int followKey = 0;
    bool primerallave = false;


    [Tooltip("False = golden. True = dark")]
    public bool keyType = false;

    // Start is called before the first frame update

    private void Start()
    {
        if (keyType)
        {
            GetComponent<SpriteRenderer>().color = new Color(56/255, 0,1);
        }

        collider = GetComponent<CircleCollider2D>();
        speed = Random.Range(1,2);
    }


    // Update is called once per frame
    void Update()
    {
        LlavesSeguir();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            following = true;
            diferencia += 15;
            player = collision.gameObject;
                if (primerallave!)
                {
                    primerallave = true;
                }
                else
                {
                    followKey += 1;
                }
            Debug.Log(followKey);
            if (keyType == false)
            {
                player.GetComponent<PlayerMovement>().hasGoldKey = true;
                player.GetComponent<PlayerMovement>().goldKeyHeld = gameObject;
            }
            else if (keyType == true)
            {
                player.GetComponent<PlayerMovement>().hasDarkKey = true;
                player.GetComponent<PlayerMovement>().darkKeyHeld = gameObject;
            }
            collider.enabled = false;
        }
        
    }

    private void LlavesSeguir()
    {

        if (followKey == 0 && primerallave == true)
        {
            if (following && Mathf.Abs((player.transform.localPosition - transform.localPosition).magnitude) > 3)
            {
                transform.localPosition += (player.transform.position - transform.localPosition) / speed * 2 * Time.deltaTime;
            }
            if (player != null && keyType == false)
            {
                if (player.GetComponent<PlayerMovement>().hasGoldKey == false)
                {
                    player.GetComponent<PlayerMovement>().hasGoldKey = true;
                    player.GetComponent<PlayerMovement>().goldKeyHeld = gameObject;
                }
            }
            else if (player != null && keyType == true)
            {
                if (player.GetComponent<PlayerMovement>().hasDarkKey == false)
                {
                    player.GetComponent<PlayerMovement>().hasDarkKey = true;
                    player.GetComponent<PlayerMovement>().darkKeyHeld = gameObject;
                }
            }
        }

        else if (followKey >= 1 && primerallave == true)
        {
            Debug.Log("segunda llave siguiendo");
            if (following && Mathf.Abs((player.transform.localPosition - transform.localPosition).magnitude) > 3)
            {
                transform.localPosition += (player.transform.position - transform.localPosition) / speed * 2 * Time.deltaTime * diferencia;
            }
            if (player != null && keyType == false)
            {
                if (player.GetComponent<PlayerMovement>().hasGoldKey == false)
                {
                    player.GetComponent<PlayerMovement>().hasGoldKey = true;
                    player.GetComponent<PlayerMovement>().goldKeyHeld = gameObject;
                }
            }
            else if (player != null && keyType == true)
            {
                if (player.GetComponent<PlayerMovement>().hasDarkKey == false)
                {
                    player.GetComponent<PlayerMovement>().hasDarkKey = true;
                    player.GetComponent<PlayerMovement>().darkKeyHeld = gameObject;
                }
            }
        }
    }
}