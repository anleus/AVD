using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using CreatorKitCode;

public class Bullet3D : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 15f;
    public LayerMask badLayer;
    public LayerMask goodLayer;
    public GameObject explosionParticles;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<OldEnemy>().Die();
            rb.Sleep();
        }

        if (goodLayer == (goodLayer | (1 << collision.gameObject.layer)))
        {
            Animator targetAnimator = collision.gameObject.GetComponentInChildren<Animator>();

            if (targetAnimator != null) {
                KillEnemy(collision.gameObject, targetAnimator);
            }
        }

        if (badLayer == (badLayer | (1 << collision.gameObject.layer)))
        {
            rb.Sleep();    
        }
        explosionParticles.SetActive(true);
        Destroy(gameObject, 0.8f);
    }

    void KillEnemy(GameObject enemy, Animator animator) 
    {
        enemy.GetComponent<Collider>().enabled = false;
        CharacterData dataEnemy = enemy.GetComponent<CharacterData>();
        animator.SetTrigger("Hit");
        dataEnemy.Stats.CurrentHealth = 0;
        
    }
}
