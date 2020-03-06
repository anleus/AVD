using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Style { Normal, Charged};

public class Shooting : MonoBehaviour
{
    public Transform bulletPoint;
    public GameObject bullet;
    public PlayerStats stats;
    public LineRenderer line;

    public Style style;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            AlternateStyle();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine("Shoot");
        }
    }

    IEnumerator Shoot()
    {
        if (style == Style.Normal)
        {
            Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
            yield return new WaitForSeconds(0.1f);
        }
        else
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(bulletPoint.position, bulletPoint.right);
            Debug.Log(hitInfo.transform.name);
            if (!hitInfo.transform.CompareTag("Player"))
            {
                try
                {
                    hitInfo.transform.GetComponent<Hitable>().Execute(Style.Charged);
                }
                catch { }

                line.SetPosition(0, bulletPoint.position);
                line.SetPosition(1, hitInfo.point);
            }

            line.enabled = true;
            yield return new WaitForSeconds(0.02f);
            line.enabled = false;
        }
    }

    void AlternateStyle()
    {
        if (style == Style.Normal) style = Style.Charged;
        else style = Style.Normal;

        stats.ChangeShotImage(style);
    }
}
