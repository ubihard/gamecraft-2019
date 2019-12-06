using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public DamageEvent attackEvent;
    public DamageEvent magicEvent;

    public BarItem attackBar;
    public BarItem defenseBar;
    public BarItem potionBar;
    public BarItem magicBar;

    public int originalHealth = 100;
    public int originalAttack = 70;
    public int originalDefense = 0;
    public int originalMagic = 50;

    private int health;
    private int attack;
    private int defense;
    private int magic;

    void Start()
    {
        if (attackEvent == null)
        {
            attackEvent = new DamageEvent();
        }
        if (magicEvent == null)
        {
            magicEvent = new DamageEvent();
        }

        health = originalHealth;
        attack = originalAttack;
        defense = originalDefense;
        magic = originalMagic;

        attackBar.filledEvent.AddListener(OnAttack);
        defenseBar.filledEvent.AddListener(OnDefend);
        potionBar.filledEvent.AddListener(OnHeal);
        magicBar.filledEvent.AddListener(OnMagic);
    }

    private void OnAttack()
    {
        attackEvent.Invoke(attack);
    }

    private void OnDefend()
    {
        defense += 2;
    }

    private void OnHeal()
    {
        int finalHealth = health + 10;
        if (finalHealth > originalHealth)
        {
            finalHealth = originalHealth;
        }

        health = finalHealth;
    }

    private void OnMagic()
    {
        magicEvent.Invoke(magic);
    }

    private void OnHit(int damage)
    {
        int finalDamage = damage - defense;
        if (damage < 3)
        {
            finalDamage = 3;
        }

        health -= finalDamage;
    }
}
