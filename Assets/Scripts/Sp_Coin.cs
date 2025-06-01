using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sp_Coin : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

   
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            // Sumar una moneda al jugador
            AudioManager.Instance.PlayAudioClip(audioClip);
            FindObjectOfType<PlayerMovement>().MonedaConseguida();
            Destroy(gameObject.gameObject);
        }
    }
}
