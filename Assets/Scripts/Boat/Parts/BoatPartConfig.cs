using System;
using UnityEngine;

[Serializable]
public struct BoatPartConfig
{
    [SerializeField] private string m_name;
    [SerializeField] private float m_currentHealth;
    [SerializeField] private float m_maxHealth;
    [SerializeField] private float m_explosionDamage;
    [SerializeField] private float m_explosionRadius;

    public string Name { get { return m_name; } }
    public float Health
    { 
        get{ return m_currentHealth; } 
        set
        {
            value = m_currentHealth + value;
            value = (value <= m_maxHealth) ? value : m_maxHealth;
            m_currentHealth = value;
        }    
    }
    public float MaxHealth { get{ return m_maxHealth; } }
    public float ExplosionDamage { get{ return m_explosionDamage; } }
    public float ExplosionRadius { get{ return m_explosionRadius; } }

    public BoatPartConfig(string name, float health, float explosionDamage, float explosionRadius)
    {
        m_name = name;
        m_maxHealth = health;
        m_currentHealth = m_maxHealth;

        m_explosionDamage = explosionDamage;
        m_explosionRadius = explosionRadius;
    }
}