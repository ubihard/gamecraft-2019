using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBar : BarItem
{
    void Start()
    {
        EventManager.Instance.defenseButtonHitEvent.AddListener(AddToBar);
    }

    void Update()
    {
        if (value == maxValue)
        {
            EventManager.Instance.defenseFilledEvent.Invoke();
            value = 0;
        }
    }
}
