using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class AICommander : MonoBehaviour
{
    Camera cam;
    [SerializeField] List<AIController> agents;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam)
        {
            
            if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift))
            {
                foreach(AIController controller in agents)
                {
                    QueueCommand(controller, SampleScreenPos(), controller.selectedActionType);
                    
                    
                }
            }
            else if (Input.GetMouseButtonDown(0))
            {
                foreach (AIController controller in agents)
                {
                    QueuePriorityCommand(controller, SampleScreenPos(), controller.selectedActionType);
                }
            }
        }
    }

    NavMeshHit SampleScreenPos()
    {
        RaycastHit hit;
        NavMeshHit nHit;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        NavMesh.SamplePosition(hit.point, out nHit, 0.1f, NavMesh.AllAreas);
        return nHit;
    }

    void QueueCommand(AIController agent, NavMeshHit navHit, IAction actionType)
    {
        if (agent.selected)
        {
            agent.actionQueue.Enqueue(actionType);
        }

        // Basic FSM. Find a better way to do this soon.
        if (agent.selectedActionType.GetType() == typeof(AIMove))
        {
            AIMove move = (AIMove)agent.selectedActionType;
            move.targetDestination = navHit.position;
        }
    }

    void QueuePriorityCommand(AIController agent, NavMeshHit navHit, IAction actionType)
    {
        if (agent.selected)
        {
            agent.actionQueue.Clear();
            agent.actionQueue.Enqueue(actionType);
        }

        // Basic FSM. Find a better way to do this soon.
        if (agent.selectedActionType.GetType() == typeof(AIMove))
        {
            AIMove move = (AIMove)agent.selectedActionType;
            move.targetDestination = navHit.position;
        }
    }
}
