using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class MagicDoor : MonoBehaviour
{
    public Sprite openGoldDoor;
    public Sprite closeGoldDoor;

    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;
    public GameObject magician;

    private void Start()
    {
        magician = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public void AbrirPuertaMagica()
    {
        sprite.sprite = openGoldDoor;
        boxCollider.enabled = false;
    }
    public void CerrarPuertaMagica()
    {
        sprite.sprite = closeGoldDoor;
        boxCollider.enabled = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        float dist = magician.transform.position.y - transform.position.y;
        if (dist > -1)
        {
            sprite.sortingOrder = 3;
        }
        else
        {
            sprite.sortingOrder = 0;
        }
    }
}