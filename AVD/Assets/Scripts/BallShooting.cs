using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooting : MonoBehaviour
{
    public GameObject ball;
    private GameObject createdBall;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector3 direction = mousePosition - transform.position;

            //RaycastHit hitPosition = Physics.Raycast(transform.position, direction);
            
            ShotBall(mousePosition);
        }
    }

    void ShotBall(Vector3 position)
    {
        createdBall = Instantiate(ball, transform.position, transform.rotation);
        createdBall.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
