using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GunInput : MonoBehaviour
{
    public SteamVR_Action_Boolean shoot;
    public SteamVR_Input_Sources handType;
    public GunBehaviour behaviour;
    public Animator gunAnimator;

    private void Start()
    {
        shoot.AddOnStateDownListener(OnTriggerPress, handType);
    }

    private void OnTriggerPress(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (behaviour != null)
        {
            behaviour.Shoot();

            if (gunAnimator != null)
            {
                gunAnimator.SetTrigger("Shoot");
            }
        }
        else
        {
            Debug.LogWarning(this + " Component is missing GunBehaviour script!");
        }
    }
}
