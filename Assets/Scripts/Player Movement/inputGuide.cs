using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputGuide : MonoBehaviour
{
    bool active = false;
    bool isRotating = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.Tab))
        {
            //isRotating = true;
            
            if (active)
                active = false;
            else
                active = true;
                
        }

        /*
        if (active && isRotating)
        {
            if (transform.eulerAngles.x >= 90)
            {
                transform.eulerAngles = new Vector3(90, 0, 0);
                isRotating = false;

            }
            else
            {
                transform.eulerAngles += new Vector3(50 * Time.deltaTime, 0, 0);
            }

        }
        else if (!active && isRotating)
        {
            if (transform.eulerAngles.x <= 0)
            {
                transform.eulerAngles = Vector3.zero;
                isRotating = false;

            }
            else
            {
                transform.eulerAngles -= new Vector3(50 * Time.deltaTime, 0, 0);
            }
            
        }
        */

        if(!active)
            transform.eulerAngles = new Vector3(90, 0, 0);
        else if(active && !isRotating)
        {
            transform.eulerAngles = Vector3.zero;
        }

    }
}
