//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GunInput : MonoBehaviour
{
    public SteamVR_Action_Boolean shoot;
    public GunBehaviour behaviour;
    public Animator gunAnimator;
    public AudioSource source;

    private SteamVR_Input_Sources hand;
    private Interactable interactable;
    private bool isActive = false;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
        if (interactable == null)
        {
            Debug.LogWarning(this + " Script couldn't find Interactable component!");
            this.enabled = false;
        }
    }

    private void Update()
    {
        if (interactable.attachedToHand)
        {
            if (!isActive)
            {
                hand = interactable.attachedToHand.handType;
                shoot.AddOnStateDownListener(OnTriggerPress, hand);
                isActive = !isActive;
            }
        }
        else
        {
            if (isActive)
            {
                shoot.RemoveOnStateDownListener(OnTriggerPress, hand);
                isActive = !isActive;
            }
        }
    }

    private void OnTriggerPress(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (behaviour != null)
        {
            behaviour.Shoot();

            if (source != null)
            {
                source.Stop();
                source.Play();
            }

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
