using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    CircleCollider2D collider;
    bool following = false;
    float speed;
    GameObject player;

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
        if (following && Mathf.Abs((player.transform.localPosition - transform.localPosition).magnitude) > 3)
        {
            transform.localPosition += (player.transform.position - transform.localPosition) / 250 * speed;
        }
        if(player != null && keyType == false)
        { 
            if(player.GetComponent<PlayerMovement>().hasGoldKey == false)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            following = true;
            player = collision.gameObject;
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
}
