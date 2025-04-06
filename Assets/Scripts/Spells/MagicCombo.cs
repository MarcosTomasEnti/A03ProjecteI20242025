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

    public const float redBallSpeed = 20;
    public const float purpleBallSpeed = 20;
    public const float greenBallSpeed = 40;
    public const float thunderCasterSpeed = 40f;

    public BarraMana barraMana;

    Vector2 mousePos;
    Vector3 direction;

    //Mana de los disparos
    int ManaFireBall = 10;
    int ManaGreatFireBall = 40;
    int ManaBounceBall = 5;
    int ManaMeteor = 70;
    int ManaThunder = 70;
    int ManaStorm = 35;
    int ManaStun = 25;
    float ManaLaserBeam = 20;




    int[] comboList = new int[5] {0,0,0,0,0};
    int pressedKeys = 0;




    // Start is called before the first frame update
    void Start()
    {
        barraMana = FindObjectOfType<BarraMana>();
        if (barraMana == null)
        {
            Debug.LogError("No se encontró BarraMana en la escena!");
            enabled = false; // Desactiva este script si no hay BarraMana
        }
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
        else if (comboList[0] == 1 && comboList[1] == 0 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0 && barraMana != null && barraMana.Mana >= ManaFireBall) // q fireball attack
        {
            barraMana.ManaConsumida(ManaFireBall);
            GameObject fireball = Instantiate(fireBall.gameObject, transform.position, transform.rotation);
            Rigidbody2D firerb = fireball.GetComponent<Rigidbody2D>();
            if (fireball != null)
            {
                firerb.velocity = direction.normalized * redBallSpeed;
            }
        }
        else if (comboList[0] == 2 && comboList[1] == 0 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0 && barraMana != null && barraMana.Mana >= ManaBounceBall) // e boncy ball
        {
            barraMana.ManaConsumida(ManaBounceBall);
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
        else if (comboList[0] == 1 && comboList[1] == 3 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0 && barraMana != null && barraMana.Mana >= ManaStun) // q + r
        {
            barraMana.ManaConsumida(ManaStun);
            GameObject stunBall = Instantiate(StunBall.gameObject, transform.position, transform.rotation);
            Rigidbody2D stunB = stunBall.GetComponent<Rigidbody2D>();
            if (stunBall != null)
            {
                stunB.velocity = direction.normalized * purpleBallSpeed;
            }

        }
        else if (comboList[0] == 1 && comboList[1] == 1 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0 && barraMana != null && barraMana.Mana >= ManaGreatFireBall) // q + q  great fireball
        {
            barraMana.ManaConsumida(ManaGreatFireBall);
            GameObject greatFireBall = Instantiate(GreatFireBall.gameObject, transform.position, transform.rotation);
            Rigidbody2D GreatFBrb = greatFireBall.GetComponent<Rigidbody2D>();
            if (greatFireBall != null)
            {
                GreatFBrb.velocity = direction.normalized * greenBallSpeed;
            }
        }
        else if (comboList[0] == 1 && comboList[1] == 2 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0 && barraMana != null && barraMana.Mana >= ManaMeteor) // q + e meteor
        {
            barraMana.ManaConsumida(ManaMeteor);
            GameObject meteor = Instantiate(Meteoro.gameObject, new Vector2(0, 0), Quaternion.identity);
        }
        else if (comboList[0] == 1 && comboList[1] == 2 && comboList[2] == 1 && comboList[3] == 2 && comboList[4] == 0 && barraMana != null && barraMana.Mana >= ManaThunder) // q + e + q + e
        {
            barraMana.ManaConsumida(ManaThunder);
            GameObject thunderCaster = Instantiate(ThunderCaster.gameObject, transform.position, quaternion.Euler(0,0,0));
            Rigidbody2D thunderCasterRB = thunderCaster.GetComponent<Rigidbody2D>();
            thunderCasterRB.velocity = direction.normalized * thunderCasterSpeed;
            Debug.Log(thunderCasterSpeed);
        }
        else if (comboList[0] == 1 && comboList[1] == 2 && comboList[2] == 3 && comboList[3] == 0 && comboList[4] == 0 && barraMana != null && barraMana.Mana >= ManaStorm) // q + e + r  StormArea
        {
            barraMana.ManaConsumida(ManaStorm);
            GameObject DmgAreaStorm = Instantiate(StormArea.gameObject, new Vector2(0, 0), Quaternion.identity);
        }
        else if (comboList[0] == 1 && comboList[1] == 2 && comboList[2] == 3 && comboList[3] == 4 && comboList[4] == 0 && barraMana != null && barraMana.Mana >= ManaLaserBeam) // q + e + r + f + 
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