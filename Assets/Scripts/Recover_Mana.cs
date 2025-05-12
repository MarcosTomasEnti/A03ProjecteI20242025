using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover_Mana : MonoBehaviour
{
    public float recoverMana;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Funcion de Curar mana
            Destroy(gameObject.gameObject);
            FindObjectOfType<BarraMana>().ManaRestaurar(recoverMana);
        }
    }
}