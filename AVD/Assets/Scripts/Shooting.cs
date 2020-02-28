using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Style { Normal, Charged};

public class Shooting : MonoBehaviour
{
    public Transform bulletPoint;
    public GameObject bullet;
    public GameObject laser;
    public PlayerStats stats;

    private GameObject laserShot;
    private bool isLaser = false;

    public Style style;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            AlternateStyle();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if ((Input.GetButtonUp("Fire1") && laserShot != null) || stats.energy <= 0f)
        {
            Destroy(laserShot);
            isLaser = false;
        }

        if (isLaser) stats.energy -= Time.deltaTime * 20;

    }

    void Shoot()
    {
        if (style == Style.Normal)
        {
            Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
        }
        else
        {
            isLaser = true;
            laserShot = Instantiate(laser, bulletPoint.position, bulletPoint.rotation);
            laserShot.GetComponent<Laser>().ShotLaser(bulletPoint); 
        }
    }


    void AlternateStyle()
    {
        if (style == Style.Normal) style = Style.Charged;
        else style = Style.Normal;
    }
}
