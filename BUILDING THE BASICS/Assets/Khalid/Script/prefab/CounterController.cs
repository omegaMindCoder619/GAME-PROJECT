using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterController : MonoBehaviour
{
    public TMP_Text text_counter;
    public float counter; 
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text_counter.text = counter.ToString() + "xp";
    }
}
