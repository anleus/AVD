using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Style { Normal, Charged};

public class Shooting : MonoBehaviour
{
    public Transform bulletPoint;
    public GameObject bullet;
    public GameObject laser;
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
    }

    void Shoot()
    {
        if (style == Style.Normal)
        {
            Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
        }
        else
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(bulletPoint.position, bulletPoint.right);

            if (hitInfo)
            {
                hitInfo.transform.GetComponent<Hitable>().Execute(style);
            }
        }
    }

    void AlternateStyle()
    {
        if (style == Style.Normal) style = Style.Charged;
        else style = Style.Normal;
    }
}
