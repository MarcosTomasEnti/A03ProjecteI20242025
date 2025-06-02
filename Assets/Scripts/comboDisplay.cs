using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboDisplay : MonoBehaviour
{
    int[] comboList = new int[5] { 0, 0, 0, 0, 0 };
    int pressedKeys = 0;


    public Sprite Q;
    public Sprite E;
    public Sprite R;
    public Sprite F;
    public GameObject[] runeGameObject;
    public GameObject pausa;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!pausa.GetComponent<PauseManager>().juegoPausado)
        {
            if (Input.GetKeyDown(KeyCode.Q)) //Q = Melee
            {
                runeGameObject[pressedKeys].GetComponent<SpriteRenderer>().sprite = Q;
                pressedKeys++;
            }
            else if (Input.GetKeyDown(KeyCode.E)) //E = Projectile
            {
                runeGameObject[pressedKeys].GetComponent<SpriteRenderer>().sprite = E;
                pressedKeys++;
            }
            else if (Input.GetKeyDown(KeyCode.R)) // R = Fisicas
            {
                runeGameObject[pressedKeys].GetComponent<SpriteRenderer>().sprite = R;
                pressedKeys++;
            }
            else if (Input.GetKeyDown(KeyCode.F)) // F = Elemental
            {
                runeGameObject[pressedKeys].GetComponent<SpriteRenderer>().sprite = F;
                pressedKeys++;
            }

            if (Input.GetMouseButtonDown(0) || pressedKeys >= 5)
            {
                pressedKeys = 0;
                for (int i = 0; i < comboList.Length; i++)
                {
                    runeGameObject[i].GetComponent<SpriteRenderer>().sprite = null;
                    comboList[i] = 0;
                }
            }
        }

    }
}
