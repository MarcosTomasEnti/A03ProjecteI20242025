using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    CircleCollider2D circleCollider;
    SpriteRenderer sprite;
    TextMeshPro text;


    [SerializeField]
    int value;


    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        text.text = "$" + value;
    }

    private void Update()
    {
        if(text.color.g < 1)
            text.color += new Color(0, 0.01f, 0);
        if (text.color.g > 1)
            text.color = new Color(1, 1, text.color.b);

        if (text.color.b < 1)
            text.color += new Color(0, 0, 0.01f);
        if (text.color.b > 1)
            text.color = new Color(1, text.color.g, 1);


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.Mouse1))
        {
            if(collision.GetComponent<PlayerMovement>().totalCoins >= value)
            { 
                collision.GetComponent<PlayerMovement>().totalCoins -= value;
                collision.GetComponent<PlayerMovement>().coinCounter.GetComponent<CoinCounter>().updateCount(collision.GetComponent<PlayerMovement>().totalCoins);

                Destroy(gameObject);
            }
            else
            {
                text.color = new Color(1, 0, 0);   
            }
        }
    }
}
