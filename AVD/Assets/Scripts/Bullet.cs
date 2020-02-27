using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public int normalDamage = 20;
    public Animator animator;

    private float time = 0.5f;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        transform.Rotate(0, 0, 30f * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (!hitInfo.CompareTag("Player"))
        {
            if (hitInfo.CompareTag("Hitable"))
            {
                hitInfo.GetComponent<Hitable>().Execute(Style.Normal);
            }
            animator.SetTrigger("impact");
            rb.velocity = Vector2.zero;
        }
    }

    public void End()
    {
        Destroy(gameObject);
    }
    
}
