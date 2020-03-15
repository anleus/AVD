using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] int canonNum = 0;
    [SerializeField] float frequency = 0.3f;

    public GameObject bullet;
    public Animator turretAnimator;
    public Transform[] bulletPoints;
    public Animator[] canonAnimator;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StopAllCoroutines();
            Die();
        }
    }

    void StartShooting()
    {
        StartCoroutine("Shot");
    }

    IEnumerator Shot()
    {
        Instantiate(bullet, bulletPoints[canonNum].position, bulletPoints[canonNum].rotation);
        canonAnimator[canonNum].SetTrigger("Shot");

        canonNum++;
        if (canonNum >= bulletPoints.Length)
        {
            canonNum = 0;
        }

        yield return new WaitForSeconds(frequency);
        StartCoroutine("Shot");
    }

    public void Die()
    {
        turretAnimator.SetTrigger("dead");
        Destroy(gameObject, 1);
    }
}
