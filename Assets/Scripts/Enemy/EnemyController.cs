using UnityEngine;
using UnityEngine.AI;

public class EnemyController : GameComponent, IDamage
{
    public float health = 5.0f;
    NavMeshAgent agent;
    private Enemy m_enemy;
    public GunBehaviour Gun;

    private Transform playerTransform;


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
        m_enemy = new Enemy(health, Gun.Gun);

        agent = GetComponent<NavMeshAgent>();

        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerTransform);

        agent.destination = Camera.main.transform.position;//GameObject.FindGameObjectWithTag("Player").transform.position;
        //Debug.Log("Remaining distance: " + agent.remainingDistance.ToString());

        m_enemy.Gun.TimeUpdate(Time.deltaTime);
        Vector3 muzzlePosition = Gun.transform.TransformPoint(m_enemy.Gun.Config.MuzzlePosition);
        m_enemy.Shoot(muzzlePosition, Gun.transform.forward);
    }
}
