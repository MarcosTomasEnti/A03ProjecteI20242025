using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject manuPausa;
    public GameObject Magician;
    public GameObject menuOptions;
    public bool juegoPausado = false;
    public bool Options = false;
    private void OnEnable()
    {
        PausarJuego();
        
    }
    private void Update()
    {
        if (!Options)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (juegoPausado)
                {
                    ReanudarJuego();
                }
                else
                {
                    PausarJuego();
                }
            }
        }
    }

   public void ReanudarJuego()
    {
        if (!Options)
        {
            Magician.GetComponent<WandAim>().Pausa = false;
            juegoPausado = false;
            manuPausa.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void PausarJuego()
    {
        Magician.GetComponent<WandAim>().Pausa = true;
        juegoPausado = true;
        manuPausa.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Opciones()
    {
        manuPausa.SetActive(false);
        menuOptions.SetActive(true);
        Options = true;
    }

    public void ReturnPause()
    {
        Options = false;
    }
}
