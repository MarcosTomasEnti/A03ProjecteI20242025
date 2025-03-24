//Librerías: si en algún momento necesitas usar elementos que pertenezcan a una y no la has puesto se pondrá automáticamente
//           si es parte de la colección base de unity y no sacadas de internet
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//La clase sirve para declarar qué uso tendrá el script. En este caso es para dar instrucciones a un objeto en escena. Pero no es algo importante al 
//   inicio y si es necesario ya se verá mas adelante. Por ahora al crear un script siempre aparecerá por defecto como se ve
public class WandAim : MonoBehaviour
{
    //A partir de aquí se pueden poner las variables. NO ANTES.

    //Public permite que la variable sea accedida desde el editor de unity.
    //SpriteRenderer es el elemento que contiene el sprite y sus valores. Podemos alterarlo con código.
    public SpriteRenderer sprite;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject BounchBall;
    public Vector2 mousePos;
    public Vector3 direction;
    public float redBallSpeed = 20;
    public float greenBallSpeed = 40;
   

    // Start is called before the first frame update
    void Start()
    {
        //accedemos al componente haciendo uso de la jerarquía de la escena, ya que este componente es de un hijo del objeto al que pertenece este 
        //script
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //se guarda en esta variable, que es un vector de 3 dimensiones, la posición del mouse en la pantalla
        mousePos = Input.mousePosition;
        //se usa como referencia la posición del mouse en la pantalla para obtener sus coordenadas dentro de la escena
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
     
        

        //Calculamos el ángulo al que debe apuntar diciéndole que mire en dirección a las coordenadas que le proporcionamos
        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        //Aplicamos el ángulo a las propiedades del objeto
        transform.up = direction;
        if(Input.GetKeyDown(KeyCode.Q))
        {
            GameObject fireball = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D firerb = fireball.GetComponent<Rigidbody2D>();
            if (fireball != null)
            {
                firerb.velocity = direction.normalized * redBallSpeed;
            }
            // Instantiate(bulletPrefab, mousePos, direction);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject bounchBall = Instantiate(BounchBall, transform.position, Quaternion.identity);
            Rigidbody2D bounchrb = bounchBall.GetComponent<Rigidbody2D>();
            if (bounchBall != null)
            {
                bounchrb.velocity = direction.normalized * greenBallSpeed;
            }
        }
        //Con esto calculamos que el punto 0 del mouse sea el medio de la pantalla y así podemos determinar si mira adelante o atrás para girar la
        //varita
        if (mousePos.x - transform.parent.position.x < 0)
        {
            //Cambiamos la posición ligeramente para que se de la vuelta correctamente
            transform.localPosition = new Vector3(-1.5f, -1, 0);
            //le damos la vuelta al sprite en el eje x
            sprite.flipX = false;
        }
        else
        {
            //Cambiamos la posición ligeramente para que se de la vuelta correctamente
            transform.localPosition = new Vector3(1.5f, -1, 0);
            //le damos la vuelta al sprite en el eje x
            sprite.flipX = true;
        }

    }

    

}