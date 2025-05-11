using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    CircleCollider2D collider;
    bool following = false;
    float speed;
    GameObject player;
    public Transform followTarget;
    public static List<GameObject> collectedKeys = new List<GameObject>();

    [Tooltip("False = golden. True = dark")]
    public bool keyType = false;

    private void Start()
    {
        if (keyType)
        {
            GetComponent<SpriteRenderer>().color = new Color(56f / 255f, 0, 1f);
        }

        collider = GetComponent<CircleCollider2D>();
        speed = Random.Range(1f, 2f);
    }
    private void Update()
    {
        LlavesSeguir();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !following)
        {
            following = true;
            player = collision.gameObject;

            followTarget = collectedKeys.Count == 0 ? player.transform : collectedKeys[collectedKeys.Count - 1].transform;

            collectedKeys.Add(gameObject);
            collider.enabled = false;

            var playerMovement = player.GetComponent<PlayerMovement>();
            if (!keyType)
            {
                playerMovement.hasGoldKey = true;
                playerMovement.goldKeyHeld = gameObject;
            }
            else
            {
                playerMovement.hasDarkKey = true;
                playerMovement.darkKeyHeld = gameObject;
            }
        }
    }
    private void LlavesSeguir()
    {
        if (following && followTarget != null)
        {
            Vector3 direction = followTarget.position - transform.position;
            if (direction.magnitude > 3f)
            {
                transform.position += direction / speed * 4 * Time.deltaTime;
            }
        }

        if (player != null)
        {
            var playerMovement = player.GetComponent<PlayerMovement>();
            if (!keyType && playerMovement.hasGoldKey == false)
            {
                playerMovement.hasGoldKey = true;
                playerMovement.goldKeyHeld = gameObject;
            }
            else if (keyType && playerMovement.hasDarkKey == false)
            {
                playerMovement.hasDarkKey = true;
                playerMovement.darkKeyHeld = gameObject;
            }
        }
    }
}