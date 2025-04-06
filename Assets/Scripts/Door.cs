using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool locked = false;

    public GameObject magician;

    public Sprite openDoor;
    public Sprite closeDoor;

    SpriteRenderer sprite;
    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        magician = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!locked)
        {
            openTheDoor();
        }
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        float dist = magician.transform.position.y - transform.position.y;
        if (dist > -1)
            sprite.sortingOrder = 3;
        else
            sprite.sortingOrder = 0;  
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        closeTheDoor();
    }


    void openTheDoor()
    {
        sprite.sprite = openDoor;
        boxCollider.enabled = false;
    }

    void closeTheDoor()
    {
        sprite.sprite = closeDoor;
        boxCollider.enabled = true;
    }


}
