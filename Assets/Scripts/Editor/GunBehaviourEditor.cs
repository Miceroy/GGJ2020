using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GunBehaviour))]
public class GunBehaviourEditor : Editor
{
    private GunBehaviourProperties m_behaviourProperties;
    private GunConfigObjectProperties m_objectProperties;
    private SerializedObject m_serializedGunConfigObject;
    private SerializedProperty m_serializedMuzzlePosition;

    private void OnEnable()
    {
        if(m_behaviourProperties == null)
            m_behaviourProperties = new GunBehaviourProperties(serializedObject);
    }

    public override void OnInspectorGUI()
    {
        
        serializedObject.Update();
        EditorGUILayout.ObjectField(m_behaviourProperties.GunConfigObject);
        serializedObject.ApplyModifiedProperties();

        if(m_behaviourProperties.GunConfigObject.objectReferenceValue == null)
            return;
        
        m_serializedGunConfigObject = new SerializedObject(m_behaviourProperties.GunConfigObject.objectReferenceValue);
        m_objectProperties = new GunConfigObjectProperties(m_serializedGunConfigObject);

        m_serializedMuzzlePosition = m_objectProperties.GunConfig.FindPropertyRelative("m_muzzlePosition");
        if(m_serializedMuzzlePosition == null)
            return;

        m_serializedGunConfigObject.Update();
        m_serializedMuzzlePosition.vector3Value = 
            EditorGUILayout.Vector3Field("Muzzle Position: ", m_serializedMuzzlePosition.vector3Value);
        m_serializedGunConfigObject.ApplyModifiedProperties();
    }

    public void OnSceneGUI()
    {
        if(m_behaviourProperties.GunConfigObject.objectReferenceValue == null)
            return;
            
        m_objectProperties = new GunConfigObjectProperties(m_serializedGunConfigObject);

        m_serializedMuzzlePosition = m_objectProperties.GunConfig.FindPropertyRelative("m_muzzlePosition");
        if(m_serializedMuzzlePosition == null)
            return;

        EditorGUI.BeginChangeCheck();

        Vector3 newMuzzlePosition =
            Handles.PositionHandle(
                m_serializedMuzzlePosition.vector3Value,
                Quaternion.identity
                );

        if(EditorGUI.EndChangeCheck())
        {
            m_serializedGunConfigObject.Update();
            m_serializedMuzzlePosition.vector3Value = newMuzzlePosition;
            m_serializedGunConfigObject.ApplyModifiedProperties();
            Repaint();
        }
    }
}
