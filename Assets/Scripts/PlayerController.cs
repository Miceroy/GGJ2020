using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameComponent, IDamage
{
    public float health = 5.0f;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
