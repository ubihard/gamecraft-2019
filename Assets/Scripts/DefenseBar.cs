using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseBar : BarItem
{
    void Start()
    {
        EventManager.Instance.defenseButtonHitEvent.AddListener(AddToBar);
    }

    void Update()
    {
        Image bar = GetComponent<Image>();
        bar.fillAmount = value * 0.2f;
        if (value == maxValue)
        {
            value = 0;
            EventManager.Instance.defenseFilledEvent.Invoke();
        }
    }
}
