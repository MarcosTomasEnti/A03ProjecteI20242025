using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinacionTeclas : MonoBehaviour
{
    public float tiempoMaximo = 3f; // Tiempo máximo permitido por tecla
    private float tiempoRestante; // Tiempo que se irá reduciendo
    private int pasoCombo; // Seguimiento del paso en la secuencia
    public int eleccion; // Ataque seleccionado
    private bool comboActivo; // Comrpueba que estamos elegiendo un combo

    void Start()
    {
        EleccionAtaque();
    }

    void Update()
    {
        if (!comboActivo) return; // No hacer nada si el combo no está activo

        // Reducir el tiempo restante
        tiempoRestante -= Time.deltaTime;

        // Si el tiempo se acaba antes de terminar el combo, romperlo sin reiniciar automáticamente
        if (tiempoRestante <= 0)
        {
            Debug.Log("Tiempo agotado");
            comboActivo = false;
            return;
        }

        // Detectar el combo según la elección
        switch (eleccion)
        {
            case 0:
                DetectarCombo(new KeyCode[] { KeyCode.Q, KeyCode.W }, Aturdir);
                break;
            case 1:
                DetectarCombo(new KeyCode[] { KeyCode.Q, KeyCode.E }, AtaquePotente);
                break;
            case 2:
                DetectarCombo(new KeyCode[] { KeyCode.Q, KeyCode.E }, MeteoroArea);
                break;
            case 3:
                DetectarCombo(new KeyCode[] { KeyCode.Q, KeyCode.R }, Quemadura);
                break;
            case 4:
                DetectarCombo(new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E }, AturdirArea);
                break;
            case 5:
                DetectarCombo(new KeyCode[] { KeyCode.Q, KeyCode.Q, KeyCode.E, KeyCode.E, KeyCode.R }, Bomba);
                break;
        }
    }

    void DetectarCombo(KeyCode[] secuencia, System.Action accion)
    {
        if (pasoCombo < secuencia.Length)
        {
            // Si el jugador presiona cualquier tecla
            if (Input.anyKeyDown)
            {
                // Verifica si la tecla presionada es la correcta
                if (Input.GetKeyDown(secuencia[pasoCombo]))
                {
                    pasoCombo++; // Avanzar en la secuencia
                    tiempoRestante = tiempoMaximo; // Reiniciar el tiempo para la siguiente tecla

                    if (pasoCombo == secuencia.Length)
                    {
                        accion?.Invoke(); // Ejecutar la acción cuando el combo se complete
                        comboActivo = false; // Finalizar el combo
                    }
                }
                else
                {
                    // Si la tecla presionada no es la esperada, el combo se rompe sin reiniciar
                    Debug.Log("Tecla incorrecta");
                    comboActivo = false;
                }
            }
        }
    }

    public void EleccionAtaque()
    {
        // El jugador elige la acción y según lo que escoja se dará un número para cada ataque permitiendo al switch acceder al ataque elegido, ese numero lo debe recibir eleccion
        pasoCombo = 0;
        tiempoRestante = tiempoMaximo;
        comboActivo = true; // Permite que el combo inicie
    }

    // Funciones de los efectos
    void Aturdir() => Debug.Log("Aturdimiento");
    void AtaquePotente() => Debug.Log("Ataque potente");
    void MeteoroArea() => Debug.Log("Meteoro lanzado!");
    void Quemadura() => Debug.Log("Quemadura");
    void AturdirArea() => Debug.Log("Aturdimiento en área");
    void Bomba() => Debug.Log("Bomba");
}