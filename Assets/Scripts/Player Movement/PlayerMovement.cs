//Librerías: si en algún momento necesitas usar elementos que pertenezcan a una y no la has puesto se pondrá automáticamente
//           si es parte de la colección base de unity y no sacadas de internet
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//La clase sirve para declarar qué uso tendrá el script. En este caso es para dar instrucciones a un objeto en escena. Pero no es algo importante al 
//   inicio y si es necesario ya se verá mas adelante. Por ahora al crear un script siempre aparecerá por defecto como se ve
public class PlayerMovement : MonoBehaviour
{
    //A partir de aquí se pueden poner las variables. NO ANTES.
    public bool alive = true;
    //Public permite que la variable sea accedida desde el editor de unity.
    //"RigidBody2D" es un componente de objeto de unity que proporciona físicas al objeto y se puede declarar en el editor para modificar
    //sus atributos.
    public Rigidbody2D rb;
    //Este boolean sirve para que el movimiento del jugador esté en modo "point and click" o que se mueva con WASD y apunte con ratón.
    public bool pointAndClickMovement = false;
    //Para el modo point and click, muestra si el jugador sigue intentando llegar al punto o no para seguir moviendose hacia él.
    bool moving = false;
    //Coordenadas del último click a donde ir en modo point and click
    Vector2 lastClickPos;
    //Este float nos servirá para recibir la dirección en la que el jugador se mueve horizontalmente con teclas y su intensidad en caso de mando.
    float horizontalMove = 0f;
    //Este float nos servirá para recibir la dirección en la que el jugador se mueve verticalmente con teclas y su intensidad en caso de mando.
    float verticalMove = 0f;
    //Velocidad del jugador. Si se altera puede proporcionar una velocidad diferente. En negativo le hará ir al revés.
    public float speed = 15;
    public GameObject PauseMenu;
    
    SpriteRenderer sprite;
    [SerializeField] private AudioSource audio;
    public Image hitEfect;

    public AudioSource audioSource;
    public AudioClip deathSound;
    public CoinCounter coinCounter;
    public Animator Animation;
    public SaveFileResource saveFile;

    public GameObject goldKeyHeld;
    public GameObject darkKeyHeld;

    public bool hasGoldKey = false;
    public bool hasDarkKey = false;
    bool SoundDead = false;

    float dashTimer = 100;
    float dashTimerCap = 0.5f;
    float dashSpeed = 35;
    float originalSpeed = 15;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Animation = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dashTimer < dashTimerCap)
        {
            dashTimer += Time.deltaTime;
            if(dashTimer >= dashTimerCap)
            {
                speed = originalSpeed;
            }
        }

        if (hitEfect.color.a > 0)
        {
            hitEfect.color -= new Color(0, 0, 0, 2 * Time.deltaTime);
            
        }
        else
        {
            Animation.SetBool("Golpeado", false);
        }


        if (Input.GetKeyDown(KeyCode.F3))
        {
            speed += 10;
        }
        if (Input.GetKeyDown(KeyCode.F4) && speed > 15)
        {
            speed -= 10;
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            saveFile.unlockedMeteor = true;
            saveFile.unlockedGreatFireball = true;
            saveFile.unlockedBounceBall = true;
            saveFile.unlockedThunderCaster = true;
            saveFile.unlockedLaserBeam = true;
            saveFile.unlockedStunBall = true;
            saveFile.unlockedStormArea = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape)&& PauseMenu.GetComponent<PauseManager>().Options == false)
        {
            PauseMenu.SetActive(true);
            
        }
       
            if (alive)
        {
            //asignamos el input de movimiento físico usando los ejes de movimiento vertical y horizontal a los floats anteriormente declarados.
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

            Animation.SetBool("IsDead", true);
            sprite.color -= new Color(0, 0, 0, 2 * Time.deltaTime);
        }


    }

    public void destroyChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.tag == "Player")
            {
                
                Destroy(gameObject.transform.GetChild(i).gameObject);

            }
        }
        if (!SoundDead)
        {
            audioSource.clip = deathSound;
            audioSource.Play();
            SoundDead = true;
            Debug.Log("Sonido de muerte reproducido");
        }
    }


    //actúa igual al void update, pero va ligado al motor de físicas y no a los frames de la pantalla.
    private void FixedUpdate()
    {
        if (alive)
            move();


    }

    void move()
    {
        //se guarda en esta variable, que es un vector de 3 dimensiones, la posición del mouse en la pantalla
        Vector3 mousePos = Input.mousePosition;
        //se usa como referencia la posición del mouse en la pantalla para obtener sus coordenadas dentro de la escena
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //si le restamos la posición del mouse en el eje x la posición del jugador nos da como punto 0 el centro de la pantalla.
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

        //en caso de que el movimiento point and click esté desactivado:
        if (pointAndClickMovement == false)
        {
            //se usa un parametro que pertenece al componente "RigidBody2D" que permite calcular movimiento haciendo uso de valores que le
            //proporcionemos. Se hace uso de un vector de 2 dimensiones y es imprescindible multiplicarlo por DeltaTime. esto sirve para que la velocidad 
            //se calcule de manera estable en cualquier dispositivo en caso de un framerate variable.
            //el nuevo vector 2d declarado que contiene horizontalMove y verticalMove sirve para anular o permitir movimiento según la dirección que
            //hayamos tomado con las teclas.
            rb.MovePosition(rb.position + new Vector2(horizontalMove, verticalMove) * Time.fixedDeltaTime * speed);

        }
        //en caso de que sí que esté activo el movimiento point and click Y se haga click derecho en algún punto:
        else if (Input.GetMouseButton(1))
        {
            //obtenemos las coordenadas del último punto donde se ha hecho click para que el jugador sepa a donde ir
            lastClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Damos luz verde a que el jugador vaya al punto
            moving = true;
        }
        //en caso de que el jugador no esté en el punto y siga en movimiento hacia este:
        if (moving && (Vector2)transform.position != lastClickPos)
        {
            //declaramos una variable para calcular la velocidad a la que se mueve
            float step = speed * Time.fixedDeltaTime;
            //se mueve el jugador hacia las coordenadas dadas haciendo uso de las variables declaradas y usadas anteriormente
            transform.position = Vector2.MoveTowards(transform.position, lastClickPos, step);
        }
        //en caso de que sí que esté en el punto o no se esté moviendo:
        else
        {
            moving = false;
        }
    }
    public void MonedaConseguida()
    {
        saveFile.totalCoins++;
        coinCounter.GetComponent<CoinCounter>().updateCount(saveFile.totalCoins);
        Debug.Log("Monedas totales: " + saveFile.totalCoins);
    }

    public void dash()
    {
        speed = dashSpeed;
        dashTimer = 0;
    }

    public void hurtEffect()
    {
        hitEfect.color = new Color(1, 1, 1, 1);
        Animation.SetBool("Golpeado", true);
        audio.Play(); 
    }
}
