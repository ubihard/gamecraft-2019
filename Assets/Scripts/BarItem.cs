using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BarItem : MonoBehaviour
{
    public ButtonController button;
    public UnityEvent filledEvent;

    public int maxValue = 5;
    public int value { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        value = 0;

        if (filledEvent == null)
        {
            filledEvent = new UnityEvent();
        }
        button.hitEvent.AddListener(AddToBar);
    }

    // Update is called once per frame
    void Update()
    {
        if (value == maxValue) {
            filledEvent.Invoke();
            value = 0;
        }
    }

    public bool CanExecute()
    {
        return value == maxValue;
    }

    void AddToBar()
    {
        value += 1;
    }
}
