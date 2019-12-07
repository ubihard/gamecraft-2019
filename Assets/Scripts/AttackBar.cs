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
        GameObject obj = (Image) GameObject.FindWithTag("AFiller");
        obj.fill
        value + 0.2f;
        this.fillAmount = value;
        if (value == maxValue)
        {
            value = 0;
            EventManager.Instance.attackFilledEvent.Invoke();
        }
    }
}