using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    [SerializeField]
    GameObject hand;

    public Animator animator;
    public bool ataque1 = false;
    public bool ataque2 = false;
    public bool ataque3 = false;
    
    float timer = 0;
    float timerCap = 0.75f;
    bool inMotion = false;

    void Update()
    {
        if (ataque1)
        {
            animator.SetBool("Ataque1", true);
            inMotion = true;
            hand.SetActive(false);
        }
        else if (ataque2)
        {
            animator.SetBool("Ataque2", true);
            inMotion = true;
            hand.SetActive(false);
        }
        else if (ataque3)
        {
            animator.SetBool("Ataque3", true);
            inMotion = true;
            hand.SetActive(false);
        }

        if (inMotion)
            timer += Time.deltaTime;

        if (timer >= timerCap && inMotion)
        {
            inMotion = false;
            ataque1 = false;
            ataque2 = false;
            ataque3 = false;
            animator.SetBool("Ataque1", false);
            animator.SetBool("Ataque2", false);
            animator.SetBool("Ataque3", false);
            timer = 0;
            hand.SetActive(true);
        }

       
    }
}