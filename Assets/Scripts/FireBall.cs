using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Suelo") || collision.gameObject.CompareTag("Enemigo"))
    {
            
        
            Destroy(gameObject);
    }
}
}
