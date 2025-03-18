using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    
    public Rigidbody2D rbpelota2D;
    public float velocityHoritzontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rbpelota2D.AddForce(new Vector2(0, velocityHoritzontal));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hello!");
        Color randomColor = new Color(Random.value, Random.value, Random.value,1.0f);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = randomColor;
    }
}
