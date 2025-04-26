using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        text.text = ": 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateCount(int amount)
    {
        text.text = ": " + amount;
    }
}
