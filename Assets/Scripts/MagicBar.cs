using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBar : BarItem
{
    void Start()
    {
        EventManager.Instance.magicButtonHitEvent.AddListener(AddToBar);
    }

    void Update()
    {
        Image bar = GetComponent<Image>();
        bar.fillAmount = value * 0.2f;
        if (value == maxValue)
        {
            StartCoroutine(InvokeFilledMagic());
        }
    }

    IEnumerator InvokeFilledMagic()
    {
        yield return new WaitForSeconds(0.5f);
        EventManager.Instance.magicFilledEvent.Invoke();
        value = 0;
    }
}
