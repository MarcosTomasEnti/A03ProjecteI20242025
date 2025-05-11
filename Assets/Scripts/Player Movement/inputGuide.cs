using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputGuide : MonoBehaviour
{
    public GameObject bounceBallText;
    public GameObject greatFireballText;
    public GameObject meteorText;
    public GameObject stunballText;
    public GameObject frostStormText;
    public GameObject thunderText;
    public GameObject laserBeamText;

    bool active = false;
    bool isRotating = false;
    GameObject magician;

    // Start is called before the first frame update
    void Start()
    {
        magician = GameObject.FindGameObjectWithTag("Player");
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

        if(active)
        {
            if(magician.GetComponent<PlayerMovement>().saveFile.unlockedBounceBall)
            {

            }
            if(magician.GetComponent<PlayerMovement>().saveFile.unlockedGreatFireball)
            {

            }
            if (magician.GetComponent<PlayerMovement>().saveFile.unlockedThunderCaster)
            {

            }
            if (magician.GetComponent<PlayerMovement>().saveFile.unlockedLaserBeam)
            {

            }
            if (magician.GetComponent<PlayerMovement>().saveFile.unlockedThunderCaster)
            {

            }
            if (magician.GetComponent<PlayerMovement>().saveFile.unlockedStormArea)
            {

            }
            if (magician.GetComponent<PlayerMovement>().saveFile.unlockedMeteor)
            {

            }


        }

    }
}
