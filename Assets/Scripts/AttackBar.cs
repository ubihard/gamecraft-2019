using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBar : BarItem
{
    void Start()
    {
        EventManager.Instance.attackButtonHitEvent.AddListener(AddToBar);
    }

    void Update()
    {
        Image bar = GetComponent<Image>();
        bar.fillAmount = value * 0.2f;
        if (value == maxValue)
        {
            StartCoroutine(InvokeFilledAttack());
        }
    }
    IEnumerator InvokeFilledAttack()
    {
        yield return new WaitForSeconds(0.5f);
        EventManager.Instance.attackFilledEvent.Invoke();
        value = 0;
    }
}
