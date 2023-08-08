using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    public bool selected;
    public NavMeshAgent navMeshAgent;
    public Queue<Vector3> actionQueue = new Queue<Vector3>();

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(actionQueue.Count > 0)
        {
            // If we're not within 0.5 units of our queued destination, 
            if (Vector3.Distance(transform.position, actionQueue.Peek()) < 1.1f)
            {
                // Remove current destination from the queue
                actionQueue.Dequeue();
                // set the navmeshagent's destination to the vector3 at the front of the queue
                if(actionQueue.Count != 0)
                    navMeshAgent.destination = actionQueue.Peek();
                else
                {
                    Debug.Log("Actions Complete.");
                }
            }
            else
            {
                if(navMeshAgent.destination != actionQueue.Peek())
                    // Set the destination to the vector3 at the front of the queue.
                    navMeshAgent.destination = actionQueue.Peek();
            }
        }
    }
}
