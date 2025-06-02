using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainManager : MonoBehaviour
{
    public void OnStartClick()
    {
        AudioManager.levelMusic();
        SceneManager.LoadScene("Tutorial Vf2");
        
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