using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] int canonNum = 0;
    [SerializeField] float frequency = 1f;

    public GameObject bullet;
    public Animator turretAnimator;
    public AudioSource turretSound;
    public Transform[] bulletPoints;
    public Animator[] canonAnimator;

    void Start() 
    {
        StartCoroutine("DeathCD");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Die();
        }
    }

    void StartShooting()
    {
        StartCoroutine("Shot");
    }

    IEnumerator DeathCD() 
    {
        yield return new WaitForSeconds(5);
        Die();
    }

    IEnumerator Shot()
    {
        canonAnimator[canonNum].SetTrigger("Shot");
        Instantiate(bullet, bulletPoints[canonNum].position, bulletPoints[canonNum].rotation);
        turretSound.Play();
        

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
        StopAllCoroutines();
        turretAnimator.SetTrigger("dead");
        Destroy(gameObject, 1);
    }
}
