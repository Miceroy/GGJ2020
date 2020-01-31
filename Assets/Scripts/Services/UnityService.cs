using UnityEngine;

public class UnityService : IUnityService
{
    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }
}