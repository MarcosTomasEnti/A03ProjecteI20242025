using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Choco");
        if (collision.gameObject.CompareTag("Player"))
        {
            // Funcion de Curar vida
            Destroy(gameObject.gameObject);
        }
    }
    // Update is called once per frame
}
