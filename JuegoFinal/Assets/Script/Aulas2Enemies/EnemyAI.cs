using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //public float retreatDistance = 4.0f;
    [SerializeField] private Transform objective;
    //[SerializeField] private NavMeshBuilder surface;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    public int multiplier = 2;
    public float range = 4;

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
        Invoke(nameof(Run),Random.Range(2,4));

        // Vector3 runTo = transform.position + ((transform.position - objective.position) * multiplier);
        // float distance = Vector3.Distance(transform.position, objective.position);
        // if (distance < range)
        // {
        //     navMeshAgent.SetDestination(runTo);
        // }


        // float distance = Vector3.Distance(transform.position, objective.position);
        // Debug.Log(distance);
        
        // if(distance < retreatDistance)
        // {
        //     Vector3 dirToPlayer = transform.position - objective.position;

        //     Vector3 newPos = dirToPlayer.normalized;

        //     navMeshAgent.SetDestination(newPos);
        // }
        // else
        // {
        //     navMeshAgent.SetDestination(objective.position);
        // }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //surface.BuildNavMesh();
        }
    }

    void Run()
    {
        Vector3 runTo = transform.position + ((transform.position - objective.position) + new Vector3(Random.Range(-12,12),0,Random.Range(-15,12)) * multiplier);
        float distance = Vector3.Distance(transform.position, objective.position);
        navMeshAgent.speed = Random.Range(7.5f, 11f);
        if (distance < range)
        {
            navMeshAgent.SetDestination(runTo);
        }
    }
}
