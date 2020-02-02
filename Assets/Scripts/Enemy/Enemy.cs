using UnityEngine;

public class Enemy
{
    private float m_health;
    private IGun m_gun;
    private IUnityService m_unityService;

    public float Health { get{ return m_health; } }
    public IGun Gun { get{ return m_gun; } }

    public Enemy(float health, IGun gun, IUnityService unityService = null)
    {
        m_health = health;
        m_gun = gun;

        m_unityService = unityService;
        if(m_unityService == null)
            m_unityService = new UnityService();
    }

    public void Shoot(Vector3 muzzlePosition, Vector3 direction)
    {
        if(!m_gun.Shoot())
        {
            m_gun.Reload();
            return;
        }

        RaycastHit hitInfo;
        if(!m_unityService.RayCast(muzzlePosition, direction, out hitInfo))
            return;

        hitInfo.transform.GetComponent<IDamage>().Take(m_gun.Config.Damage);
    }
}