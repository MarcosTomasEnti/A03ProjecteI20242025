using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    CircleCollider2D collider;
    bool following = false;


    GameObject player;

    // Start is called before the first frame update

    private void Start()
    {
        collider = GetComponent<CircleCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (following && Mathf.Abs((player.transform.localPosition - transform.localPosition).magnitude) > 3)
        {
            transform.localPosition += (player.transform.position - transform.localPosition) / 250;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            following = true;
            player = collision.gameObject;
            collider.enabled = false;
        }
    }
}
