using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour, IAction
{
    public Vector3 targetDestination;
    public NavMeshAgent navMeshAgent;
    [SerializeField] private float checkpointCompleteThreshold = 1.1f;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public void Execute()
    {
        navMeshAgent.destination = targetDestination;
    }

    public bool IsActionComplete()
    {
        if (Vector3.Distance(transform.position, targetDestination) < checkpointCompleteThreshold)
        {
            return true;
        }
        else
            return false;
    }
}
