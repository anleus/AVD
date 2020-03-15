using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBall : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject turret;
    public Animator animator;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        rb.AddTorque(transform.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            animator.SetTrigger("badHit");
        }
        else if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            Instantiate(turret, transform.position + new Vector3(0f, 0.5f, 0f), collision.transform.rotation);
            Die();
        }     
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
