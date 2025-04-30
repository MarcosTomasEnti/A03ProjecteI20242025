using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderCaster : MonoBehaviour
{
    public GameObject thunder;

    public float castDelay = 0.1f;

    float time = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > castDelay )
        {
            Instantiate(thunder, transform.position, transform.rotation);
            time = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo") || collision.gameObject.CompareTag("Puerta"))
        {
            Destroy(gameObject);
        }
    }


}
