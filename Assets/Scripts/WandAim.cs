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
    public GameObject bulletPrefab;
    public GameObject BounchBall;
    public GameObject GreatFireBall;
    public Vector2 mousePos;
    public Vector3 direction;
    public float redBallSpeed = 20;
    public float greenBallSpeed = 40;
    public GameObject Meteoro;
    public GameObject CanonDeMeteoritos;


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
        //se guarda en esta variable, que es un vector de 3 dimensiones, la posici�n del mouse en la pantalla
        mousePos = Input.mousePosition;
        //se usa como referencia la posici�n del mouse en la pantalla para obtener sus coordenadas dentro de la escena
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
     
        

        //Calculamos el �ngulo al que debe apuntar dici�ndole que mire en direcci�n a las coordenadas que le proporcionamos
        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        //Aplicamos el �ngulo a las propiedades del objeto
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
        if (Input.GetKeyDown(KeyCode.G))
        {
            
           
            GameObject meteor = Instantiate(Meteoro, new Vector2(0,0), Quaternion.identity);

           
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject greatFireBall = Instantiate(GreatFireBall, transform.position, Quaternion.identity);
            Rigidbody2D GreatFBrb = greatFireBall.GetComponent<Rigidbody2D>();
            if (greatFireBall != null)
            {
                GreatFBrb.velocity = direction.normalized * greenBallSpeed;
            }
        }
        //Con esto calculamos que el punto 0 del mouse sea el medio de la pantalla y as� podemos determinar si mira adelante o atr�s para girar la
        //varita
        if (mousePos.x - transform.parent.position.x < 0)
        {
            //Cambiamos la posici�n ligeramente para que se de la vuelta correctamente
            transform.localPosition = new Vector3(-1.5f, -1, 0);
            //le damos la vuelta al sprite en el eje x
            sprite.flipX = false;
        }
        else
        {
            //Cambiamos la posici�n ligeramente para que se de la vuelta correctamente
            transform.localPosition = new Vector3(1.5f, -1, 0);
            //le damos la vuelta al sprite en el eje x
            sprite.flipX = true;
        }

    }

    

}