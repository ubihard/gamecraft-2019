using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int originalHealth = 600;
    public int health;
    public int attack = 8;
    public int defense = 20;
    public int resistance = 20;

    public int currentSceneIndex;

    public 

    void Start()
    {
        health = originalHealth;

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        EventManager.Instance.playerAttackEvent.AddListener(OnPhysicalHit);
        EventManager.Instance.playerMagicEvent.AddListener(OnMagicalHit);
        EventManager.Instance.bossAttackFilledEvent.AddListener(OnAttack);
    }

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
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
