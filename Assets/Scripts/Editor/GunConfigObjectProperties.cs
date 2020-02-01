using UnityEditor;

public class GunConfigObjectProperties
{
    private SerializedProperty m_serializedGunConfig;

    public SerializedProperty GunConfig { get { return m_serializedGunConfig; } }

    public GunConfigObjectProperties(SerializedObject serializedGunConfigObject)
    {
        if(serializedGunConfigObject == null)
            return;
            
        m_serializedGunConfig = serializedGunConfigObject.FindProperty("m_Config");
    }
}