using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;

    public static bool attack = false;
    public static bool defend = false;
    public static bool magic = false;
    public static bool heal = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {
            animator.SetTrigger("Attack");
            attack = false;
        } 

        if (defend)
        {
            animator.SetTrigger("Defend");
            defend = false;
        }

        if (magic)
        {
            animator.SetTrigger("Magic");
            magic = false;
        }

        if (heal)
        {
            animator.SetTrigger("Heal");
            heal = false;
        }
    }
}
