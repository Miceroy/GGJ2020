using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleOnAwake : MonoBehaviour
{
    private void OnAwake()
    {
        foreach(ParticleSystem particleSystem in transform.GetComponents<ParticleSystem>())
        {
            particleSystem.Play();
        }
    }
}
