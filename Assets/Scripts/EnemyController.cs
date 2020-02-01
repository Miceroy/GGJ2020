using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : GameComponent, IDamage
{
    public float health = 5.0f;
    NavMeshAgent agent;


    public void Take(float amount)
    {
        health -= amount;
        if(health <= 0.0f)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

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
