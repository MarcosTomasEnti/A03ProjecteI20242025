using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sp_Coin : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            // Sumar una moneda al jugador
            FindObjectOfType<PlayerMovement>().MonedaConseguida();
            Destroy(gameObject.gameObject);
        }
    }
}
