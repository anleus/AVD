using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooting : MonoBehaviour
{
    public GameObject ball;
    private GameObject createdBall;
    [SerializeField] private float speed;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = -Vector3.one;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                clickPosition = hit.point;

                Vector3 direction = clickPosition - transform.position;
                direction.Normalize();
            
                ShotBall(direction);
            }    
        }
    }

    void ShotBall(Vector3 shotDirection)
    {
        createdBall = Instantiate(ball, transform.position, transform.rotation);
        createdBall.GetComponent<Rigidbody>().AddForce(shotDirection * speed, ForceMode.Impulse);
    }
}
