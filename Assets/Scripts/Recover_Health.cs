using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 50;
    [SerializeField] private AudioClip audioClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Funcion de Curar vida
            AudioManager.Instance.PlayAudioClip(audioClip, AudioManager.AudioType.Items);
            Destroy(gameObject.gameObject);
            FindObjectOfType<BarraVida>().VidaConsumida(-health);
        }
    }
}