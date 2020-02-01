
using System;
using UnityEngine;

[Serializable]
public struct ProjectileConfig
{
    [SerializeField] private float m_damage;
    [SerializeField] private float m_radius;
    private bool m_isExploaded;

    public float Damage
    {
        get { return m_damage; }
        set { m_damage = value; }
    }
    public float Radius
    {
        get { return m_radius; }
        set { m_radius = value; }
    }
    public bool IsExploaded
    {
        get { return m_isExploaded; }
        set { m_isExploaded = value; }
    }

    public ProjectileConfig(float damage, float radius)
    {
        m_damage = damage;
        m_radius = radius;
        m_isExploaded = false;
    }
}