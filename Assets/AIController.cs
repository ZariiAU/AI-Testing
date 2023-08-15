using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Receives Actions from <see cref="AICommander"/> to queue and execute.
/// </summary>
public class AIController : MonoBehaviour
{
    public bool selected;
    public NavMeshAgent navMeshAgent;
    public Queue<IAction> actionQueue = new Queue<IAction>();
    public IAction selectedActionType;

    private void Start()
    {
        selectedActionType = GetComponent<AIMove>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(actionQueue.Count > 0)
        {
            // If our action is complete already
            if (actionQueue.Peek().IsActionComplete())
            {
                // Remove current action from the queue
                actionQueue.Dequeue();
                // Execute the next action
                actionQueue.Peek().Execute();
            }
            else
            {
                actionQueue.Peek().Execute();
            }
        }
    }
}
