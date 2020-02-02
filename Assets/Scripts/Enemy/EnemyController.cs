using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : GameComponent, IDamage
{
    public float health = 5.0f;
    NavMeshAgent agent;
    private Enemy m_enemy;

    private Transform playerBoatTransform;


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
        GunBehaviour gunBehaviour = transform.GetComponentInChildren<GunBehaviour>();

        m_enemy = new Enemy(health, gunBehaviour.Gun);

        agent = GetComponent<NavMeshAgent>();

        playerBoatTransform = GameObject.FindWithTag("PlayerBoat").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = Camera.main.transform.position;//GameObject.FindGameObjectWithTag("Player").transform.position;
        //Debug.Log("Remaining distance: " + agent.remainingDistance.ToString());

        m_enemy.Gun.TimeUpdate(Time.deltaTime);
        Vector3 muzzlePosition = transform.TransformPoint(m_enemy.Gun.Config.MuzzlePosition);
        m_enemy.ShootAtPlayerBoat(playerBoatTransform.position, muzzlePosition);
    }
}
