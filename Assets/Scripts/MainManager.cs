using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainManager : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("Tutorial");
    }   
    public void Options() 
    {
        SceneManager.LoadScene("MenúOptions");
    }
    public void Exit()
    {
        Application.Quit();
    }
}