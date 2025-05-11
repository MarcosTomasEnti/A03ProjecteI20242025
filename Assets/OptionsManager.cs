using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Options_Manager : MonoBehaviour
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
}
