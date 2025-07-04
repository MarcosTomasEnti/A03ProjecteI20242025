using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBall : MonoBehaviour
{
    public int golpe = 10;
    public float stun = 1f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6f);
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
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Suelo") || collision.gameObject.CompareTag("Puerta"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("RangedEnemy"))
        {
            collision.gameObject.GetComponent<RangedEnemy>().RecibirGolpe(golpe);
            Destroy(gameObject.gameObject);
        }
        else if (collision.gameObject.CompareTag("MeleeEnemy"))
        {
            collision.gameObject.GetComponent<MeleeEnemy>().efectoStun(stun);
            Destroy(gameObject.gameObject);
        }
        else if (collision.gameObject.CompareTag("Obstaculos"))
        {
            Destroy(gameObject.gameObject);
        }
        else if (collision.gameObject.CompareTag("GolemEnemy"))
        {
            collision.gameObject.GetComponent<Golem_script>().efectoStun(stun);
            Destroy(gameObject.gameObject);
        }
    }

}
