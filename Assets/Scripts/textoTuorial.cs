using System;
using UnityEngine;
using UnityEngine.UI;

public class textoTutorial : MonoBehaviour
{
    public Text textoUI;
    private int letraActual = 0;
    private float tiempoAnterior = 0f;
    private string textoCompleto = "Hola";
    private int velocidad = 25; // milisegundos entre letras

    void Update()
    {
        mostrarTextoProgresivo();
    }

    void mostrarTextoProgresivo()
    {
        float ahora = Time.time * 1000; // convertir a milisegundos
        if (letraActual < textoCompleto.Length && ahora - tiempoAnterior > velocidad)
        {
            letraActual++;
            tiempoAnterior = ahora;

            // Muestra el texto progresivamente
            if (textoUI != null)
                textoUI.text = textoCompleto.Substring(0, letraActual);
        }
    }
}