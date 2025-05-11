using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BubbleDamage : MonoBehaviour
{
    [SerializeField] private Transform BubbleDmg;
// Referencia al texto de TextMeshPro
    public float bubbleSpeed = 5f;

    private void Start()
    {
        Instantiate(BubbleDmg, transform.position, Quaternion.identity);
    }
}