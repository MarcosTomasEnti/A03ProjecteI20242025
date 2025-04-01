using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Slider visualHealth;
    private const float VidaMaxima = 100;
    [SerializeField] private float health = VidaMaxima;
    public float velocidadRegeneracion = 10f;
    public GameObject magician;

    public float Health
    {
        get { return health; }
        set
        {
            health = Mathf.Clamp(value, 0, VidaMaxima);
            ActualizarBarra();
        }
    }

    private void Start()
    {

        magician = GameObject.FindGameObjectWithTag("Player");

        visualHealth.maxValue = VidaMaxima;
        visualHealth.value = Health;
        
    }

    private void ActualizarBarra()
    {
        if (visualHealth != null)
        {
            visualHealth.value = Health;
        }
        if(Health <= 0) 
        {
            magician.GetComponent<PlayerMovement>().alive = false;
            magician.GetComponent<PlayerMovement>().destroyChildren();
        }
    }

    public void VidaConsumida(float cantidad)
    {
        if (Health >= cantidad)
        {
            Health -= cantidad;
        }
    }

    /*
    IEnumerator RegenerarMana()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (Health < VidaMaxima)
            {
                Health += velocidadRegeneracion * 0.1f;
            }
        }
    }
    */
}