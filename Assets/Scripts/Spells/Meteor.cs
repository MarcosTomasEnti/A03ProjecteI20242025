using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Vector2 mousePos;
    public GameObject Meteoro;
    int golpe = 80;
    // Start is called before the first frame update
    void Start()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = mousePos;

        //se guarda en esta variable, que es un vector de 3 dimensiones, la posici�n del mouse en la pantalla

        //se usa como referencia la posici�n del mouse en la pantalla para obtener sus coordenadas dentro de la escena

        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            collision.gameObject.GetComponent<Enemigos>().RecibirGolpe(golpe);
        }
    }
}