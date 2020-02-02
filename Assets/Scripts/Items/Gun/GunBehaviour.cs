using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public GunConfigObject m_GunConfigObject;
    private Gun m_gun;

    public IGun Gun { get { return m_gun; } } 

    private void Awake()
    {
        m_gun = new Gun(m_GunConfigObject.m_Config);
    }

    private void Update()
    {
        m_gun.TimeUpdate(Time.deltaTime);
    }

    public bool Shoot()
    {
        if(!m_gun.Shoot())
            return false;

        FireType fireType = m_gun.Config.FireType;

        if(fireType == FireType.RayTrace)
        {
            RaycastHit hit;
            
            //Debug.DrawRay(transform.TransformPoint(m_gun.Config.MuzzlePosition), transform.forward * 10.0f, Color.red, 5.0f);

            if (!Physics.Raycast(transform.TransformPoint(m_gun.Config.MuzzlePosition), transform.forward, out hit))
                return true;

            //Debug.DrawLine(transform.TransformPoint(m_gun.Config.MuzzlePosition), hit.point, Color.yellow, 5.0f);
            //Debug.LogWarning("Hit object " + hit.collider.gameObject);

            IDamage damageable = hit.transform.GetComponentInParent<IDamage>();
            if(damageable == null)
                return true;

            damageable.Take(m_gun.Config.Damage);
        }
        else if(fireType == FireType.Projectile)
        {
            
        }
        return true;
    }

    public void Reload()
    {
        m_gun.Reload();
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    if (m_gun == null) return;
    //    Gizmos.DrawSphere(transform.TransformPoint(m_gun.Config.MuzzlePosition), 0.10f);
    //}
}