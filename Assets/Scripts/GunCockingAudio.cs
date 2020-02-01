using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class GunCockingAudio : MonoBehaviour
{
    public LinearMapping linear;
    public AudioSource source;
    public AudioClip pullSound;
    public AudioClip releaseSound;

    private bool fullyPulled = false;
    
    void Update()
    {
        if (linear != null)
        {
            if (linear.value > 0.9f && !fullyPulled)
            {
                if (source != null)
                {
                    source.Stop();
                    source.clip = pullSound;
                    source.Play();
                }
                fullyPulled = !fullyPulled;
            }
            else if (linear.value < 0.1f && fullyPulled)
            {
                if (source != null)
                {
                    source.Stop();
                    source.clip = releaseSound;
                    source.Play();
                }
                fullyPulled = !fullyPulled;
            }
        }
    }
}
