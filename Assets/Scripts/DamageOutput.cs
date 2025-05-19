using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageOutput : MonoBehaviour
{
    TextMeshPro text;
    private void Start()
    {
        text = GetComponent<TextMeshPro>();
        Destroy(gameObject, 5);
    }

    public void getNumber(float damage)
    {
        text = GetComponent<TextMeshPro>();
        text.text = "" + damage.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, Time.deltaTime, 0);
        text.color -= new Color(0, 0, 0, 0.5f * Time.deltaTime);
    }
}
