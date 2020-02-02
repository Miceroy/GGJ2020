using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatHealth : MonoBehaviour, IDamage
{
    public float health = 10;
    public ParticleSystem explosion = null;

    public void Take(float amount)
    {
        health -= amount;
        if (health <= 0.0f)
        {
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, Quaternion.identity, null);
            }
            Destroy(gameObject);
        }
    }
}
