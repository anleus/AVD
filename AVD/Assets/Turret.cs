using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullet;
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown("Fire1")) Shot();
    }

    public void Shot()
    {
        Instantiate(bullet, point1.position, point1.rotation);
        
        Instantiate(bullet, point2.position, point2.rotation);
     
        Instantiate(bullet, point3.position, point3.rotation);
  
        Instantiate(bullet, point4.position, point4.rotation);
    }
}
