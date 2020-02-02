using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatHealth : MonoBehaviour, IDamage
{
    [SerializeField] private float health = 10;
    [SerializeField] private ParticleSystem explosion = null;

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
