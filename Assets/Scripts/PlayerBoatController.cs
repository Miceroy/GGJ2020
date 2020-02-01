using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoatController : GameComponent
{
    private Boat m_boat;

    // Start is called before the first frame update
    void Start()
    {
        List<Transform> childTransforms = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            childTransforms.Add(transform.GetChild(i));
        }

        List<BoatPartBehaviour> partBehaviours = new List<BoatPartBehaviour>();

        GetComponents(partBehaviours);
        
        IBoatPart[] parts = new IBoatPart[partBehaviours.Count];

        for (int i = 0; i < parts.Length; i++)
        {
            parts[i] = partBehaviours[i].Part;
        }

        m_boat = new Boat(parts, 200f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
