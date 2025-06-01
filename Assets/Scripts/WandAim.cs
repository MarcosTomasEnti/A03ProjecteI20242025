//Librer�as: si en alg�n momento necesitas usar elementos que pertenezcan a una y no la has puesto se pondr� autom�ticamente
//           si es parte de la colecci�n base de unity y no sacadas de internet
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

//La clase sirve para declarar qu� uso tendr� el script. En este caso es para dar instrucciones a un objeto en escena. Pero no es algo importante al 
//   inicio y si es necesario ya se ver� mas adelante. Por ahora al crear un script siempre aparecer� por defecto como se ve
public class WandAim : MonoBehaviour
{
    //A partir de aqu� se pueden poner las variables. NO ANTES.

    //Public permite que la variable sea accedida desde el editor de unity.
    //SpriteRenderer es el elemento que contiene el sprite y sus valores. Podemos alterarlo con c�digo.
    public SpriteRenderer sprite;
    public Transform firePoint;

    Vector2 mousePos;
    Vector3 direction;
    GameObject magician;



    // Start is called before the first frame update
    void Start()
    {
        //accedemos al componente haciendo uso de la jerarqu�a de la escena, ya que este componente es de un hijo del objeto al que pertenece este 
        //script
        sprite = GetComponentInChildren<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        

        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = direction;

        if (mousePos.x - transform.parent.position.x < 0)
        {
            //Cambiamos la posici�n ligeramente para que se de la vuelta correctamente
            transform.localPosition = new Vector3(-1.5f, -1, 0);
            //le damos la vuelta al sprite en el eje x
            sprite.flipX = true;
        }
        else
        {
            //Cambiamos la posici�n ligeramente para que se de la vuelta correctamente
            transform.localPosition = new Vector3(1.5f, -1, 0);
            //le damos la vuelta al sprite en el eje x
            sprite.flipX = false;
        }

    }

    

}