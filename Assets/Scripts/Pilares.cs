using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilares : MonoBehaviour
{
    public bool activado = false;
    //public bool lockedMagic = false;
    float tiempoRestante;
    float tiempo = 10f; //El tiempo máximo que estara activado
    GameObject puerta;

    // Update is called once per frame
    void Update()
    {
        if (activado == true && (Time.deltaTime - tiempoRestante) < tiempo)
        {           
          activado = false;            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            activado = true;
            //puerta.GetComponent<MagicDoor>().lockedMagic == true;
            tiempoRestante += Time.deltaTime;
        }
    }
}