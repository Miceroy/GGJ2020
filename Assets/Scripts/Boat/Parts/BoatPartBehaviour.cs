using System.Collections.Generic;
using UnityEngine;

public class BoatPartBehaviour : MonoBehaviour, IFixable, IDamage, IExplodeable
{
    public BoatPartObject m_PartObject;
    private BoatPart m_boatPart;

    public float Damage { get{ return m_boatPart.Damage; } }
    public float Radius { get{ return m_boatPart.Radius; } }
    public bool IsExploded { get{ return m_boatPart.IsExploded; } }

    private void Awake()
    {
        m_boatPart = new BoatPart(m_PartObject.m_Config);
    }

    public void Fix(float amount)
    {
        m_boatPart.Fix(amount);
    }

    public void Take(float amount)
    {
        m_boatPart.Take(amount);
    }

    public bool Explode()
    {
        if(m_boatPart.Health <= 0)
            return false;

        Collider[] objects = Physics.OverlapSphere(transform.position, m_boatPart.Radius);

        List<IDamage> damageables = new List<IDamage>();

        for (int i = 0; i < objects.Length; i++)
        {
            IDamage damageable = objects[i].GetComponent<IDamage>();

            if(damageable != null)
                damageables.Add(damageable);
        }

        for (int i = 0; i < damageables.Count; i++)
        {
            damageables[i].Take(m_boatPart.Damage);
        }

        return true;
    }
}