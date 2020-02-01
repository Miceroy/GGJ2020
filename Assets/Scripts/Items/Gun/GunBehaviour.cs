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

    public void Shoot()
    {
        if(!m_gun.Shoot())
            return;

        if(m_gun.Config.FireType == FireType.RayTrace)
        {
            RaycastHit hit;
            
            if(!Physics.Raycast(transform.position + m_gun.Config.MuzzlePosition, transform.forward, out hit))
                return;

            //if(hit.collider.tag == "Enemy")

        }
    }
}