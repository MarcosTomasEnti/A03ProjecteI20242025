using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemHit : MonoBehaviour
{
    public BoxCollider2D boxCollider;

    public int hit = 40;

    float timer = 0;
    
    float timeLimit =0.75f;

    

    bool alreadyHit = false;
    

    BarraVida barraVida;
    // Start is called before the first frame update
    void Start()
    {
        barraVida = FindObjectOfType<BarraVida>();
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;

        

        if (timer >= timeLimit *0.5f)
        {
            boxCollider.enabled = true;
        }

        if (timer >= timeLimit)
        {
            Destroy(gameObject);
        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !alreadyHit)
        {
            barraVida.VidaConsumida(hit);
            alreadyHit = true;
            
        }
    }
}
