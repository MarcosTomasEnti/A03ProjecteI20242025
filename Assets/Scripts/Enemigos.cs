using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public int vida = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
<<<<<<< Updated upstream


>>>>>>> Stashed changes
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            vida -= 40;
            Debug.Log("Vida restante: " + vida);
        }
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
