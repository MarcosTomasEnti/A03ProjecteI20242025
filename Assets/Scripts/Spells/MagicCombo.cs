using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagicCombo : MonoBehaviour
{
    int[] comboList = new int[5] {0,0,0,0,0};
    int pressedKeys = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q)) //Q = Melee
        {
            comboList[pressedKeys] = 1;
            pressedKeys++;
        }
        else if(Input.GetKeyDown(KeyCode.E)) //E = Projectile
        {
            comboList[pressedKeys] = 2;
            pressedKeys++;
        }
        else if (Input.GetKeyDown(KeyCode.R)) // R = Fisicas
        {
            comboList[pressedKeys] = 3;
            pressedKeys++;
        }
        else if (Input.GetKeyDown(KeyCode.F)) // F = Elemental
        {
            comboList[pressedKeys] = 4;
            pressedKeys++;
        }
        
        if(Input.GetMouseButtonDown(0) || pressedKeys >= 5)
        {

            getSpell();
            pressedKeys = 0;
        }
    }

    void getSpell()
    {



        //1 = basic
        //2 = area
        //3 = stun
        //4 = special


        if (comboList[0] == 0 && comboList[1] == 0 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0)
        {
            Debug.Log("Null spell");
        }
        else if (comboList[0] == 1 && comboList[1] == 0 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0)
        {
            Debug.Log("basic");
        }
        else if (comboList[0] == 2 && comboList[1] == 0 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0)
        {
            Debug.Log("area");
        }
        else if (comboList[0] == 3 && comboList[1] == 0 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0)
        {
            Debug.Log("stun");
        }
        else if (comboList[0] == 4 && comboList[1] == 0 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0)
        {
            Debug.Log("special");
        }
        else if (comboList[0] == 1 && comboList[1] == 1 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0)
        {
            Debug.Log("Daño daño");
        }
        else if (comboList[0] == 1 && comboList[1] == 2 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0)
        {
            Debug.Log("daño area");
        }
        else if (comboList[0] == 1 && comboList[1] == 3 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0)
        {
            Debug.Log("basico stun");
        }
        else if (comboList[0] == 1 && comboList[1] == 4 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0)
        {
            Debug.Log("basico efecto");
        }
        else
        {
            Debug.Log("Null spell");
        }

        for (int i = 0; i < 5; i++) 
        {
            comboList[i] = 0;
        }
    }



}