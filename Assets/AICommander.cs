using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class AICommander : MonoBehaviour
{
    Camera cam;
    [SerializeField] List<AIMove> agents;

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
                QueueCommand(SampleScreenPos());
            }
            else if (Input.GetMouseButtonDown(0))
            {
                QueuePriorityCommand(SampleScreenPos());
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

    void QueueCommand(NavMeshHit navHit)
    {
        foreach (AIMove agent in agents)
        {
            if (agent.selected)
            {
                agent.actionQueue.Enqueue(navHit.position);
            }
        }
    }

    void QueuePriorityCommand(NavMeshHit navHit)
    {
        foreach (AIMove agent in agents)
        {
            if (agent.selected)
            {
                agent.actionQueue.Clear();
                agent.actionQueue.Enqueue(navHit.position);
            }
        }
    }
    
}
