using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsula : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2D;
    // Start is called before the first frame update

    public float horizontalSpeed;
    public float jumpForce;

    void Start()
    {
        if(rb2D == null)
        {
            Debug.Log("Rigidbody2D is not initlialitzed");
            rb2D = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.H))
        {
            // rb2D.velocity = new Vector3(-15f, 0);
            rb2D.velocity = new Vector3(0-horizontalSpeed, 0);
        }
        if (Input.GetKey(KeyCode.J))
        {
            // rb2D.velocity = new Vector3(15f, 0);
            rb2D.velocity = new Vector3(horizontalSpeed, 0);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Jump");
            rb2D.AddForce(new Vector2(0, jumpForce));
        }
    }
}
