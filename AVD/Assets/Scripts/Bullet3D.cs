using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3D : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(0, 0, speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
