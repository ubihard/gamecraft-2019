using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBar : BarItem
{
    void Start()
    {
        EventManager.Instance.potionButtonHitEvent.AddListener(AddToBar);
    }

    void Update()
    {
        if (value == maxValue)
        {
            EventManager.Instance.potionFilledEvent.Invoke();
            value = 0;
        }
    }
}
