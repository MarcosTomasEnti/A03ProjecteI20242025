using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class MagicCombo : MonoBehaviour
{
    GameObject player;
    public GameObject pausa;
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

    GameObject animManager;

    //animManager.GetComponent<AnimManager>().ataque1 = true;


    int[] comboList = new int[5] {0,0,0,0,0};
    int pressedKeys = 0;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        barraMana = FindObjectOfType<BarraMana>();
        animManager = GameObject.FindObjectOfType<AnimManager>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pausa.GetComponent<PauseManager>().juegoPausado)
        { 
        if (Input.GetKeyDown(KeyCode.Q)) //Q = Melee
        {
            comboList[pressedKeys] = 1;
            pressedKeys++;
        }
        else if (Input.GetKeyDown(KeyCode.E)) //E = Projectile
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

        if (Input.GetMouseButtonDown(0) || pressedKeys >= 5)
        {

            getSpell();
            pressedKeys = 0;
        }
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
            animManager.GetComponent<AnimManager>().ataque1 = true;
            if (fireball != null)
            {
                firerb.velocity = direction.normalized * redBallSpeed;                
            }
        }
        else if (comboList[0] == 2 && comboList[1] == 0 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0 && barraMana != null && barraMana.Mana >= ManaBounceBall && player.GetComponent<PlayerMovement>().saveFile.unlockedBounceBall) // e boncy ball
        {
            barraMana.ManaConsumida(ManaBounceBall);
            GameObject bounchBall = Instantiate(BouncyBall.gameObject, transform.position, Quaternion.identity);
            Rigidbody2D bounchrb = bounchBall.GetComponent<Rigidbody2D>();
            animManager.GetComponent<AnimManager>().ataque1 = true;
            if (bounchBall != null)
            {
                bounchrb.velocity = direction.normalized * greenBallSpeed;
            }
        }
        else if (comboList[0] == 3 && comboList[1] == 0 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0)// r
        {

        }
        else if (comboList[0] == 1 && comboList[1] == 3 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0 && barraMana != null && barraMana.Mana >= ManaStun && player.GetComponent<PlayerMovement>().saveFile.unlockedStunBall) // q + r
        {
            barraMana.ManaConsumida(ManaStun);
            GameObject stunBall = Instantiate(StunBall.gameObject, transform.position, transform.rotation);
            Rigidbody2D stunB = stunBall.GetComponent<Rigidbody2D>();
            animManager.GetComponent<AnimManager>().ataque2 = true;
            if (stunBall != null)
            {
                stunB.velocity = direction.normalized * purpleBallSpeed;
            }

        }
        else if (comboList[0] == 1 && comboList[1] == 1 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0 && barraMana != null && barraMana.Mana >= ManaGreatFireBall && player.GetComponent<PlayerMovement>().saveFile.unlockedGreatFireball) // q + q  great fireball
        {
            barraMana.ManaConsumida(ManaGreatFireBall);
            GameObject greatFireBall = Instantiate(GreatFireBall.gameObject, transform.position, transform.rotation);
            Rigidbody2D GreatFBrb = greatFireBall.GetComponent<Rigidbody2D>();
            animManager.GetComponent<AnimManager>().ataque2 = true;
            if (greatFireBall != null)
            {
                GreatFBrb.velocity = direction.normalized * greenBallSpeed;
            }
        }
        else if (comboList[0] == 1 && comboList[1] == 2 && comboList[2] == 0 && comboList[3] == 0 && comboList[4] == 0 && barraMana != null && barraMana.Mana >= ManaMeteor && player.GetComponent<PlayerMovement>().saveFile.unlockedMeteor) // q + e meteor
        {
            barraMana.ManaConsumida(ManaMeteor);
            GameObject meteor = Instantiate(Meteoro.gameObject, new Vector2(0, 0), Quaternion.identity);
            animManager.GetComponent<AnimManager>().ataque2 = true;
        }
        else if (comboList[0] == 1 && comboList[1] == 2 && comboList[2] == 1 && comboList[3] == 2 && comboList[4] == 0 && barraMana != null && barraMana.Mana >= ManaThunder && player.GetComponent<PlayerMovement>().saveFile.unlockedThunderCaster) // q + e + q + e
        {
            barraMana.ManaConsumida(ManaThunder);
            GameObject thunderCaster = Instantiate(ThunderCaster.gameObject, transform.position, quaternion.Euler(0,0,0));
            Rigidbody2D thunderCasterRB = thunderCaster.GetComponent<Rigidbody2D>();
            thunderCasterRB.velocity = direction.normalized * thunderCasterSpeed;
            Debug.Log(thunderCasterSpeed);
            animManager.GetComponent<AnimManager>().ataque3 = true;
        }
        else if (comboList[0] == 1 && comboList[1] == 2 && comboList[2] == 3 && comboList[3] == 0 && comboList[4] == 0 && barraMana != null && barraMana.Mana >= ManaStorm && player.GetComponent<PlayerMovement>().saveFile.unlockedStormArea) // q + e + r  StormArea
        {
            barraMana.ManaConsumida(ManaStorm);
            GameObject DmgAreaStorm = Instantiate(StormArea.gameObject, new Vector2(0, 0), Quaternion.identity);
            animManager.GetComponent<AnimManager>().ataque3 = true;
        }
        else if (comboList[0] == 1 && comboList[1] == 2 && comboList[2] == 3 && comboList[3] == 4 && comboList[4] == 0 && barraMana != null && barraMana.Mana >= ManaLaserBeam && player.GetComponent<PlayerMovement>().saveFile.unlockedLaserBeam) // q + e + r + f + 
        {
            GameObject laserBeam = Instantiate(LaserBeam.gameObject, transform.position, transform.rotation);
            animManager.GetComponent<AnimManager>().ataque3 = true;
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