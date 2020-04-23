using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooting : MonoBehaviour
{
    public GameObject ball;
    public Transform origin;
    public Animator animator;
    private GameObject createdBall;
    [SerializeField] float timeToShot = 0.38f;
    [SerializeField] private float speed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            animator.SetTrigger("throw");

            StartCoroutine(ShotBall(transform.forward));
        }
    }

    IEnumerator ShotBall(Vector3 shotDirection)
    {
        yield return new WaitForSeconds(timeToShot);
        createdBall = Instantiate(ball, origin.position, origin.rotation);
        createdBall.GetComponent<TurretBall>().playerTransform = transform;
        createdBall.GetComponent<Rigidbody>().AddForce(shotDirection * speed, ForceMode.Impulse);
    }
}
