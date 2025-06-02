using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover_Mana : MonoBehaviour
{
    public float recoverMana;
    [SerializeField] private AudioClip audioClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Funcion de Curar mana
            AudioManager.Instance.PlayAudioClip(audioClip, AudioManager.AudioType.Items);
            Destroy(gameObject.gameObject);
            FindObjectOfType<BarraMana>().ManaRestaurar(recoverMana);
        }
    }
}