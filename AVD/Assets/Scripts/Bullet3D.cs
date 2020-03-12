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
        rb.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {   
            Instantiate(
                explosionParticles,
                collision.transform.position, 
                collision.transform.rotation);
                
            Debug.Log("Enemy hited");
        }

        if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            Debug.Log("ground hited");
            Destroy(gameObject);
        }

        //Destroy(gameObject);
    }
}
