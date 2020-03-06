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
    public float speed = 2f;

    public bool moveRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (!moveRight)
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Turn"))
        {
            if (moveRight) moveRight = false;
            else moveRight = true;
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            col.transform.GetComponent<PlayerController>().Hited();
        }
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
}
