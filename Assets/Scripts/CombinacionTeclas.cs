using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinacionTeclas : MonoBehaviour
{
    public float tiempoMaximo = 3f; // Tiempo máximo permitido por tecla
    private float tiempoRestante; // Tiempo que se irá reduciendo
    private int pasoCombo; // Seguimiento del paso en la secuencia
    public int eleccion; // Combo seleccionado

    void Start()
    {
        tiempoRestante = tiempoMaximo;
        ReiniciarCombo();
    }

    void Update()
    {
        // Reducir el tiempo restante
        tiempoRestante -= Time.deltaTime;

        // Si se acaba el tiempo antes de terminar el combo, reiniciar solo el tiempo
        if (tiempoRestante <= 0)
        {
            ReiniciarCombo();
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
                        ReiniciarCombo(); // Volver a empezar el combo
                    }
                }
                else
                {
                    // Si la tecla presionada no es la esperada, se rompe el combo
                    Debug.Log("¡Error! Tecla incorrecta. Combo reiniciado.");
                    ReiniciarCombo();
                }
            }
        }
    }

    void ReiniciarCombo()
    {
        pasoCombo = 0;
        tiempoRestante = tiempoMaximo;
    }

    // Funciones de los efectos
    void Aturdir() => Debug.Log("¡Aturdimiento activado!");
    void AtaquePotente() => Debug.Log("¡Ataque potente realizado!");
    void MeteoroArea() => Debug.Log("¡Meteoro en área lanzado!");
    void Quemadura() => Debug.Log("¡Quemadura aplicada!");
    void AturdirArea() => Debug.Log("¡Aturdimiento en área ejecutado!");
    void Bomba() => Debug.Log("¡Bomba detonada!");
}