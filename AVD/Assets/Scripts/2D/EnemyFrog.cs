using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrog : MonoBehaviour, Hitable
{
    public int health = 100;
    private int normalDamage = 30;
    private int constantDamage = 15;
    private bool isDead = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Execute(Style style)
    {
        TakeDamage(style);
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

        if (health <= 0 && !isDead)
        {
            isDead = true;
            animator.SetTrigger("dead");
            
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            col.transform.GetComponent<PlayerController>().Hited();
        }
    }


}
