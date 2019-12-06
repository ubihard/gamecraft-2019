using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBar : BarItem
{
    void Start()
    {
        EventManager.Instance.magicButtonHitEvent.AddListener(AddToBar);
    }

    void Update()
    {
        if (value == maxValue)
        {
            EventManager.Instance.magicFilledEvent.Invoke();
            value = 0;
        }
    }
}
