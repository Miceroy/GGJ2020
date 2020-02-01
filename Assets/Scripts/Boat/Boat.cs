using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : IExplodeable
{
    private IBoatPart[] m_parts;

    private float m_explosionDamage;
    private float m_explosionRadius;
    private bool m_isExploded;

    public float Health
    {
        get
        {
            float health = 0;
            for (int i = 0; i < m_parts.Length; i++)
            {
                if(!m_parts[i].IsExploded)
                    health += m_parts[i].Health; 
            }
            return health;
        }
    }

    public float Damage { get{ return m_explosionDamage; } }
    public float Radius { get{ return m_explosionRadius; } }
    public bool IsExploded { get{ return m_isExploded; } }

    public Boat(IBoatPart[] parts, float explosionDamage, float explosionRadius)
    {
        m_parts = parts;
        m_explosionDamage = explosionDamage;
        m_explosionRadius = explosionRadius;
    }

    public bool Explode()
    {
        if(m_isExploded)
            return false;
        
        return m_isExploded = true;
    }
}
