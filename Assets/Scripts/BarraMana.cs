using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BarraMana : MonoBehaviour
{
    public Slider visualMana;
    private const float ManaMaximo = 100;
    [SerializeField] private float mana = ManaMaximo;
    public float velocidadRegeneracion = 10f;

    public float Mana
    {
        get { return mana; }
        set
        {
            mana = Mathf.Clamp(value, 0, ManaMaximo);
            ActualizarBarra();
        }
    }

    private void Start()
    {
        if (visualMana == null)
        {
            Debug.LogError("Error: visualMana no está asignado en el Inspector.");
            visualMana = GetComponent<Slider>();
            if (visualMana == null)
            {
                Debug.LogError("No se encontró componente Slider en este GameObject.");
            }
        }

        visualMana.maxValue = ManaMaximo;
        visualMana.value = Mana;

        StartCoroutine(RegenerarMana());
    }

    private void ActualizarBarra()
    {
        if (visualMana != null)
        {
            visualMana.value = Mana;
        }
    }

    public void ManaConsumida(int cantidad)
    {
        if (Mana >= cantidad)
        {
            Mana -= cantidad;
        }
    }

    IEnumerator RegenerarMana()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (Mana < ManaMaximo)
            {
                Mana += velocidadRegeneracion * 0.1f;
            }
        }
    }
}