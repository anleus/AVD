using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private float time = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        CountdownToDeath();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(gameObject);
    }

    void CountdownToDeath()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }   
    }
}
