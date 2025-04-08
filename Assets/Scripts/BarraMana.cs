using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BarraMana : MonoBehaviour
{
    public Slider visualMana;
    private const float ManaMaximo = 100;
    [SerializeField] private float mana = ManaMaximo;

    [SerializeField]
    private float velocidadRegeneracion = 1f;

    bool infiniteMana = false;

    private float deltaTimeMana = 0;
    [SerializeField]
    private float timeRestoreMana = 0.5f;

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
        deltaTimeMana += Time.deltaTime;

        if(deltaTimeMana >= timeRestoreMana)
        {
            RegenerarMana();
            deltaTimeMana = 0;
        }

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

    private void RegenerarMana()
    {
        if (Mana < ManaMaximo)
        {
            Mana += velocidadRegeneracion;
            deltaTimeMana = 0;
        }
    }     
}