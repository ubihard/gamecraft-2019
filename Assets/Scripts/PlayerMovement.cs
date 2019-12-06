using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;

    public bool attack = false;
    public bool defend = false;
    public bool magic = false;
    public bool heal = false;

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
            animator.SetBool("isAttacking", true);
        }
    }
}
