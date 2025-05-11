using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainEnemy : MonoBehaviour
{
    private CircleCollider2D hitBox;
    SpriteRenderer sprite;
    // Start is called before the first frame update
   void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (sprite.color.a < 1)
        {

            sprite.color += new Color(0, 0, 0, 2 * Time.deltaTime);
        }
        else if (sprite.color.a > 1)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
        }
    }
    public void RecibirGolpe()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
    }
}
