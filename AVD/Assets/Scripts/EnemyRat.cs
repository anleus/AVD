using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRat : MonoBehaviour, Hitable
{
    private Rigidbody2D rb;
    private Animator animator;
    private int normalDamage = 50;
    private int constantDamage = 30;
    public int health = 100;
    private bool isDead;
    public List<GameObject> wayPoints;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Behaviour();
    }

    public void Execute(Style style)
    {
        TakeDamage(style);
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

    void Die()
    {
        Destroy(gameObject);
    }

    private void Behaviour()
    {

    }
}
