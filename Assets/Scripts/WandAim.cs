using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WandAim : MonoBehaviour
{
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = direction;
        
        if (mousePos.x - transform.parent.position.x < 0)
        {
            transform.localPosition = new Vector3(-1.5f, -1, 0);
            sprite.flipX = false;
        }
        else
        {
            transform.localPosition = new Vector3(1.5f, -1, 0);
            sprite.flipX = true;
        }
    }
}
