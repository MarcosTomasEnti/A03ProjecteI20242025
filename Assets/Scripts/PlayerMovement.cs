using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool pointAndClickMovement = false;
    bool moving = false;
    Vector2 lastClickPos;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    public float speed = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (pointAndClickMovement == false)
            {
                pointAndClickMovement = true;
            }
            else
            {
                pointAndClickMovement = false;
            }

        }

    }

    private void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        if (mousePos.x - transform.position.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (pointAndClickMovement == false)
        {
            rb.MovePosition(rb.position + new Vector2(horizontalMove, verticalMove) * Time.fixedDeltaTime * speed);

        }
        else if(Input.GetMouseButton(0))
        {
            lastClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }
        if(moving && (Vector2)transform.position != lastClickPos)
        {
            float step = speed * Time.fixedDeltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickPos, step);
        }
        else
        {
            moving = false;
        }


    }
}
