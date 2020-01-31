using UnityEngine;

public enum FireType{ RayTrace, Projectile }

[System.Serializable]
public struct GunConfig
{
    [SerializeField] private string m_name;
    [SerializeField] private FireType m_fireType;
    [SerializeField] private ushort m_maxMagazineSize;
    [SerializeField] private ushort m_ammonCount;
    [SerializeField] private float m_fireRate;
    [SerializeField] private float m_damage;
    [SerializeField] private Vector3 m_muzzlePosition;

    public string Name { get{ return m_name; } }
    public FireType FireType { get{ return m_fireType; } }
    public ushort MaxMagazineSize { get{ return m_maxMagazineSize; } }
    public ushort AmmonCount 
    { 
        get { return m_ammonCount; }
        set 
        { 
            if(value > m_maxMagazineSize)
                m_ammonCount = m_maxMagazineSize;
            else
                m_ammonCount = value;
        }
    }
    public float FireRate { get{ return m_fireRate; } }
    public float Damage { get{ return m_damage; } }
    public Vector3 MuzzlePosition
    {
        get{ return m_muzzlePosition; } 
        set{ m_muzzlePosition = value; }
    }

    public GunConfig(string name, FireType fireType , ushort magazineSize, float fireRate, float damage)
    {
        m_name = name;
        m_fireType = fireType;
        m_maxMagazineSize = magazineSize;
        m_ammonCount = m_maxMagazineSize;
        m_fireRate = fireRate;
        m_damage = damage;
        m_muzzlePosition = Vector3.zero;
    }
}