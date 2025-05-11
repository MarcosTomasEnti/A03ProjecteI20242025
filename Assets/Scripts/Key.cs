using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    CircleCollider2D collider;
    bool following = false;
    float diferencia;  //la diferencia de la segunda o demás llaves siguiendo al jugador
    float speed;
    GameObject player;
    GameObject followTarget;
    public static List<GameObject> collectedKeys = new List<GameObject>();

    [Tooltip("False = golden. True = dark")]
    public bool keyType = false;

    // Start is called before the first frame update

    private void Start()
    {
        if (keyType)
        {
            GetComponent<SpriteRenderer>().color = new Color(56 / 255, 0, 1);
        }

        collider = GetComponent<CircleCollider2D>();
        speed = Random.Range(1, 2);
    }


    // Update is called once per frame
    void Update()
    {
        LlavesSeguir();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !following)
        {
            following = true;
            player = collision.gameObject;

            if (collectedKeys.Count == 0)
            {
                followTarget = player;
            }
            else
            {
                followTarget = collectedKeys[collectedKeys.Count - 1];
            }

            collectedKeys.Add(gameObject);
            diferencia = 15 * collectedKeys.Count;

            if (!keyType)
            {
                player.GetComponent<PlayerMovement>().hasGoldKey = true;
                player.GetComponent<PlayerMovement>().goldKeyHeld = gameObject;
            }
            else
            {
                player.GetComponent<PlayerMovement>().hasDarkKey = true;
                player.GetComponent<PlayerMovement>().darkKeyHeld = gameObject;
            }

            collider.enabled = false;
        }
    }

    private void LlavesSeguir()
    {
        if (following && followTarget != null)
        {
            Vector3 direction = followTarget.transform.position - transform.position;
            if (direction.magnitude > 3f)
            {
                transform.position += direction / speed * 2f * Time.deltaTime;
            }
        }
        if (player != null && keyType == false)
        {
            if (player.GetComponent<PlayerMovement>().hasGoldKey == false)
            {
                player.GetComponent<PlayerMovement>().hasGoldKey = true;
                player.GetComponent<PlayerMovement>().goldKeyHeld = gameObject;
            }
        }
        else if (player != null && keyType == true)
        {
            if (player.GetComponent<PlayerMovement>().hasDarkKey == false)
            {
                player.GetComponent<PlayerMovement>().hasDarkKey = true;
                player.GetComponent<PlayerMovement>().darkKeyHeld = gameObject;
            }
        }
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Key : MonoBehaviour
//{
//    CircleCollider2D collider;
//    bool following = false;
//    float speed;
//    GameObject player;
//    public Transform followTarget;
//    public static List<GameObject> collectedKeys = new List<GameObject>();

//    [Tooltip("False = golden. True = dark")]
//    public bool keyType = false;

//    private void Start()
//    {
//        if (keyType)
//        {
//            GetComponent<SpriteRenderer>().color = new Color(56f / 255f, 0, 1f);
//        }

//        collider = GetComponent<CircleCollider2D>();
//        speed = Random.Range(1f, 2f);
//    }
//    private void Update()
//    {
//        LlavesSeguir();
//    }
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Player") && !following)
//        {
//            following = true;
//            player = collision.gameObject;

//            followTarget = collectedKeys.Count == 0 ? player.transform : collectedKeys[collectedKeys.Count - 1].transform;

//            collectedKeys.Add(gameObject);
//            collider.enabled = false;

//            var playerMovement = player.GetComponent<PlayerMovement>();
//            if (!keyType)
//            {
//                playerMovement.hasGoldKey = true;
//                playerMovement.goldKeyHeld = gameObject;
//            }
//            else
//            {
//                playerMovement.hasDarkKey = true;
//                playerMovement.darkKeyHeld = gameObject;
//            }
//        }
//    }
//    private void LlavesSeguir()
//    {
//        if (following && followTarget != null)
//        {
//            Vector3 direction = followTarget.position - transform.position;
//            if (direction.magnitude > 3f)
//            {
//                transform.position += direction / speed * 4 * Time.deltaTime;
//            }
//        }

//        if (player != null)
//        {
//            var playerMovement = player.GetComponent<PlayerMovement>();
//            if (!keyType && playerMovement.hasGoldKey == false)
//            {
//                playerMovement.hasGoldKey = true;
//                playerMovement.goldKeyHeld = gameObject;
//            }
//            else if (keyType && playerMovement.hasDarkKey == false)
//            {
//                playerMovement.hasDarkKey = true;
//                playerMovement.darkKeyHeld = gameObject;
//            }
//        }
//    }
//}