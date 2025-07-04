using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SpawnPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    
    GameObject button;
   // GameObject text;
 
    private void Start()
    {
        button = transform.GetChild(0).gameObject;
       // text = transform.GetChild(0).GetChild(0).gameObject;
    }
    // Update is called once per frame
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().alive == true)
        {
            transform.eulerAngles = new Vector3(90, 0, 0);
            button.GetComponent<Image>().color = new Color(255, 255 , 255, 0);
          // text.GetComponent<LiberationSans>().color = new Color(255, 255, 255, 0);
        }
        else  
        {
            transform.eulerAngles = Vector3.zero;
            button.GetComponent<Image>().color += new Color(0, 0, 0, 0.5f * Time.deltaTime);
           // text.GetComponent<Image>().color += new Color(0, 0, 0, 0.5f * Time.deltaTime);
        }
        
    }
    public void OnButtonClick()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().alive == false)
        {
            if (SceneManager.GetActiveScene().name == "Tutorial Vf2")
            {
                SceneManager.LoadScene("Tutorial Vf2");
            }
            else if (SceneManager.GetActiveScene().name == "LVL1")
            {
                SceneManager.LoadScene("LVL1");
            }
            else if (SceneManager.GetActiveScene().name == "LVL2")
            {
                SceneManager.LoadScene("LVL2");
            }
            else if (SceneManager.GetActiveScene().name == "LVL 3")
            {
                SceneManager.LoadScene("LVL 3");
            }
            else if (SceneManager.GetActiveScene().name == "LVL4 F")
            {
                SceneManager.LoadScene("LVL4 F");
            }
        }
    }
}
