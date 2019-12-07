using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int originalHealth = 600;
    public int health;
    public int attack = 8;
    public int defense = 20;
    public int resistance = 20;

    void Start()
    {
        health = originalHealth;

        EventManager.Instance.playerAttackEvent.AddListener(OnPhysicalHit);
        EventManager.Instance.playerMagicEvent.AddListener(OnMagicalHit);
        EventManager.Instance.bossAttackFilledEvent.AddListener(OnAttack);
    }

    void OnPhysicalHit(int damage)
    {
        int finalDamage = damage - defense;
        if (finalDamage < 20)
        {
            finalDamage = 20;
        }
        health -= finalDamage;
    }

    void OnMagicalHit(int damage)
    {
        int finalDamage = damage - resistance;
        if (finalDamage < 20)
        {
            finalDamage = 20;
        }
        health -= finalDamage;
    }

    void OnAttack()
    {
        EventManager.Instance.bossAttackEvent.Invoke(attack);
    }
}
