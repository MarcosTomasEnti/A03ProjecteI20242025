using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPrueba : MonoBehaviour
{
   private Vector2 input = Vector2.zero;

    private void Update()
    {
        input.y = Input.GetAxisRaw("Vertical");
    }

    public float GetAxisRawY()
    {
        return input.y;
    }
}
