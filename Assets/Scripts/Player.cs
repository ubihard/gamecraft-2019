using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        health = originalHealth;
        attack = originalAttack;
        defense = originalDefense;
        magic = originalMagic;

        EventManager.Instance.attackFilledEvent.AddListener(OnAttack);
        EventManager.Instance.defenseFilledEvent.AddListener(OnDefend);
        EventManager.Instance.potionFilledEvent.AddListener(OnHeal);
        EventManager.Instance.magicFilledEvent.AddListener(OnMagic);
    }

    private void OnAttack()
    {
        EventManager.Instance.playerAttackEvent.Invoke(attack); 
        PlayerMovement.attack = true;
        GameObject.Instantiate(Resources.Load("AttackParticle"));
        GameObject lightEffectThing = GameObject.Instantiate((GameObject) Resources.Load("AttackParticle"));
        GameObject.Destroy(lightEffectThing, 1);
    }

    private void OnDefend()
    {
        defense += 2;
        PlayerMovement.defend = true;
    }

    private void OnHeal()
    {
        int finalHealth = health + 10;
        if (finalHealth > originalHealth)
        {
            finalHealth = originalHealth;
        }

        health = finalHealth;

        PlayerMovement.heal = true;
    }

    private void OnMagic()
    {
        EventManager.Instance.playerMagicEvent.Invoke(magic);
        PlayerMovement.magic = true;
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
