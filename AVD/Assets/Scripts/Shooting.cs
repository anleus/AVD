using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform bulletPoint;
    public GameObject bullet;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            
            //Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
        }
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
    }
}
