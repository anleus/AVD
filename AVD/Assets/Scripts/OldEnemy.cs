using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldEnemy : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody viejoRb;
    public Animator animator;
    public bool ready = false;
    private bool dead = false;

    void Start()
    {
        speed = 2f;
        StartCoroutine("Idle");
    }

    void Update()
    {
        if (ready && !dead)
        {
            viejoRb.velocity = new Vector3(
                viejoRb.velocity.x,
                viejoRb.velocity.y,
                -speed);
        }
    }

    IEnumerator Idle()
    {
        yield return new WaitForSeconds(1.5f);
        ready = true;
        animator.SetBool("walking", true);
    }

    public void Die()
    {
        viejoRb.Sleep();
        animator.SetTrigger("dead");
        dead = true;
        Destroy(gameObject, 3.02f);
    }
}
