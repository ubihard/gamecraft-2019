using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarItem : MonoBehaviour
{
    public int maxValue = 5;
    public int value { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        value = 0;
    }

    public void AddToBar()
    {
        value += 1;
    }
}
