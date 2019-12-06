using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private static EventManager _instance;

    public static EventManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("Event Manager").AddComponent<EventManager>();
            }
            return _instance;
        }
    }

    public UnityEvent attackFilledEvent;
    public UnityEvent defenseFilledEvent;
    public UnityEvent potionFilledEvent;
    public UnityEvent magicFilledEvent;
    public DamageEvent playerAttackEvent;
    public DamageEvent playerMagicEvent;
    public UnityEvent attackButtonHitEvent;
    public UnityEvent defenseButtonHitEvent;
    public UnityEvent potionButtonHitEvent;
    public UnityEvent magicButtonHitEvent;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    void OnEnable()
    {
        attackFilledEvent = new UnityEvent();
        defenseFilledEvent = new UnityEvent();
        potionFilledEvent = new UnityEvent();
        magicFilledEvent = new UnityEvent();
        playerAttackEvent = new DamageEvent();
        playerMagicEvent = new DamageEvent();
        attackButtonHitEvent = new UnityEvent();
        defenseButtonHitEvent = new UnityEvent();
        potionButtonHitEvent = new UnityEvent();
        magicButtonHitEvent = new UnityEvent();
    }

    void Onable()
    {
        attackFilledEvent = null;
        defenseFilledEvent = null;
        potionFilledEvent = null;
        magicFilledEvent = null;
        playerAttackEvent = null;
        playerMagicEvent = null;
        attackButtonHitEvent = null;
        defenseButtonHitEvent = null;
        potionButtonHitEvent = null;
        magicButtonHitEvent = null;
    }
}