using UnityEngine;
using Valve.VR.InteractionSystem;

/// <summary>
/// When MonoBehaviour is disabled, hovering over object is disabled.
/// </summary>
public class AllowOnlyOneHand : MonoBehaviour
{
    IgnoreHovering ignore;

    public void OnEnable()
    {
        if (ignore == null)
        {
            ignore = GetComponent<IgnoreHovering>();
        }

        if (ignore != null)
        {
            Destroy(ignore);
        }
    }

    public void OnDisable()
    {
        if (ignore == null)
        {
            ignore = GetComponent<IgnoreHovering>();
            if (ignore == null)
            {
                ignore = gameObject.AddComponent<IgnoreHovering>();
            }
        }
    }
}
