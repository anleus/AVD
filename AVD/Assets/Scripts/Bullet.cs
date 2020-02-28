using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public int normalDamage = 20;
    public Animator animator;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (!hitInfo.CompareTag("Player"))
        {
            if (hitInfo.CompareTag("Hitable"))
            {
                try
                {
                    hitInfo.GetComponent<Hitable>().Execute(Style.Normal);
                } catch { }
                
            }
            Debug.Log(hitInfo.name);
            animator.SetTrigger("impact");
            rb.velocity = Vector2.zero;
        }
    }

    public void End()
    {
        Destroy(gameObject);
    }
    
}
