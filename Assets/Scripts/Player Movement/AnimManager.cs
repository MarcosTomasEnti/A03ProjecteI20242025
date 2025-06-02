using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
   public Animator animator;
   public bool ataque1 = false;
   public bool ataque2 = false;
   public bool ataque3 = false;


    void Update()
    {
            if (ataque1)
            {
                animator.SetBool("Ataque1", true);
            }
            else
            {
                animator.SetBool("Ataque1", false);
            }

            if (ataque2)
            {
                animator.SetBool("Ataque2", true);
            }
            else
            {
                animator.SetBool("Ataque2", false);
            }

            if (ataque3)
            {
                animator.SetBool("Ataque3", true);
            }
            else
            {
                animator.SetBool("Ataque3", false);
            }
        ataque1 = false;
        ataque2 = false;
        ataque3 = false;
    }
}