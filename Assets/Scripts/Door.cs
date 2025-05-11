using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool open = false;
    public bool locked = false;
    

    [Tooltip("False = golden. True = dark")]
    public bool lockType = false; //false = golden;; true = dark.
    int collisionStayCount = 0;
    [HideInInspector]
    public GameObject magician;

    public Sprite openGoldDoor;
    public Sprite closeGoldDoor;
    public Sprite openDarkDoor;
    public Sprite closeDarkDoor;
    public Sprite goldLock;
    public Sprite darkLock;

    SpriteRenderer sprite;
    BoxCollider2D boxCollider;
    GameObject keyLock;

    // Start is called before the first frame update
    void Start()
    {
        keyLock = transform.GetChild(0).gameObject;

        magician = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        if(locked == false)
            Destroy(keyLock);

        if (!lockType)
            keyLock.GetComponent<SpriteRenderer>().sprite = goldLock;
        else
            keyLock.GetComponent<SpriteRenderer>().sprite = darkLock;

        if (lockType)
            sprite.sprite = closeDarkDoor;
        else
            sprite.sprite = closeGoldDoor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!open && locked && collision.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<PlayerMovement>();
            GameObject keyToDestroy = null;

            if (!lockType && player.hasGoldKey)
            {
                keyToDestroy = player.goldKeyHeld;
                player.hasGoldKey = false;
                player.goldKeyHeld = null;
                locked = false;
            }
            else if (lockType && player.hasDarkKey)
            {
                keyToDestroy = player.darkKeyHeld;
                player.hasDarkKey = false;
                player.darkKeyHeld = null;
                locked = false;
            }

            if (!open && !locked)
            {
                openTheDoor();
                collisionStayCount++;
                Debug.Log(collisionStayCount);
                Destroy(keyLock);
            }

            if (keyToDestroy != null)
            {
                Key.collectedKeys.Remove(keyToDestroy);
                Destroy(keyToDestroy);
            }
        }


    }
    private void OnTriggerStay2D(Collider2D other)
    {
        float dist = magician.transform.position.y - transform.position.y;
        if (dist > -1)
        { 
            sprite.sortingOrder = 3;
            if(locked) 
                keyLock.GetComponent<SpriteRenderer>().sortingOrder = 4; 
        }
        else
        { 
            sprite.sortingOrder = 0;
            if(locked)
                keyLock.GetComponent<SpriteRenderer>().sortingOrder = 1;
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
        if(lockType)
            sprite.sprite = openDarkDoor;
        else
            sprite.sprite = openGoldDoor;
        boxCollider.enabled = false;
    }

    void closeTheDoor()
    {
        if (lockType)
            sprite.sprite = closeDarkDoor;
        else
            sprite.sprite = closeGoldDoor;

        boxCollider.enabled = true;
    }

    void TransferFollowers(GameObject destroyedKey, GameObject player)
    {
        int destroyedIndex = Key.collectedKeys.IndexOf(destroyedKey);
        if (destroyedIndex >= 0)
        {
            // Si hay una llave detrás de la destruida, actualiza su objetivo de seguimiento
            if (destroyedIndex + 1 < Key.collectedKeys.Count)
            {
                GameObject newLeader = destroyedIndex == 0 ? player : Key.collectedKeys[destroyedIndex - 1];
                Key.collectedKeys[destroyedIndex + 1].GetComponent<Key>().followTarget = newLeader.transform;
            }

            // Eliminar la llave destruida de la lista general
            Key.collectedKeys.RemoveAt(destroyedIndex);
        }
    }
}