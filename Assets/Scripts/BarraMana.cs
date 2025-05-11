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
        regenerarMana();

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

    void regenerarMana()
    {
        if (mana < ManaMaximo)
        {
            Mana += velocidadRegeneracion * Time.deltaTime *0.75f;
        }
    }

        
}