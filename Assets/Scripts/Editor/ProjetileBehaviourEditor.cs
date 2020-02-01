using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ProjectileBehaviour))]
public class ProjectileBehaviourEditor : Editor
{
    private ProjectileBehaviour m_behaviour;
    private SerializedObject m_serializedProjectileObject;
    private SerializedProperty m_projectileObjectProperty;
    private SerializedProperty m_projectileConfigProperty;
    private SerializedProperty m_radiusProperty;

    private void OnEnable()
    {
        m_behaviour = (ProjectileBehaviour)target;
        m_projectileObjectProperty = serializedObject.FindProperty("m_ProjectileObject");
        
        if(m_projectileObjectProperty == null)
            return;
        
        if(m_projectileObjectProperty.objectReferenceValue == null)
            return;

        m_serializedProjectileObject = new SerializedObject(m_projectileObjectProperty.objectReferenceValue);

        m_projectileConfigProperty = m_serializedProjectileObject.FindProperty("m_Config");
        m_radiusProperty = m_projectileConfigProperty.FindPropertyRelative("m_radius");
    }

    public override void OnInspectorGUI()
    {
        OnEnable();
        serializedObject.Update();
        EditorGUILayout.ObjectField(m_projectileObjectProperty);
        serializedObject.ApplyModifiedProperties();

        if(m_projectileObjectProperty.objectReferenceValue == null)
            return;

        if(m_serializedProjectileObject == null)
        {
            m_serializedProjectileObject = new SerializedObject(m_projectileObjectProperty.objectReferenceValue);
            OnEnable();
        }

        m_serializedProjectileObject.Update();
        float newRadius = m_radiusProperty.floatValue;
        m_radiusProperty.floatValue = EditorGUILayout.Slider(newRadius, 0f, 10f);
        m_serializedProjectileObject.ApplyModifiedProperties();
    }

    private void OnSceneGUI()
    {
        OnEnable();
        if(m_projectileObjectProperty.objectReferenceValue == null)
            return;

        Handles.color = Color.red;

        Handles.DrawWireDisc(m_behaviour.transform.position, Vector3.up, m_radiusProperty.floatValue);
        Handles.DrawWireDisc(m_behaviour.transform.position, Vector3.right, m_radiusProperty.floatValue);
        Handles.DrawWireDisc(m_behaviour.transform.position, Vector3.forward, m_radiusProperty.floatValue);
    }
}