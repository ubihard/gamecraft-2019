using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAttackBar : BarItem
{
    public float originalFillInterval = 5f;

    private float fillInterval;

    void Start()
    {
        fillInterval = originalFillInterval;
    }

    void Update()
    {
        CheckTimeInterval();

        Image bar = GetComponent<Image>();
        bar.fillAmount = value * 0.2f;
        if (value == maxValue)
        {
            value = 0;
            EventManager.Instance.bossAttackFilledEvent.Invoke();
        }
    }

    void CheckTimeInterval()
    {
        fillInterval -= Time.deltaTime;
        if (fillInterval <= 0f)
        {
            AddToBar();
            fillInterval = originalFillInterval;
        }
    }
}
