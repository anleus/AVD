using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SimpleWalk : MonoBehaviour
{

    NavMeshAgent agent;
    public Transform destination;
    Vector3 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = destination.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (destination.transform.position != previousPosition)
        {
            agent.destination = destination.transform.position;
            previousPosition = destination.transform.position;
        }
    }
}
