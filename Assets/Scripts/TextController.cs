using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TextController : MonoBehaviour
{
    private Collider2D m_collider;
    private TextMeshPro text;
    bool desaparece = false;
    private void Start()
    {
        text = GetComponent<TextMeshPro>();
        m_collider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if(desaparece)
        {
            transform.position += new Vector3(0,  0.5f*Time.deltaTime, 0);
            text.color -= new Color(0, 0, 0, 0.5f * (Time.deltaTime) / 2);
            Destroy(gameObject, 5f);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entra en contacto");
        if (collision.gameObject.CompareTag("Bullet") )
        {
            Debug.Log("Entra en el if");
           desaparece=true;

        }
    }

}