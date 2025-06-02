using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour
{
    public void ReturnTC()
    {
        SceneManager.LoadScene("Title Screen");
    }
    public void Sound()
    {
        SceneManager.LoadScene("Sound Options");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ReturnOptions()
    {
        SceneManager.LoadScene("MenúOptions");
    }

}
