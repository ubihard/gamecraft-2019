using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBar : BarItem
{
    void Start()
    {
        EventManager.Instance.attackButtonHitEvent.AddListener(AddToBar);
    }

    void Update()
    {
        if (value == maxValue)
        {
            EventManager.Instance.attackFilledEvent.Invoke();
            value = 0;
        }
    }
}
