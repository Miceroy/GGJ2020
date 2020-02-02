using UnityEngine;

public interface IUnityService
{
    float GetDeltaTime();
    bool RayCast(Vector3 startPosition, Vector3 direction, out RaycastHit hitInfo);
}