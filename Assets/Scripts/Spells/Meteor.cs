using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    Vector2 mousePos;

    int golpe = 80;
    // Start is called before the first frame update
    void Start()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = mousePos;

        //se guarda en esta variable, que es un vector de 3 dimensiones, la posición del mouse en la pantalla

        //se usa como referencia la posición del mouse en la pantalla para obtener sus coordenadas dentro de la escena

        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TrainEnemy"))
        {
            collision.gameObject.GetComponent<TrainEnemy>().RecibirGolpe(golpe);
        }
        if (collision.gameObject.CompareTag("MeleeEnemy"))
        {
            collision.gameObject.GetComponent<MeleeEnemy>().RecibirGolpe(golpe);
        }
        if (collision.gameObject.CompareTag("RangedEnemy"))
        {
            collision.gameObject.GetComponent<RangedEnemy>().RecibirGolpe(golpe);
        }
    }
}