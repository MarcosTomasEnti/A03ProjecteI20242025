using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public float golpe = 25;
    Vector2 playerPos;
    public BarraMana barraMana;

    public float manaCost = 100;
    // Start is called before the first frame update
    void Start()
    {
        barraMana = FindObjectOfType<BarraMana>();

    }

    // Update is called once per frame
    void Update()
    {
        

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Transform>().GetComponentInChildren<Transform>().position;
        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 direction = new Vector2(mousePos.x - playerPos.x, mousePos.y - playerPos.y);

        transform.up = direction;
        transform.localScale = new Vector3(1, Vector3.Distance(playerPos, mousePos) / 2, 0);
        transform.position = new Vector2((playerPos.x + mousePos.x) / 2, (playerPos.y + mousePos.y) / 2);

        if (Input.GetMouseButtonUp(0) || barraMana.Mana <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            barraMana.ManaConsumida(manaCost * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("MeleeEnemy"))
        {
            collision.gameObject.GetComponent<MeleeEnemy>().RecibirGolpe(golpe * Time.deltaTime);
        }
        if (collision.gameObject.CompareTag("RangedEnemy"))
        {
            collision.gameObject.GetComponent<RangedEnemy>().RecibirGolpe(golpe * Time.deltaTime);
        }
    }
}
