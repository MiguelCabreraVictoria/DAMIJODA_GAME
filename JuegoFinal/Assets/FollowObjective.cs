using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class FollowObjective : MonoBehaviour
{
    [SerializeField] private Transform objective;
  //  [SerializeField] private NavMeshSurface2d surfaces;
    //public NavMeshSurface[] surfaces;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;        
    }

    private void Update(){
        navMeshAgent.SetDestination(objective.position);

        if (Input.GetKeyDown(KeyCode.Space))
        {
           //public AsyncOperation UpdateNavMesh(NavMeshData data);
           // surfaces.BuildNavMesh();
        }
    }
}
