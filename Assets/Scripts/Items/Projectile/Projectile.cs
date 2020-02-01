using System;

[Serializable]
public class Projectile : IExplodeable
{
    private ProjectileConfig m_config;

    public float Damage { get { return m_config.Damage; } }
    public float Radius { get { return m_config.Radius; } }
    public bool IsExploded { get { return m_config.IsExploaded; } }

    public Projectile(ProjectileConfig config)
    {
        m_config = config;
    }

    public bool Explode()
    {
        if(m_config.IsExploaded)
            return false;
        
        return m_config.IsExploaded = true;
    }
}
