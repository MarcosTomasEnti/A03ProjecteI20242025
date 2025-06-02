using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilares : MonoBehaviour
{
    [SerializeField]
    Sprite pilarOn;
    [SerializeField]
    Sprite pilarOff;

    public bool activado = false;
    public float tiempoActivo = 10f; // tiempo máximo activado
    private float tiempoRestante = 0f;

    public GameObject puertaVinculada;

    private void Update()
    {
        if (activado)
        {
            tiempoRestante -= Time.deltaTime;

            if (tiempoRestante <= 0f)
            {
                activado = false;
                puertaVinculada.GetComponent<MagicDoor>().CerrarPuertaMagica();
            }
        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            activado = true;
            tiempoRestante = tiempoActivo;

            puertaVinculada.GetComponent<MagicDoor>().AbrirPuertaMagica();
            Destroy(collision.gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            activado = true;
            tiempoRestante = tiempoActivo;

            puertaVinculada.GetComponent<MagicDoor>().AbrirPuertaMagica();
            Destroy(collision.gameObject);
        }
    }
}