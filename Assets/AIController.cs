using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using Sirenix.OdinInspector;

/// <summary>
/// Receives Actions from <see cref="AICommander"/> to queue and execute.
/// </summary>
public class AIController : SerializedMonoBehaviour
{
    public bool selected;
    public NavMeshAgent navMeshAgent;
    public List<IAction> actionQueue = new List<IAction>();
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
            if (actionQueue.Last() != null && !actionQueue.Last().IsActionComplete())
                // Execute the next action
                actionQueue.Last().Execute();

            // If our action is complete already
            else if (actionQueue.Last().IsActionComplete())
            {
                
                // Remove current action from the queue
                actionQueue.Remove(actionQueue.Last());

                if(actionQueue.Last() != null)
                    // Execute the next action
                    actionQueue.Last().Execute();
            }
        }
    }
}
