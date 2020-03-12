﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] int canonNum = 0;
    [SerializeField] float frequency = 0.3f;

    public GameObject bullet;
    public Transform[] bulletPoints;
    public Animator[] canonAnimator;

    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            StopAllCoroutines();
        }
    }

    void StartShooting()
    {
        StartCoroutine("Shot");
    }

    IEnumerator Shot()
    {
        canonNum++;
        if (canonNum >= bulletPoints.Length)
        {
            canonNum = 0;
        }

        Instantiate(bullet, bulletPoints[canonNum].position, bulletPoints[canonNum].rotation);
        canonAnimator[canonNum].SetTrigger("Shot");

        yield return new WaitForSeconds(frequency);
        StartCoroutine("Shot");
    }
}