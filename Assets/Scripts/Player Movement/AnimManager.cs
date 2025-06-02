using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public Animator animator;
   GameObject MagicCom;


    void Update()
    {
        if (MagicCom.GetComponent<MagicCombo>().pressedKeys > 0)
        {
            if (MagicCom.GetComponent<MagicCombo>().pressedKeys == 1)
            {
                animator.SetBool("Ataque1", true);
            }
            else
            {
                animator.SetBool("Ataque1", false);
            }

            if (MagicCom.GetComponent<MagicCombo>().pressedKeys == 2)
            {
                animator.SetBool("Ataque2", true);
            }
            else
            {
                animator.SetBool("Ataque2", false);
            }

            if (MagicCom.GetComponent<MagicCombo>().pressedKeys >= 3)
            {
                animator.SetBool("Ataque3", true);
            }
            else
            {
                animator.SetBool("Ataque3", false);
            }

        }
    }
}