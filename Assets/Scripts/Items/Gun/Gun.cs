using UnityEngine;

public class Gun : IGun
{
    [SerializeField] private GunConfig m_config;
    private float m_currentTime;
    private bool m_isGrabbed;

    public bool IsGrabbed { get{ return m_isGrabbed; } }
    
    public GunConfig Config 
    { 
        get { return m_config; }
        set { m_config = value; }
    }

    public Gun(GunConfig config)
    {
        m_config = config;
    }

    public IGrabable Grab()
    {
        if(m_isGrabbed)
            return null;

        m_isGrabbed = true;
        return this;
    }
    
    public void Release()
    {
        m_isGrabbed = false;
        m_currentTime = m_config.FireRate;
    }

    public virtual bool Shoot()
    {
        if(m_config.AmmonCount > 0 && m_currentTime >= m_config.FireRate)
        {
            m_config.AmmonCount -= 1;
            m_currentTime = 0f;
            return true;
        }
        else
            return false;
    }

    public void Reload()
    {
        m_config.AmmonCount = m_config.MaxMagazineSize;
    }

    public void TimeUpdate(float deltaTime)
    {
        m_currentTime += deltaTime;
    }
}