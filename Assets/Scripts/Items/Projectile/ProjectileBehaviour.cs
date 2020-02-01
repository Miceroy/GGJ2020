using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ProjectileBehaviour : MonoBehaviour
{
    public ProjectileObject m_ProjectileObject;
    private IExplodeable m_projectile;

    private void Awake()
    {
        m_projectile = new Projectile(m_ProjectileObject.m_Config);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(m_projectile.IsExploded)
            return;

        Collider[] objects = Physics.OverlapSphere(transform.position, m_projectile.Radius);

        List<IDamage> damageables = new List<IDamage>();

        for (int i = 0; i < objects.Length; i++)
        {
            IDamage damageable = objects[i].GetComponent<IDamage>();

            if(damageable != null)
                damageables.Add(damageable);
        }

        for (int i = 0; i < damageables.Count; i++)
        {
            damageables[i].Take(m_projectile.Damage);
        }
    }
}
