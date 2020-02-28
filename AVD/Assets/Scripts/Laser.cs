using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer line;
    private bool hited;
    private GameObject objective;
    private float timer = 0f;
    private Transform start;

    void Update()
    {
        line.SetPosition(0, start.position);

        if (hited)
        {
            try
            {
                if (timer > 0) timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    objective.GetComponent<Hitable>().Execute(Style.Charged);
                    timer = 0.5f;
                }
            } catch { }
        } else
        {
            line.SetPosition(1, start.position + start.right * 20f);
        }
    }

    public void ShotLaser(Transform startPoint)
    {
        start = startPoint;
        RaycastHit2D hitInfo = Physics2D.Raycast(startPoint.position, startPoint.right);

        if (hitInfo && !hitInfo.transform.CompareTag("Player"))
        {
            hited = true;
            objective = hitInfo.transform.gameObject;
            line.SetPosition(0, startPoint.position);
            line.SetPosition(1, hitInfo.point);
        }
        else
        {
            line.SetPosition(0, startPoint.position);
            line.SetPosition(1, startPoint.position + startPoint.right * 20f);
        }
    }
}
