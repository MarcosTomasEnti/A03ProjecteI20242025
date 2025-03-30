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
        float distanceto = Vector3.Distance(gameObject.transform.position, collision.gameObject.transform.position);
        if (collision.gameObject.CompareTag("Enemigo") && distanceto <=2)
        {
            collision.gameObject.GetComponent<Enemigos>().RecibirGolpe(golpe);
        }
    }
 
}
