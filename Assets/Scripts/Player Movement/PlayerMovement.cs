//Librer�as: si en alg�n momento necesitas usar elementos que pertenezcan a una y no la has puesto se pondr� autom�ticamente
//           si es parte de la colecci�n base de unity y no sacadas de internet
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//La clase sirve para declarar qu� uso tendr� el script. En este caso es para dar instrucciones a un objeto en escena. Pero no es algo importante al 
//   inicio y si es necesario ya se ver� mas adelante. Por ahora al crear un script siempre aparecer� por defecto como se ve
public class PlayerMovement : MonoBehaviour
{
    //A partir de aqu� se pueden poner las variables. NO ANTES.
    public bool alive = true;
    //Public permite que la variable sea accedida desde el editor de unity.
    private int totalCoins = 0;
    //"RigidBody2D" es un componente de objeto de unity que proporciona f�sicas al objeto y se puede declarar en el editor para modificar
    //sus atributos.
    public Rigidbody2D rb;
    //Este boolean sirve para que el movimiento del jugador est� en modo "point and click" o que se mueva con WASD y apunte con rat�n.
    public bool pointAndClickMovement = false;
    //Para el modo point and click, muestra si el jugador sigue intentando llegar al punto o no para seguir moviendose hacia �l.
    bool moving = false;
    //Coordenadas del �ltimo click a donde ir en modo point and click
    Vector2 lastClickPos;
    //Este float nos servir� para recibir la direcci�n en la que el jugador se mueve horizontalmente con teclas y su intensidad en caso de mando.
    float horizontalMove = 0f;
    //Este float nos servir� para recibir la direcci�n en la que el jugador se mueve verticalmente con teclas y su intensidad en caso de mando.
    float verticalMove = 0f;
    //Velocidad del jugador. Si se altera puede proporcionar una velocidad diferente. En negativo le har� ir al rev�s.
    public float speed = 15;

    SpriteRenderer sprite;
    public Sprite deathSprite;

    public AudioSource audioSource;
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            speed += 10;
        }
        if (Input.GetKeyDown(KeyCode.F4) && speed > 10)
        {
            speed -= 10;
        }

        if(Input.GetKeyDown(KeyCode.Escape)) 
            Application.Quit();


        if (alive)
        {
            //asignamos el input de movimiento f�sico usando los ejes de movimiento vertical y horizontal a los floats anteriormente declarados.
            horizontalMove = Input.GetAxisRaw("Horizontal");
            verticalMove = Input.GetAxisRaw("Vertical");

            //Detecta si hemos pulsado espacio para alternar entre point and click o movimiento WASD.
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (pointAndClickMovement == false)
                {
                    pointAndClickMovement = true;
                }
                else
                {
                    pointAndClickMovement = false;
                }

            }
        }
        else
        {

            sprite.sprite = deathSprite;
            sprite.color -= new Color(0,0,0,2*Time.deltaTime);
        }
        

    }

    public void destroyChildren()
    {
        for(int i = 0; i< transform.childCount; i++)
        {
            if(gameObject.transform.GetChild(i).gameObject.tag == "Player")
            {
                audioSource.clip = deathSound;
                audioSource.Play();
                Destroy(gameObject.transform.GetChild(i).gameObject);
                
            }
        }
    }


    //act�a igual al void update, pero va ligado al motor de f�sicas y no a los frames de la pantalla.
    private void FixedUpdate()
    {
        if (alive)
            move();


    }

    void move()
    {
        //se guarda en esta variable, que es un vector de 3 dimensiones, la posici�n del mouse en la pantalla
        Vector3 mousePos = Input.mousePosition;
        //se usa como referencia la posici�n del mouse en la pantalla para obtener sus coordenadas dentro de la escena
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //si le restamos la posici�n del mouse en el eje x la posici�n del jugador nos da como punto 0 el centro de la pantalla.
        //con esto podemos tener referencia para que el sprite se gire si apuntamos a su espalda.
        if (mousePos.x - transform.position.x < 0)
        {
            //accedemos al sprite y lo giramos en el eje x
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            //accedemos al sprite y lo giramos en el eje x
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //en caso de que el movimiento point and click est� desactivado:
        if (pointAndClickMovement == false)
        {
            //se usa un parametro que pertenece al componente "RigidBody2D" que permite calcular movimiento haciendo uso de valores que le
            //proporcionemos. Se hace uso de un vector de 2 dimensiones y es imprescindible multiplicarlo por DeltaTime. esto sirve para que la velocidad 
            //se calcule de manera estable en cualquier dispositivo en caso de un framerate variable.
            //el nuevo vector 2d declarado que contiene horizontalMove y verticalMove sirve para anular o permitir movimiento seg�n la direcci�n que
            //hayamos tomado con las teclas.
            rb.MovePosition(rb.position + new Vector2(horizontalMove, verticalMove) * Time.fixedDeltaTime * speed);

        }
        //en caso de que s� que est� activo el movimiento point and click Y se haga click derecho en alg�n punto:
        else if (Input.GetMouseButton(1))
        {
            //obtenemos las coordenadas del �ltimo punto donde se ha hecho click para que el jugador sepa a donde ir
            lastClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Damos luz verde a que el jugador vaya al punto
            moving = true;
        }
        //en caso de que el jugador no est� en el punto y siga en movimiento hacia este:
        if (moving && (Vector2)transform.position != lastClickPos)
        {
            //declaramos una variable para calcular la velocidad a la que se mueve
            float step = speed * Time.fixedDeltaTime;
            //se mueve el jugador hacia las coordenadas dadas haciendo uso de las variables declaradas y usadas anteriormente
            transform.position = Vector2.MoveTowards(transform.position, lastClickPos, step);
        }
        //en caso de que s� que est� en el punto o no se est� moviendo:
        else
        {
            moving = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            totalCoins++;
            Debug.Log("Monedas totales: " + totalCoins);
        }

    }
}
