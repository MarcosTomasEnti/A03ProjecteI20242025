using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarraMana : MonoBehaviour
{
    public Slider visualMana;
    public float Mana;
    public int costoMana;

    private void Start()
    {
        StartCoroutine(tiempo());
    }

    /*private void Update()
    {
        visualMana.GetComponent<Slider>().value = Mana;
        if(Input.GetMouseButtonDown(1) && Mana >= costoMana)
        {
            Mana -= costoMana;

        }
    }*/

    public void ManaConsumida(float manaReducir)
    {
        Mana -= manaReducir;
    }

    IEnumerator tiempo()
    {
        while(true) 
        {
            yield return new WaitForSeconds(0.1f);
            if(Mana < 100)
            {
                Mana += 10f * Time.deltaTime;
            }
        }

    }
}