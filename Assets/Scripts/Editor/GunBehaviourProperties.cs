using UnityEditor;
using UnityEngine;

public class GunBehaviourProperties
{
    private SerializedProperty m_serializedGunConfigObject;

    public SerializedProperty GunConfigObject
    {
        get { return m_serializedGunConfigObject; }
    }

    public GunBehaviourProperties(SerializedObject serializedGun)
    {
        m_serializedGunConfigObject = serializedGun.FindProperty("m_GunConfigObject");
    }
}