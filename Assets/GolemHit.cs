using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemHit : MonoBehaviour
{
    public int hit = 40;
    BarraVida barraVida;
    // Start is called before the first frame update
    void Start()
    {
        barraVida = FindObjectOfType<BarraVida>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            barraVida.VidaConsumida(hit);
            Destroy(gameObject);
        }
    }
}
