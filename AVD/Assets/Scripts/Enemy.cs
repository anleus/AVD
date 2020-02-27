﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Hitable
{
    public int health = 100;
    private int normalDamage = 20;
    private int constantDamage = 5;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(Style style)
    {
        switch (style)
        {
            case Style.Normal:
                health -= normalDamage;
                break;
            case Style.Charged:
                health -= constantDamage;
                break;
        }

        if (health <= 0)
        {
            animator.SetTrigger("dead");
        }
    }

    public void Execute(Style style)
    {
        TakeDamage(style);
    }
}