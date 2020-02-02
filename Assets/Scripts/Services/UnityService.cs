using UnityEngine;

public class UnityService : IUnityService
{
    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }
    public bool RayCast(Vector3 startPosition, Vector3 direction, out RaycastHit hitInfo)
    {
        return Physics.Raycast(startPosition, direction, out hitInfo);
    }
}