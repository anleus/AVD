using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3D : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 15f;
    public LayerMask layerMask;
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

        if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            rb.Sleep();    
        }
        explosionParticles.SetActive(true);
        Destroy(gameObject, 0.8f);
    }
}
