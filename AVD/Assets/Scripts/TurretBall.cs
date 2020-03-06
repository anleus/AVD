using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBall : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask layerMask;
    public GameObject turret;

    private Rigidbody rb;
    private Transform hit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddTorque(transform.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            Instantiate(turret, collision.transform.position + new Vector3(0f, 0.5f, 0f), collision.transform.rotation);
        }

        Destroy(gameObject);
    }
}
