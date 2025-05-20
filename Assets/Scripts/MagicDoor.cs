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

    private void Start()
    {
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
}