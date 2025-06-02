using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menu;
    public GameObject optionsMenu;
    public Toggle toogle;

    private void Start()
    {
        if(Screen.fullScreen)
        {
            toogle.isOn = true;
        }
        else
        {
            toogle.isOn = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseOptions()
    {
        menu.SetActive(true);
        optionsMenu.SetActive(false);
        menu.GetComponent<PauseManager>().Options = false;
    }

    public void FullScreen(bool pantallaCompleta)
    {
       Screen.fullScreen = pantallaCompleta;
    }
}
