public class BoatPart : IBoatPart
{
    private BoatPartConfig m_config;
    private bool m_isExploaded;

    public float Health { get{ return m_config.Health; } }
    public float Damage { get{ return m_config.ExplosionDamage; } }
    public float Radius { get{ return m_config.ExplosionRadius; } }
    public bool IsExploded { get{ return m_isExploaded; } }

    public float MaxHealth { get{ return m_config.MaxHealth; } }

    public IBoatPart Part { get{ return this; } }

    public BoatPart(BoatPartConfig config)
    {
        m_config = config;
        m_isExploaded = false;
    }

    public bool Explode()
    {
        if(m_isExploaded)
            return false;
        
        return m_isExploaded = true;
    }

    public void Fix(float amount)
    {
        if(m_isExploaded)
            return;
            
        m_config.Health += amount;
    }

    public void Take(float amount)
    {
        m_config.Health -= amount;

        if(m_config.Health <= 0)
            Explode();
    }
}