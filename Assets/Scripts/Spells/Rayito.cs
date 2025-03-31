using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rayito : MonoBehaviour
{
    public int golpe = 70;
    float time = 0f;
    float flipTimer = 0.0625f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        time += Time.deltaTime;
        sprite.color -= new Color(0,0,0,5* Time.deltaTime);
        if(sprite.color.a < 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MeleeEnemy"))
        {
            collision.gameObject.GetComponent<MeleeEnemy>().RecibirGolpe(golpe);
        }
        if (collision.gameObject.CompareTag("RangedEnemy"))
        {
            collision.gameObject.GetComponent<RangedEnemy>().RecibirGolpe(golpe);
        }
    }
 
}
