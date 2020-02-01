using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BoatPartBehaviour))]
public class BoatPartBehaviourEditor : Editor
{
    private BoatPartBehaviour m_behaviour;
    private SerializedProperty m_boatPartObjectProperty;

    private SerializedObject m_serializedBoatPartObject;
    private SerializedProperty m_boatConfigProperty;
    private SerializedProperty m_explosionDamageProperty;
    private SerializedProperty m_explosionRadiusProperty;

    private void OnEnable()
    {
        m_behaviour = (BoatPartBehaviour)target;
        m_boatPartObjectProperty = serializedObject.FindProperty("m_PartObject");

        if(m_boatPartObjectProperty == null)
            return;

        if(m_boatPartObjectProperty.objectReferenceValue == null)
            return;

        m_serializedBoatPartObject = new SerializedObject(m_boatPartObjectProperty.objectReferenceValue);
        m_boatConfigProperty = m_serializedBoatPartObject.FindProperty("m_Config");
        m_explosionDamageProperty = m_boatConfigProperty.FindPropertyRelative("m_explosionDamage");
        m_explosionRadiusProperty = m_boatConfigProperty.FindPropertyRelative("m_explosionRadius");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.ObjectField(m_boatPartObjectProperty);
        serializedObject.ApplyModifiedProperties();

        if(m_boatPartObjectProperty.objectReferenceValue == null)
            return;
        
        OnEnable();
        m_serializedBoatPartObject.Update();
        GUILayout.Label("Explosion");
        float damage = m_explosionDamageProperty.floatValue;
        m_explosionDamageProperty.floatValue = EditorGUILayout.FloatField("Damage: ", damage);
        float radius = m_explosionRadiusProperty.floatValue;
        m_explosionRadiusProperty.floatValue = EditorGUILayout.Slider("Radius: ", radius, 0f, 10f);
        m_serializedBoatPartObject.ApplyModifiedProperties();
    }

    private void OnSceneGUI()
    {
        OnEnable();
        
        if(m_boatPartObjectProperty == null)
            return;

        if(m_boatPartObjectProperty.objectReferenceValue == null)
            return;

        Handles.color = Color.red;

        Handles.DrawWireDisc(m_behaviour.transform.position, Vector3.up, m_explosionRadiusProperty.floatValue);
        Handles.DrawWireDisc(m_behaviour.transform.position, Vector3.right, m_explosionRadiusProperty.floatValue);
        Handles.DrawWireDisc(m_behaviour.transform.position, Vector3.forward, m_explosionRadiusProperty.floatValue);
    }
}