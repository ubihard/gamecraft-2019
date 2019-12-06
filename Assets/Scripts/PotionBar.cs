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
            StartCoroutine(InvokeFilledPotion());
        }
    }

    IEnumerator InvokeFilledPotion()
    {
        yield return new WaitForSeconds(0.5f);
        EventManager.Instance.potionFilledEvent.Invoke();
        value = 0;
    }
}
