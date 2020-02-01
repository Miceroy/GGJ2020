using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : GameComponent
{
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = Camera.main.transform.position;//GameObject.FindGameObjectWithTag("Player").transform.position;
        Debug.Log("Remaining distance: " + agent.remainingDistance.ToString());
    }
}
