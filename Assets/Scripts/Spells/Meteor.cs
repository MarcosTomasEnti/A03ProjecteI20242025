using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [Header("Configuraci�n")]
    public float speed = 5f;
    public float explosionRadius = 2f;
    public int damage = 80;
    public float timeToExplode = 2f;

    [Header("Referencias")]
    public GameObject explosionEffect;

    private Vector2 targetPosition;
    private float timer;
    private bool hasExploded = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Obtener posici�n del mouse en coordenadas del mundo 2D
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcular direcci�n y aplicar velocidad
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        rb.velocity = direction * speed;

        // Programar destrucci�n despu�s del tiempo de explosi�n
        Invoke("Explode", timeToExplode);
    }

    void Update()
    {
        if (hasExploded) return;

        timer += Time.deltaTime;

        // Explotar si llegamos cerca del objetivo antes del tiempo
        if (Vector2.Distance(transform.position, targetPosition) < 0.5f)
        {
            Explode();
        }
    }

    void Explode()
    {
        if (hasExploded) return;
        hasExploded = true;

        // Crear efecto de explosi�n
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Detectar y da�ar enemigos en el �rea
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemigo"))
            {
                // Ejemplo de c�mo hacer da�o (necesitar�as un script Enemy con este m�todo)
                // hit.GetComponent<Enemy>().TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }

    // Visualizaci�n del radio de explosi�n en el editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Vector2 mousePos;
    public GameObject Meteoro;

    float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        //se guarda en esta variable, que es un vector de 3 dimensiones, la posici�n del mouse en la pantalla
        mousePos = Input.mousePosition;
        //se usa como referencia la posici�n del mouse en la pantalla para obtener sus coordenadas dentro de la escena
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject meteor = Instantiate(Meteoro, transform.position, Quaternion.identity);

            if (meteor != null)
            {
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo") && timePassed >= 2)
        {
            // -80 En la vida del enemigo, no se puede colocar todav�a porque hay que re organizar el codigo de los enemigos

        }
    }
}*/