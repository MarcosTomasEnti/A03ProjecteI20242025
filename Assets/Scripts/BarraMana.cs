using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BarraMana : MonoBehaviour
{
    public Slider visualMana;
    private const float ManaMaximo = 100;
    [SerializeField] private float mana = ManaMaximo;
    public float velocidadRegeneracion = 10f;

    bool infiniteMana = false;

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
    

        visualMana.maxValue = ManaMaximo;
        visualMana.value = Mana;

        StartCoroutine(RegenerarMana());
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.F2))
        {
            infiniteMana = true;
        }

        if(infiniteMana)
        {
            Mana = 100;
        }

    }

    private void ActualizarBarra()
    {
        if (visualMana != null)
        {
            visualMana.value = Mana;
        }
    }

    public void ManaConsumida(float cantidad)
    {
        Mana -= cantidad;
    }

    IEnumerator RegenerarMana()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (Mana < ManaMaximo)
            {
                Mana += velocidadRegeneracion * Time.deltaTime * 50;
            }
        }
    }
}