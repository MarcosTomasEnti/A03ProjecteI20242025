using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(MovimientoPrueba))]

public class CharacterAnimationControl : MonoBehaviour
{
    private Animator animator;
    private MovimientoPrueba characterController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<MovimientoPrueba>();
    }
    private void Update()
    {
        animator.SetFloat("axisY", characterController.GetAxisRawY());
       
    }

}
