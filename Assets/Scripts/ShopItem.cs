using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public enum ItemType
    {
        HealingHeart, BounceBall, GreatFireball, StunBall, Meteor, ThunderCaster, StormArea, LaserBeam
    }

    public ItemType itemType;

    GameObject player;

    CircleCollider2D circleCollider;
    SpriteRenderer sprite;
    TextMeshPro text;
    

    [SerializeField] Sprite heartSprite;
    [SerializeField] Sprite bounceBallSprite;
    [SerializeField] Sprite greatFireballSprite;
    [SerializeField] Sprite meteorSprite;
    [SerializeField] Sprite thunderCasterSprite;
    [SerializeField] Sprite stormAreaSprite;
    [SerializeField] Sprite stunBallSprite;
    [SerializeField] Sprite laserBeam;


    [SerializeField]
    int value;


    // Start is called before the first frame update
    void Start()
    {
        


        player = GameObject.FindGameObjectWithTag("Player");
        circleCollider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        text.text = "$" + value;

        switch (itemType)
        {
            case ItemType.HealingHeart:
                sprite.sprite = heartSprite;
                break;

            case ItemType.BounceBall:
                sprite.sprite = bounceBallSprite;
                break;

            case ItemType.GreatFireball:
                sprite.sprite = greatFireballSprite;
                break;

            case ItemType.StunBall:
                sprite.sprite = stunBallSprite;
                break;

            case ItemType.Meteor:
                sprite.sprite = meteorSprite;
                break;

            case ItemType.ThunderCaster:
                sprite.sprite = thunderCasterSprite;
                break;

            case ItemType.StormArea:
                sprite.sprite = stormAreaSprite;
                break;

            case ItemType.LaserBeam:
                sprite.sprite = laserBeam;
                break;

        }
    }

    private void Update()
    {
        if(text.color.g < 1)
            text.color += new Color(0, 0.01f, 0);
        if (text.color.g > 1)
            text.color = new Color(1, 1, text.color.b);

        if (text.color.b < 1)
            text.color += new Color(0, 0, 0.01f);
        if (text.color.b > 1)
            text.color = new Color(1, text.color.g, 1);


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.Mouse1))
        {
            if(collision.GetComponent<PlayerMovement>().saveFile.totalCoins >= value)
            { 
                collision.GetComponent<PlayerMovement>().saveFile.totalCoins -= value;
                collision.GetComponent<PlayerMovement>().coinCounter.GetComponent<CoinCounter>().updateCount(collision.GetComponent<PlayerMovement>().saveFile.totalCoins);
                activateItem();
                Destroy(gameObject);
            }
            else
            {
                text.color = new Color(1, 0, 0);   
            }
        }
    }

    void activateItem()
    {
        switch (itemType)
        {
            case ItemType.HealingHeart:
                FindObjectOfType<BarraVida>().VidaConsumida(-100);
            break;

            case ItemType.BounceBall:
                player.GetComponent<PlayerMovement>().saveFile.unlockedBounceBall = true;
            break;

            case ItemType.GreatFireball:
                player.GetComponent<PlayerMovement>().saveFile.unlockedGreatFireball = true;
            break;

            case ItemType.StunBall:
                player.GetComponent<PlayerMovement>().saveFile.unlockedStunBall = true;
            break;

            case ItemType.Meteor:
                player.GetComponent<PlayerMovement>().saveFile.unlockedMeteor = true;
            break;

            case ItemType.ThunderCaster:
                player.GetComponent<PlayerMovement>().saveFile.unlockedThunderCaster = true;
            break;

            case ItemType.StormArea:
                player.GetComponent<PlayerMovement>().saveFile.unlockedStormArea = true;
            break;

            case ItemType.LaserBeam:
                player.GetComponent<PlayerMovement>().saveFile.unlockedLaserBeam = true;
            break;

        }
    }
}
