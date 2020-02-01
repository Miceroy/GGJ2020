using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoatController : GameComponent
{
    public float rotateSpeed = 20;
    public float translationSpeed = 5;
    Transform playerPos;
    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("PlayerBoat").transform;
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toPlayer = (playerPos.position - transform.position).normalized;
        Vector3 forward = transform.forward.normalized;
        Vector3 neededMomentum = Vector3.Cross(toPlayer, -forward);
        body.AddTorque(new Vector3(0, rotateSpeed * neededMomentum.y * body.mass,0));
        body.AddForce(translationSpeed * forward * body.mass, ForceMode.Force);
    }
}
