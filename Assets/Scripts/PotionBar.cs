using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionBar : BarItem
{
    void Start()
    {
        EventManager.Instance.potionButtonHitEvent.AddListener(AddToBar);
    }

    void Update()
    {
        Image bar = GetComponent<Image>();
        bar.fillAmount = value * 0.2f;
        if (value == maxValue)
        {
            value = 0;
            EventManager.Instance.potionFilledEvent.Invoke();
        }
    }
}
