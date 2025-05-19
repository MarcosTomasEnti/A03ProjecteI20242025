using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class MagicDoor : MonoBehaviour
{
    public bool lockedMagic = false;

    int collisionStayCount = 0;
    [HideInInspector]
    public GameObject magician;

    public Sprite openGoldDoor;
    public Sprite closeGoldDoor;
    GameObject pilares;

    SpriteRenderer sprite;
    BoxCollider2D boxCollider;

    // Update is called once per frame
    void Update()
    {
        /*  if (lockedMagic == true && pilares.GetComponent<Pilares>().activado == true)
          {
              openTheDoor();
              collisionStayCount++;
              Debug.Log(collisionStayCount);
          }*/

        if (pilares.GetComponent<Pilares>().activado == true)
        {
            //openTheDoor();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionStayCount--;
        Debug.Log(collisionStayCount);
        if (collisionStayCount <= 0)
        {
            closeTheDoor();
            collisionStayCount = 0;
        }
    }

    void openTheDoor()
    {
        sprite.sprite = openGoldDoor;
        boxCollider.enabled = false;
    }
    void closeTheDoor()
    {
       sprite.sprite = closeGoldDoor;
       boxCollider.enabled = true;
    }
}