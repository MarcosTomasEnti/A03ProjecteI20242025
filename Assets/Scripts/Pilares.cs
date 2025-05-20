using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilares : MonoBehaviour
{

    public bool activado = false;
    public float tiempoActivo = 10f; // tiempo máximo activado
    private float tiempoRestante = 0f;

    public MagicDoor puertaVinculada; // Asignar en el inspector

    private void Update()
    {
        if (activado)
        {
            tiempoRestante -= Time.deltaTime;

            if (tiempoRestante <= 0f)
            {
                activado = false;
                puertaVinculada.CerrarPuertaMagica();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            activado = true;
            tiempoRestante = tiempoActivo;

            puertaVinculada.AbrirPuertaMagica();
            Destroy(collision.gameObject);
        }
    }    
}