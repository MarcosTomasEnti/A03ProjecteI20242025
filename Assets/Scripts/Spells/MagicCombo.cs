using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class MagicCombo : MonoBehaviour
{

    public GameObject fireBall;
    public GameObject BouncyBall;
    public GameObject GreatFireBall;
    public GameObject Meteoro;
    public GameObject ThunderCaster;
    public GameObject LaserBeam;
    public GameObject StormArea;
    public GameObject StunBall;

    public float redBallSpeed = 20;
    public float purpleBallSpeed = 20;
    public float greenBallSpeed = 40;
    public float thunderCasterSpeed = 10f;

    Vector2 mousePos;
    Vector3 direction;

    //Mana de los disparos
    float ManaFireBall = 10;
    float ManaGreatFireBall = 40;
    float ManaBounceBall = 5;
    float ManaMeteor = 70;
    float ManaThunder = 70;
    float ManaStorm = 35;
    float ManaStun = 25;




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


        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        



        if (comboList[0] == 0 && comboList[1] == 0 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0) // no spell input, just casting
        {
            Debug.Log("Null spell");
        }
        else if (comboList[0] == 1 && comboList[1] == 0 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0) // q fireball attack
        {
            GetComponent<BarraMana>().ManaConsumida(ManaFireBall);
            GameObject fireball = Instantiate(fireBall.gameObject, transform.position, transform.rotation);
            Rigidbody2D firerb = fireball.GetComponent<Rigidbody2D>();
            if (fireball != null)
            {
                firerb.velocity = direction.normalized * redBallSpeed;
            }
        }
        else if (comboList[0] == 2 && comboList[1] == 0 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0) // e boncy ball
        {
            GetComponent<BarraMana>().ManaConsumida(ManaBounceBall);
            GameObject bounchBall = Instantiate(BouncyBall.gameObject, transform.position, Quaternion.identity);
            Rigidbody2D bounchrb = bounchBall.GetComponent<Rigidbody2D>();
            if (bounchBall != null)
            {
                bounchrb.velocity = direction.normalized * greenBallSpeed;
            }
        }
        else if (comboList[0] == 3 && comboList[1] == 0 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0)// r
        {

        }
        else if (comboList[0] == 1 && comboList[1] == 3 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0) // q + r
        {
            GetComponent<BarraMana>().ManaConsumida(ManaStun);
            GameObject stunBall = Instantiate(StunBall.gameObject, transform.position, transform.rotation);
            Rigidbody2D stunB = stunBall.GetComponent<Rigidbody2D>();
            if (stunBall != null)
            {
                stunB.velocity = direction.normalized * purpleBallSpeed;
            }

        }
        else if (comboList[0] == 1 && comboList[1] == 1 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0) // q + q  great fireball
        {
            GetComponent<BarraMana>().ManaConsumida(ManaGreatFireBall);
            GameObject greatFireBall = Instantiate(GreatFireBall.gameObject, transform.position, transform.rotation);
            Rigidbody2D GreatFBrb = greatFireBall.GetComponent<Rigidbody2D>();
            if (greatFireBall != null)
            {
                GreatFBrb.velocity = direction.normalized * greenBallSpeed;
            }
        }
        else if (comboList[0] == 1 && comboList[1] == 2 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0) // q + e meteor
        {
            GetComponent<BarraMana>().ManaConsumida(ManaMeteor);
            GameObject meteor = Instantiate(Meteoro.gameObject, new Vector2(0, 0), Quaternion.identity);
        }
        else if (comboList[0] == 1 && comboList[1] == 2 && comboList[2] == 1 && comboList[3] == 2 && comboList[4] == 0) // q + e + q + e
        {
            GetComponent<BarraMana>().ManaConsumida(ManaThunder);
            GameObject thunderCaster = Instantiate(ThunderCaster.gameObject, transform.position, quaternion.Euler(0,0,0));
            Rigidbody2D thunderCasterRB = thunderCaster.GetComponent<Rigidbody2D>();
            thunderCasterRB.velocity = direction.normalized * thunderCasterSpeed;
        }
        else if (comboList[0] == 1 && comboList[1] == 2 && comboList[2] == 3 && comboList[3] == 0 && comboList[4] == 0) // q + e + r  StormArea
        {
            GetComponent<BarraMana>().ManaConsumida(ManaStorm);
            GameObject DmgAreaStorm = Instantiate(StormArea.gameObject, new Vector2(0, 0), Quaternion.identity);
        }
        else if (comboList[0] == 1 && comboList[1] == 2 && comboList[2] == 3 && comboList[3] == 4 && comboList[4] == 0) // q + e + r + f + 
        {
            GameObject laserBeam = Instantiate(LaserBeam.gameObject, transform.position, transform.rotation);
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

