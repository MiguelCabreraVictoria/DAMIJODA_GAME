using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform objective;
    //[SerializeField] private NavMeshBuilder surface;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    private void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.updateRotation=false;
        navMeshAgent.updateUpAxis=false;
        }

    // Update is called once per frame
    private void Update()
    {
        navMeshAgent.SetDestination(objective.position);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //surface.BuildNavMesh();
        }
    }
}
